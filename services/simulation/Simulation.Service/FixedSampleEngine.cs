using Newtonsoft.Json;
using Simulation.Models;
using Simulation.Models.StatisticalDesignModels;
using Simulation.Service.Interfaces;
using Simulation.SimulationConstants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Simulation.Service
{
    public class FixedSampleEngine : IEngine
    {
        public List<string> EngineModels { get; private set; }
        public FixedSampleEngine() { }

        public FixedSampleEngine(DataTable inputAdvisor, DataTable statisticalEngine,
            string simulationReceivedTime, SimulationMultipleDataModel multipleModelData)
        {
            EngineModels = CreateFixedSampleModels(inputAdvisor, statisticalEngine, simulationReceivedTime, multipleModelData);
        }

        private List<string> CreateFixedSampleModels(DataTable inputAdvisor, DataTable statisticalEngine,
            string simulationReceivedTime, SimulationMultipleDataModel multipleModelData)
        {
            var models = new List<string>();
            InputAdvisorModel inputAdvisorModel = new InputAdvisorModel();
            if (inputAdvisor != null)
            {
                inputAdvisorModel = JsonConvert.DeserializeObject<InputAdvisorModel>(inputAdvisor.Rows[0]["object"].ToString());
            }

            foreach (var populationMultiples in multipleModelData.EndpointMultipleData)
            {
                foreach (var enrollmentMultiples in multipleModelData.EnrollmentMultipleData)
                {
                    var simulationModels = from endpointControl in populationMultiples.PopulationEndpointControl
                                           from endpointHazardRatio in populationMultiples.PopulationEndpointHazardRatio
                                           from pDropoutRateControl in populationMultiples.PopulationDropoutRateControl
                                           from pDropoutRateTreatment in populationMultiples.PopulationDropoutRateTreatment
                                           from pEnrollmentGeography in enrollmentMultiples.EnrollmentGeography
                                           from PpatientEnrolledPerUnit in enrollmentMultiples.PatientEnrolledPerUnit
                                           select new
                                           {
                                               endpointControl,
                                               endpointHazardRatio,
                                               pDropoutRateControl,
                                               pDropoutRateTreatment,
                                               pEnrollmentGeography,
                                               PpatientEnrolledPerUnit
                                           };
                    foreach (var model in simulationModels)
                    {
                        FixSampleScenario fixSampleScenario
                             = new FixSampleScenario
                             {
                                 MsgId = Guid.NewGuid(),
                                 MsgType = Constants.FIXED_SAMPLE_MESSAGE_TYPE,
                                 MsgVersion = (long)1.0, //Hardcoded for May release. There will be future story to pass the message version.

                                 Target = new FixSampleScenario.TargetModel
                                 {
                                     Location = statisticalEngine.Rows[0]["location"]?.ToString(),
                                     Name = statisticalEngine.Rows[0]["name"]?.ToString(),
                                     Id = Convert.ToInt32(statisticalEngine.Rows[0]["engineid"]),
                                     Version = statisticalEngine.Rows[0]["version"]?.ToString(),
                                 },
                                 ComputeInfo = new List<FixSampleScenario.ComputeInfoModel>
                                  {
                                    new FixSampleScenario.ComputeInfoModel { Stage = Constants.FIXED_SAMPLE_SIMULATION_STAGE, ReceivedTime = simulationReceivedTime, SentTime = "" },
                                  },
                                 Project = new FixSampleScenario.ProjectModel
                                 {
                                     ScenarioId = Guid.NewGuid().ToString(),
                                     ProjectName = inputAdvisor.Rows[0]["name"]?.ToString(),
                                     TimeUnit = populationMultiples.Population.DropoutRateModel.ByTime.ToString(),
                                     ControlArm = inputAdvisorModel.Objective.ControlArm,
                                     TreatmentArm = inputAdvisorModel.Objective.TreatmentArm,
                                     NumberOfSim = Convert.ToInt32(inputAdvisor.Rows[0]["numberofsim"].ToString()),
                                     SimSeed = Convert.ToInt32(inputAdvisor.Rows[0]["simseed"].ToString())
                                 },
                                 Population = new FixSampleScenario.PopulationModel
                                 {
                                     PopulationId = Guid.NewGuid().ToString(),
                                     Name = populationMultiples.Population.Name,
                                     VirtualPopulationSize = populationMultiples.Population.VirtualPopulationSize,
                                     EndpointModel = new List<FixSampleScenario.EndpointModel>
                                       {
                                    new FixSampleScenario.EndpointModel
                                    {
                                        Name = inputAdvisorModel.Objective.Endpoint.FirstOrDefault(name => name.Id == populationMultiples.Endpoint.EndpointId)?.Name,
                                        Endpoint = inputAdvisorModel.Objective.Endpoint.FirstOrDefault(endpoint => endpoint.Id == populationMultiples.Endpoint.EndpointId)?.Endpoint,
                                        Type = inputAdvisorModel.Objective.Endpoint.FirstOrDefault(type => type.Id == populationMultiples.Endpoint.EndpointId)?.Type,
                                        ModelName = populationMultiples.Endpoint.Model.Value,
                                        InputMethod = populationMultiples.Endpoint.InputMethod.Value,
                                        InputData = new List<FixSampleScenario.InputDataEndpointModel>
                                        {
                                            new FixSampleScenario.InputDataEndpointModel
                                            {
                                                Control = Convert.ToDecimal(model.endpointControl),
                                                Treatment = Convert.ToDecimal(populationMultiples.Endpoint.Treatment),
                                                HazardRatio = Convert.ToDecimal(model.endpointHazardRatio)
                                            },
                                        }
                                    },
                                   },
                                     DropoutRateModel = new FixSampleScenario.DropoutRateDataModel
                                     {
                                         ModelName = populationMultiples.Population.DropoutRateModel.Model.Value,
                                         InputMethod = populationMultiples.Population.DropoutRateModel.InputMethod.Value,
                                         InputData = new List<FixSampleScenario.InputDataDropRateModel>
                                        {
                                            new FixSampleScenario.InputDataDropRateModel
                                            {
                                                ByTime = populationMultiples.Population.DropoutRateModel.ByTime,
                                                Control = Convert.ToDecimal(model.pDropoutRateControl),
                                                Treatment = Convert.ToDecimal(model.pDropoutRateTreatment)
                                            },
                                        },
                                     },
                                 },
                                 Enrollment = new FixSampleScenario.EnrollmentModel
                                 {
                                     EnrollmentId = enrollmentMultiples.Enrollment.EnrollmentId,
                                     Name = enrollmentMultiples.Enrollment.Name,
                                     InputMethod = enrollmentMultiples.Enrollment.InputMethod.Value,
                                     Distribution = enrollmentMultiples.Enrollment.Distribution.Value,
                                     Sites = new List<FixSampleScenario.SitesModel>
                                    {
                                    new FixSampleScenario.SitesModel
                                    {
                                        Geography = model.pEnrollmentGeography,
                                        SiteInititationTime = enrollmentMultiples.Site.SiteInititationTime,
                                        AvgPatientsEnrolled = Convert.ToInt32(model.PpatientEnrolledPerUnit),
                                        EnrollmentCap = enrollmentMultiples.Site.EnrollmentCap
                                    }
                                    }
                                 },
                                 Design = new FixSampleScenario.DesignModel //Hardcoded value for current sprint
                                 {
                                      Name = "Name of Design",
                                      TailType = "Left Tail",
                                      TestType = "1-Sided",
                                      Hypothesis = "Superiority",
                                      SampleSize = 400,
                                      NumberOfArms = 2,
                                      CriticalPoint = Convert.ToDecimal(-1.96),
                                      NumberOfEvents = 120,
                                      TestStatistics = "Logrank",
                                      AllocationRatio = Convert.ToDecimal(3.5),
                                      PrimaryEndpoint = "Overall Survival",
                                      StatisticalDesign = "Fixed Sample",
                                      SubjectsAreFollowedType = "Fixed Period",
                                      RegulatoryRiskAssessment = "Low",
                                      SubjectsAreFollowedPeriod = 3
                                 },
                                 SimulationResults = new FixSampleScenario.SimulationResultsModel()
                             };
                        models.Add(JsonConvert.SerializeObject(fixSampleScenario));
                    }
                }
            }
            return models;
        }
    }
}
