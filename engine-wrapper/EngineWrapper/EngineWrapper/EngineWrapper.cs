using EngineWrapper.DataLake;
using EngineWrapper.Interface;
using EngineWrapper.MessageQueue;
using System;
using EngineWrapper.Utils;
using EngineWrapper.Logger;
using Microsoft.Azure.Storage.Queue;

namespace EngineWrapper
{
    public class EngineWrapper
    {
        Logging logger;
        private string storageConnectionString;
        public EngineWrapper()
        {
            logger = new Logging("EngineWrapper");
            storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", ConfigurationConstant.StorageAccountName, ConfigurationConstant.StorageAccountKey);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool WrapperOperations()
        {
            try
            {
                //Read messge from Queue
                CloudQueueMessage readQueueMessage = ReadMessage();
                if (readQueueMessage != null)
                {
                    JsonOperations jsonOperations = new JsonOperations();
                    //Update message
                    string updatedMessage = jsonOperations.UpdateInputMessageJsonField(readQueueMessage.AsString);
                    //Find the Engine Name
                    string engineName = jsonOperations.FindEngineName(updatedMessage);
                    //Add the engine stage as per engine name
                    string engineMessage = jsonOperations.AddEngineStageJsonField(updatedMessage, engineName);
                    if (!string.IsNullOrEmpty(engineMessage))
                    {
                        //Call a Engine 
                        string engineOutput = FixedSampleEngine.ComputeOutput(engineMessage);
                        //Update timestamp in engine stage.
                        string stageUpdatedMessage = jsonOperations.UpdateEngineStageJsonField(engineMessage, engineName);
                        //added result in message
                        string summaryResultMessage = jsonOperations.AddEngineOutputSummary(stageUpdatedMessage, engineOutput);
                        if (!string.IsNullOrEmpty(summaryResultMessage))
                        {
                            //Update JSON file with output data
                            string outputMessage = jsonOperations.AddOutputMessageJsonField(summaryResultMessage);
                            if (!string.IsNullOrEmpty(outputMessage))
                            {
                                //write to output Queue
                                bool isMessageWrite = WriteMessage(outputMessage);

                                //Upload to DataLake                        
                                bool isDataUpload = UploadDataToDataLake(outputMessage);
                                if (isMessageWrite && isDataUpload)
                                {
                                    return DeleteQueueMessage(readQueueMessage);
                                }
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Preparing inputs for read message method from QueueOperations class and call.
        /// </summary>
        /// <returns>Return read message as string</returns>
        CloudQueueMessage ReadMessage()
        {
            IQueueOperations queueOperations = new QueueOperations();
            return queueOperations.ReadMessage(storageConnectionString, ConfigurationConstant.ComputQueueName).Result;
        }

        /// <summary>
        /// Preparing inputs for write message method from QueueOperations class and call.
        /// </summary>
        /// <param name="outputMessage">output message</param>
        /// <returns>if write message in queue successfully, it returns true.</returns>
        bool WriteMessage(string outputMessage)
        {
            IQueueOperations queueOperations = new QueueOperations();
            return queueOperations.WriteMessage(storageConnectionString, ConfigurationConstant.OutputQueueName, outputMessage).Result;
        }

        /// <summary>
        /// Preparing inputs for upload data method from DataLakeOperations class and call.
        /// </summary>
        /// <param name="jsonFileContent">Engine output data in JSON</param>
        /// <returns>if engien output data is upload successfully, it returns true.</returns>
        bool UploadDataToDataLake(string jsonFileContent)
        {
            IDataLakeOperations dataLakeOperations = new DataLakeOperations();
            return dataLakeOperations.UploadData(ConfigurationConstant.StorageAccountName, ConfigurationConstant.StorageAccountKey, ConfigurationConstant.DataLakeUri, ConfigurationConstant.DataLakeDirectoryName, jsonFileContent).Result;

        }

        bool DeleteQueueMessage(CloudQueueMessage cloudQueueMessage)
        {
            IQueueOperations queueOperations = new QueueOperations();
            return queueOperations.DeleteMessage(storageConnectionString, ConfigurationConstant.ComputQueueName, cloudQueueMessage).Result;
        }
    }
}
