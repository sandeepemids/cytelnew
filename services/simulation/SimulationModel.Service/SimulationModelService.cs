using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Simulation.SimulationConstants;
using Simulation.DataAccess;
using Simulation.DataAccess.Interfaces;
using Simulation.Models;
using Simulation.Models.StatisticalDesignModels;
using SimulationModel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace SimulationModel.Service
{
    public class SimulationModelService : ISimulationModelService
    {
        private readonly ISimulationDataAccess simulationDataAccess;
        private readonly IOptions<SimulationSettings> simulationSettings;

        public SimulationModelService(IOptions<SimulationSettings> settings)
        {
            simulationDataAccess = new SimulationDataAccess(settings.Value.DBConnectionString);
            simulationSettings = settings;
        }

        public void CreateSimulationModels()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate simulation json schema
        /// </summary>
        /// <param name="jsonMessage"></param>
        /// <param name="jsonSchema"></param>
        /// <param name="validationMessages"></param>
        /// <returns></returns>
        private bool ValidateJsonSchema(string jsonMessage, JSchema jsonSchema, out IList<string> validationMessages)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonMessage);
                return jsonObject.IsValid(jsonSchema, out validationMessages);
            }
            catch(Exception validateJsonSchemaException)
            {
                throw new Exception(SimulationException.VALIDATE_JSON_SCHEMA_ERROR_MSG, validateJsonSchemaException);
            }
        }

        /// <summary>
        /// Create message for queue
        /// </summary>
        /// <param name="typeOfEngine"></param>
        /// <param name="jsonMessage"></param>
        /// <returns></returns>
        public SimulationResponse SimulateModel(string schemaFileName, string jsonMessage)
        {
            IList<string> validationMessages = new List<string>();
            SimulationResponse response = new SimulationResponse();
            try
            {
                JSchema jsonSchema = JSchema.Parse(File.ReadAllText(Path.Combine(simulationSettings.Value.JsonSchemaFilePath, schemaFileName)));
                if (ValidateJsonSchema(jsonMessage, jsonSchema, out validationMessages))
                {
                    response.QueueMessage = JsonConvert.SerializeObject(jsonMessage);
                }
                else
                {
                    response.ErrorMessages = validationMessages;
                }
                return response;
            }
            catch (Exception simulateModelException)
            {
                throw new Exception(SimulationException.SIMULATE_MODEL_ERROR_MSG, simulateModelException);
            }
        }

        /// <summary>
        /// Create Simulation Queue
        /// </summary>
        /// <param name="queueMessage"></param>
        /// <returns></returns>
        public bool CreateSimulationQueue(string queueMessage)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(simulationSettings.Value.QueueConnectionString);
                CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(simulationSettings.Value.QueueName);
                cloudQueue.CreateIfNotExists();
                return AddSimulationMessageToQueue(cloudQueue, queueMessage);
            }
            catch(Exception createQueueException)
            {
                throw new Exception(SimulationException.CREATE_QUEUE_ERROR_MSG, createQueueException);
            }
        }

        /// <summary>
        /// Add Simulation Message To Queue
        /// </summary>
        /// <param name="cloudQueue"></param>
        /// <param name="queueMessage"></param>
        /// <returns></returns>
        private bool AddSimulationMessageToQueue(CloudQueue cloudQueue, string queueMessage)
        {
            try
            {
                CloudQueueMessage message = new CloudQueueMessage(queueMessage);
                cloudQueue.AddMessage(message);
                return true;
            }
            catch (Exception addMessageToQueueException)
            {
                throw new Exception(SimulationException.CREATE_QUEUE_MESSAGE_ERROR_MSG, addMessageToQueueException);
            }
        }

        /// <summary>
        /// Create Simulation Data
        /// </summary>
        /// <param name="fixSampleScenario"></param>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public bool CreateSimulationData(string fixSampleScenario, Guid simulationModelId, int projectSimulationId, int resourceId)
        {
            return simulationDataAccess.CreateSimulationData(fixSampleScenario, simulationModelId, projectSimulationId, resourceId);
        }

        public int GetModelCount()
        {
            throw new NotImplementedException();
        }

        public void CreateProjectSimulation()
        {
            throw new NotImplementedException();
        }

        public void GenerateMultipleModels()
        {
            throw new NotImplementedException();
        }
    }
}
