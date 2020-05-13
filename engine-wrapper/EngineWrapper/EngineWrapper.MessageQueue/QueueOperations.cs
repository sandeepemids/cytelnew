using System;
using System.Threading.Tasks;
using EngineWrapper.Interface;
using EngineWrapper.Logger;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace EngineWrapper.MessageQueue
{
    public class QueueOperations : IQueueOperations
    {
        Logging logger;

        public QueueOperations()
        {
            logger = new Logging("QueueOperations");
        }

        /// <summary>
        /// Delete message from queue.
        /// </summary>
        /// <param name="storageConnectionString">zure Storage connection string</param>
        /// <param name="queueName">Azure Storage Queue Name</param>
        /// <param name="cloudQueueMessage">Azure cloud queue message object</param>
        /// <returns></returns>
        public async Task<bool> DeleteMessage(string storageConnectionString, string queueName, CloudQueueMessage cloudQueueMessage)
        {
            try
            {
                CloudQueue cloudQueue = ConnectToQueue(storageConnectionString, queueName);
                await cloudQueue.DeleteMessageAsync(cloudQueueMessage);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return false;
            }                
        }

        /// <summary>
        /// Read message from the Azure Storage Queue (Compute Queue)
        /// </summary>
        /// <param name="storageConnectionString">Azure Storage connection string</param>
        /// <param name="queueName">Azure Storage Queue Name</param>
        /// <returns></returns>
        public async Task<CloudQueueMessage> ReadMessage(string storageConnectionString, string queueName)
        {
            try
            {
                CloudQueue cloudQueue = ConnectToQueue(storageConnectionString, queueName);
                if(cloudQueue != null)
                {
                    CloudQueueMessage retrievedMessage = await cloudQueue.GetMessageAsync();
                    if (retrievedMessage != null)
                    {
                        return retrievedMessage;

                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                logger.Error(ex.StackTrace);
                return null;
            }            
        }

        /// <summary>
        /// Write message to the Azure Storage Queue (Output Queue)
        /// </summary>
        /// <param name="storageConnectionString">Azure Storage connection string</param>
        /// <param name="queueName">Azure Storage Queue Name</param>
        /// <param name="message">Write/Add message in the queue</param>
        /// <returns></returns>
        public async Task<bool> WriteMessage(string storageConnectionString, string queueName, string message)
        {
            try
            {
                CloudQueue cloudQueue = ConnectToQueue(storageConnectionString, queueName);
                if(cloudQueue != null)
                {
                    CloudQueueMessage cloudQueueMessage = new CloudQueueMessage(message);
                    await cloudQueue.AddMessageAsync(cloudQueueMessage, TimeSpan.FromSeconds(-1), null, null, null);
                    return true;
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
        /// using the Azure SDK connect to the Azure Storage Queue
        /// </summary>
        /// <param name="storageConnectionString">Azure Storage connection string</param>
        /// <param name="queueName">Azure Storage Queue Name to connect the queue</param>
        /// <returns></returns>
        private CloudQueue ConnectToQueue(string storageConnectionString, string queueName)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudQueueClient cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();
                CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(queueName);
                return cloudQueue;
            }
            catch(Exception ex)
            {
                logger.Error(ex.StackTrace);
                return null;
            }
        }
    }
}
