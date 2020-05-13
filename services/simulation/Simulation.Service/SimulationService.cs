using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Simulation.DataAccess;
using Simulation.DataAccess.Interfaces;
using Simulation.Models;
using Simulation.Service.Interfaces;
using SimulationModel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Simulation.SimulationConstants;
using System.Data;
using Newtonsoft.Json.Linq;

namespace Simulation.Service
{
    public class SimulationService : ISimulationService
    {
        private readonly ISimulationDataAccess simulationDataAccess;
        private readonly ISimulationModelService simulationModelService;

        public SimulationService(IOptions<SimulationSettings> settings, ISimulationModelService simulationModelService)
        {
            simulationDataAccess = new SimulationDataAccess(settings.Value.DBConnectionString);
            this.simulationModelService = simulationModelService;
        }

        /// <summary>
        /// Get Model Count And Execution Time
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <param name="statisticalEngineId"></param>
        /// <returns></returns>
        private SimulationResponseModel GetSimulationModelCountAndExecutionTime(int projectId, int resourceId, int statisticalEngineId, int projectSimulationId)
        {
            return GenerateSimulationModels(projectId, resourceId, statisticalEngineId, projectSimulationId);
        }

        /// <summary>
        /// Get Project Json Object
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        private DataTable GetProjectJsonObject(int projectId, int resourceId)
        {
            return simulationDataAccess.GetProjectJsonObject(projectId, resourceId);
        }

        /// <summary>
        /// Get Statistical Engine Details
        /// </summary>
        /// <param name="statisticalEngineId"></param>
        /// <returns></returns>
        private DataTable GetStatisticalEngineDetails(int statisticalEngineId)
        {
            return simulationDataAccess.GetStatisticalEngineDetails(statisticalEngineId);
        }

        /// <summary>
        /// Create List For Model
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string[] CreateListForModel(string data)
        {
            if (data.Contains(','))
                return data.Trim().Replace(" ", string.Empty).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            else
                return new string[] { data };
        }

        /// <summary>
        /// Get Simulation Multiple Data Model
        /// </summary>
        /// <param name="inputAdvisorModel"></param>
        /// <returns></returns>
        private SimulationMultipleDataModel GetSimulationMultipleDataModel(InputAdvisorModel inputAdvisorModel)
        {
            try {
                List<EndpointMultipleData> endpointMultiples = new List<EndpointMultipleData>();

                foreach (var population in inputAdvisorModel.Population)
                {
                    foreach (var endpoint in population.EndpointModel)
                    {
                        EndpointMultipleData endpointMultipleData = new EndpointMultipleData
                        {
                            PopulationEndpointControl = CreateListForModel(endpoint.Control),
                            PopulationEndpointHazardRatio = CreateListForModel(endpoint.HazardRatio),
                            PopulationDropoutRateControl = CreateListForModel(population.DropoutRateModel.Control),
                            PopulationDropoutRateTreatment = CreateListForModel(population.DropoutRateModel.Treatment),
                            Population = population,
                            Endpoint = endpoint
                        };
                        endpointMultiples.Add(endpointMultipleData);
                    }
                }

                List<EnrollmentMultipleData> enrollmentMultiples = new List<EnrollmentMultipleData>();
                foreach (var enrollment in inputAdvisorModel.Enrollment)
                {
                    foreach (var site in enrollment.Sites)
                    {
                        EnrollmentMultipleData enrollmentMultiple = new EnrollmentMultipleData
                        {
                            EnrollmentGeography = CreateListForModel(site.Geography.Value),
                            PatientEnrolledPerUnit = CreateListForModel(site.AvgPatientsEnrolled),
                            Enrollment = enrollment,
                            Site = site
                        };
                        enrollmentMultiples.Add(enrollmentMultiple);
                    }
                }
                SimulationMultipleDataModel multipleModelData = new SimulationMultipleDataModel
                {
                    EndpointMultipleData = endpointMultiples,
                    EnrollmentMultipleData = enrollmentMultiples,
                };
                return multipleModelData;
            }
            catch(Exception getSimulationMultipleDataModel)
            {
                throw new Exception(SimulationException.GET_SIMULATION_MULTIPLE_DATA_MODEL_EXCEPTION, getSimulationMultipleDataModel);
            }
        }

