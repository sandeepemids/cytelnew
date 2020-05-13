using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Simulation.Models.StatisticalDesignModels
{
    public class FixSampleScenario
    {
        [JsonProperty(PropertyName = "msgVersion")]
        public decimal MsgVersion { get; set; }

        [JsonProperty(PropertyName = "msgType")]
        public string MsgType { get; set; }

        [JsonProperty(PropertyName = "msgId")]
        public Guid MsgId { get; set; }

        [JsonProperty(PropertyName = "target")]
        public TargetModel Target { get; set; }

        [JsonProperty(PropertyName = "computeInfo")]
        public List<ComputeInfoModel> ComputeInfo { get; set; }

        [JsonProperty(PropertyName = "project")]
        public ProjectModel Project { get; set; }

        [JsonProperty(PropertyName = "population")]
        public PopulationModel Population { get; set; }

        [JsonProperty(PropertyName = "enrollment")]
        public EnrollmentModel Enrollment { get; set; }

        [JsonProperty(PropertyName = "design")]
        public DesignModel Design { get; set; }

        [JsonProperty(PropertyName = "simulationResults")]
        public SimulationResultsModel SimulationResults { get; set; }

        public class TargetModel
        {
            [JsonProperty(PropertyName = "location")]
            public string Location { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "version")]
            public string Version { get; set; }
        }

        public class ComputeInfoModel
        {
            [JsonProperty(PropertyName = "stage")]
            public string Stage { get; set; }

            [JsonProperty(PropertyName = "receivedTime")]
            public string ReceivedTime { get; set; }

            [JsonProperty(PropertyName = "sentTime")]
            public string SentTime { get; set; }
        }

        public class ProjectModel
        {
            [JsonProperty(PropertyName = "scenarioId")]
            public string ScenarioId { get; set; }

            [JsonProperty(PropertyName = "projectName")]
            public string ProjectName { get; set; }

            [JsonProperty(PropertyName = "timeUnit")]
            public string TimeUnit { get; set; }

            [JsonProperty(PropertyName = "controlArm")]
            public string ControlArm { get; set; }

            [JsonProperty(PropertyName = "treatmentArm")]
            public string TreatmentArm { get; set; }

            [JsonProperty(PropertyName = "numberOfSim")]
            public int NumberOfSim { get; set; }

            [JsonProperty(PropertyName = "simSeed")]
            public int SimSeed { get; set; }
        }

        public class PopulationModel
        {
            [JsonProperty(PropertyName = "populationId")]
            public string PopulationId { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "virtualPopulationSize")]
            public int VirtualPopulationSize { get; set; }

            [JsonProperty(PropertyName = "endpointModel")]
            public List<EndpointModel> EndpointModel { get; set; }

            [JsonProperty(PropertyName = "dropoutRateModel")]
            public DropoutRateDataModel DropoutRateModel { get; set; }

        }

        public class EndpointModel
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "endpoint")]
            public string Endpoint { get; set; }

            [JsonProperty(PropertyName = "type")]
            public string Type { get; set; }

            [JsonProperty(PropertyName = "modelName")]
            public string ModelName { get; set; }

            [JsonProperty(PropertyName = "inputMethod")]
            public string InputMethod { get; set; }

            [JsonProperty(PropertyName = "inputData")]
            public List<InputDataEndpointModel> InputData { get; set; }
        }

        public class InputDataEndpointModel
        {
            [JsonProperty(PropertyName = "control")]
            public decimal Control { get; set; }

            [JsonProperty(PropertyName = "treatment")]
            public decimal Treatment { get; set; }

            [JsonProperty(PropertyName = "hazardRatio")]
            public decimal HazardRatio { get; set; }
        }

        public class DropoutRateDataModel
        {
            [JsonProperty(PropertyName = "modelName")]
            public string ModelName { get; set; }

            [JsonProperty(PropertyName = "inputMethod")]
            public string InputMethod { get; set; }

            [JsonProperty(PropertyName = "inputData")]
            public List<InputDataDropRateModel> InputData { get; set; }
        }

        public class InputDataDropRateModel
        {
            [JsonProperty(PropertyName = "byTime")]
            public decimal ByTime { get; set; }

            [JsonProperty(PropertyName = "control")]
            public decimal Control { get; set; }

            [JsonProperty(PropertyName = "treatment")]
            public decimal Treatment { get; set; }
        }

        public class EnrollmentModel
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "inputMethod")]
            public string InputMethod { get; set; }

            [JsonProperty(PropertyName = "distribution")]
            public string Distribution { get; set; }

            [JsonProperty(PropertyName = "sites")]
            public List<SitesModel> Sites { get; set; }

            [JsonProperty(PropertyName = "enrollmentId")]
            public string EnrollmentId { get; set; }
        }

        public class SitesModel
        {
            [JsonProperty(PropertyName = "geography")]
            public string Geography { get; set; }

            [JsonProperty(PropertyName = "siteInititationTime")]
            public int SiteInititationTime { get; set; }

            [JsonProperty(PropertyName = "avgPatientsEnrolled")]
            public int AvgPatientsEnrolled { get; set; }

            [JsonProperty(PropertyName = "enrollmentCap")]
            public decimal EnrollmentCap { get; set; }
        }

        public class DesignModel
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "primaryEndpoint")]
            public string PrimaryEndpoint { get; set; }

            [JsonProperty(PropertyName = "numberOfArms")]
            public int NumberOfArms { get; set; }

            [JsonProperty(PropertyName = "regulatoryRiskAssessment")]
            public string RegulatoryRiskAssessment { get; set; }

            [JsonProperty(PropertyName = "statisticalDesign")]
            public string StatisticalDesign { get; set; }

            [JsonProperty(PropertyName = "hypothesis")]
            public string Hypothesis { get; set; }

            [JsonProperty(PropertyName = "numberOfEvents")]
            public int NumberOfEvents { get; set; }

            [JsonProperty(PropertyName = "sampleSize")]
            public int SampleSize { get; set; }

            [JsonProperty(PropertyName = "allocationRatio")]
            public decimal AllocationRatio { get; set; }

            [JsonProperty(PropertyName = "subjectsAreFollowedType")]
            public string SubjectsAreFollowedType { get; set; }

            [JsonProperty(PropertyName = "subjectsAreFollowedPeriod")]
            public int SubjectsAreFollowedPeriod { get; set; }

            [JsonProperty(PropertyName = "type1Error")]
            public decimal Type1Error { get; set; }

            [JsonProperty(PropertyName = "testStatistics")]
            public string TestStatistics { get; set; }

            [JsonProperty(PropertyName = "testType")]
            public string TestType { get; set; }

            [JsonProperty(PropertyName = "tailType")]
            public string TailType { get; set; }

            [JsonProperty(PropertyName = "criticalPoint")]
            public decimal CriticalPoint { get; set; }
        }

        public class SimulationResultsModel
        { }
    }
}