        /// <summary>
        /// Generate Simulation Models
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <param name="statisticalEngineId"></param>
        /// <returns></returns>
        private SimulationResponseModel GenerateSimulationModels(int projectId, int resourceId, int statisticalEngineId, int projectSimulationId)
        {
            try
            {
                var response = new SimulationResponseModel();
                var inputAdvisor = GetProjectJsonObject(projectId, resourceId);
                var statisticalEngine = GetStatisticalEngineDetails(statisticalEngineId);
                string simulationReceivedTime = DateTime.UtcNow.ToString(Constants.SIMULATION_RECEIVED_DATE_FORMAT);
                var models = CreateSimulationModels(inputAdvisor, statisticalEngine, simulationReceivedTime);

                //Create queue and save models
                response = SimulateModel(statisticalEngine.Rows[0]["schemafilename"].ToString(), models, projectSimulationId, resourceId);

                //update model count
                UpdateProjectSimulationModelCount(projectSimulationId, models.Count());
                return response;
            }
            catch(Exception generateSimulationModelsException)
            {
                throw new Exception(SimulationException.GENERATE_SIMULATION_MODELS_EXCEPTION, generateSimulationModelsException);
            }
        }

        /// <summary>
        /// Create Fixed Sample Models
        /// </summary>
        /// <param name="inputAdvisor"></param>
        /// <param name="statisticalEngine"></param>
        /// <param name="simulationReceivedTime"></param>
        /// <param name="statisticalEngineId"></param>
        /// <returns></returns>
        private List<string> CreateSimulationModels(DataTable inputAdvisor, DataTable statisticalEngine, 
            string simulationReceivedTime)
        {
            InputAdvisorModel inputAdvisorModel = new InputAdvisorModel();
            if (inputAdvisor != null)
            {
                inputAdvisorModel = JsonConvert.DeserializeObject<InputAdvisorModel>(inputAdvisor.Rows[0]["object"].ToString());
            }
            SimulationMultipleDataModel multipleModelData = GetSimulationMultipleDataModel(inputAdvisorModel);

            EngineFactory engineFactory = new EngineFactory();
            var simulationModels = engineFactory.CreateModels(inputAdvisor, statisticalEngine, simulationReceivedTime, multipleModelData);
            return simulationModels.EngineModels;
        }

        /// <summary>
        /// Create Queue and Save Models into PostgresSql
        /// </summary>
        /// <param name="statisticalEngineType"></param>
        /// <param name="engineModels"></param>
        /// <param name="projectSimulationId"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        private SimulationResponseModel SimulateModel(string schemaFileName, List<string> engineModels, int projectSimulationId, int resourceId)
        {
            var response = new SimulationResponseModel
            {
                ErrorMessages = new List<IList<string>>()
            };
            long modelCount = 0;
            try
            {
                foreach (var engineModel in engineModels)
                {
                    var simulateModelResponse = simulationModelService.SimulateModel(schemaFileName, engineModel);
                    if (simulateModelResponse.ErrorMessages == null)
                    {
                        //create queue and add message
                        if (simulationModelService.CreateSimulationQueue(simulateModelResponse.QueueMessage))
                        {
                            //create data into SimulationModel
                            var data = JObject.Parse(engineModel);
                            var simulationModelId = (Guid)data["msgId"];
                            simulationModelService.CreateSimulationData(engineModel, simulationModelId, projectSimulationId, resourceId);
                            modelCount++;
                        }
                    }
                    else
                    {
                        response.ErrorMessages.Add(simulateModelResponse.ErrorMessages);
                    }
                }
                response.NoOfModels = modelCount;
                response.TimeInSeconds = 5 * (int)modelCount;
                return response;
            }
            catch(Exception simulateModelException)
            {
                throw new Exception(SimulationException.SIMULATE_MODEL_ERROR_MSG, simulateModelException);
            }
        }

        /// <summary>
        /// Create Project Simulation Data
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        private int CreateProjectSimulationData(int projectId, int resourceId, string createdBy)
        {
            return simulationDataAccess.CreateProjectSimulationData(projectId, resourceId, createdBy);
        }

        /// <summary>
        /// Update Project Simulation Model Count
        /// </summary>
        /// <param name="projectSimulationId"></param>
        /// <param name="modelCount"></param>
        /// <returns></returns>
        private bool UpdateProjectSimulationModelCount(int projectSimulationId, int modelCount)
        {
            return simulationDataAccess.UpdateProjectSimulationModelCount(projectSimulationId, modelCount);
        }

        /// <summary>
        /// Simulate
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <param name="statisticalEngineId"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public SimulationResponseModel Simulate(int projectId, int resourceId, int statisticalEngineId, string createdBy)
        {
            try
            {
                int projectSimulationId = CreateProjectSimulationData(projectId, resourceId, createdBy);
                return GetSimulationModelCountAndExecutionTime(projectId, resourceId, statisticalEngineId, projectSimulationId);
            }
            catch(Exception simulateException)
            {
                throw new Exception(SimulationException.CREATE_SIMULATION_DATA_ERROR_MSG, simulateException);
            }
        }
    }
}