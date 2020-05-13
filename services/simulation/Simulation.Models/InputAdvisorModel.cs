using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Models
{
    public class InputAdvisorModel
    {
        [JsonProperty(PropertyName = "validated")]
        public bool Validated { get; set; }

        [JsonProperty(PropertyName = "objective")]
        public ObjectiveModel Objective { get; set; }

        [JsonProperty(PropertyName = "population")]
        public List<PopulationModel> Population { get; set; }

        [JsonProperty(PropertyName = "enrollment")]
        public List<EnrollmentModel> Enrollment { get; set; }

        [JsonProperty(PropertyName = "operationalCost")]
        public List<OperationalCostModel> OperationalCost { get; set; }

        [JsonProperty(PropertyName = "marketAccess")]
        public List<MarketAccessModel> MarketAccess { get; set; }

        [JsonProperty(PropertyName = "design")]
        public List<DesignModel> Design { get; set; }
    }

    public class ObjectiveModel
    {
        [JsonProperty(PropertyName = "populationName")]
        public string PopulationName { get; set; }
        [JsonProperty(PropertyName = "treatmentArm")]
        public string TreatmentArm { get; set; }
        [JsonProperty(PropertyName = "controlArm")]
        public string ControlArm { get; set; }
        [JsonProperty(PropertyName = "endpoint")]
        public List<EndpointModel> Endpoint { get; set; }
        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class EndpointModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "cardOrder")]
        public string CardOrder { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class ErrorModel
    {
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }

    public class PopulationEndpointModel
    {
        [JsonProperty(PropertyName = "endpointId")]
        public int EndpointId { get; set; }

        [JsonProperty(PropertyName = "model")]
        public CommonIdValueModel Model { get; set; }

        [JsonProperty(PropertyName = "inputMethod")]
        public CommonIdValueModel InputMethod { get; set; }

        [JsonProperty(PropertyName = "numberOfPieces")]
        public int NumberOfPieces { get; set; }

        [JsonProperty(PropertyName = "control")]
        public string Control { get; set; }

        [JsonProperty(PropertyName = "treatment")]
        public string Treatment { get; set; }

        [JsonProperty(PropertyName = "hazardRatio")]
        public string HazardRatio { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class CommonIdValueModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
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
        public List<PopulationEndpointModel> EndpointModel { get; set; }

        [JsonProperty(PropertyName = "dropoutRateModel")]
        public DropoutRateDataModel DropoutRateModel { get; set; }

        [JsonProperty(PropertyName = "cardOrder")]
        public int CardOrder { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class DropoutRateDataModel
    {
        [JsonProperty(PropertyName = "model")]
        public CommonIdValueModel Model { get; set; }

        [JsonProperty(PropertyName = "inputMethod")]
        public CommonIdValueModel InputMethod { get; set; }

        [JsonProperty(PropertyName = "numberOfPieces")]
        public int NumberOfPieces { get; set; }

        [JsonProperty(PropertyName = "byTime")]
        public int ByTime { get; set; }

        [JsonProperty(PropertyName = "control")]
        public string Control { get; set; }

        [JsonProperty(PropertyName = "treatment")]
        public string Treatment { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class EnrollmentModel
    {
        [JsonProperty(PropertyName = "enrollmentId")]
        public string EnrollmentId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "inputMethod")]
        public CommonIdValueModel InputMethod { get; set; }

        [JsonProperty(PropertyName = "distribution")]
        public CommonIdValueModel Distribution { get; set; }

        [JsonProperty(PropertyName = "sites")]
        public List<SitesModel> Sites { get; set; }

        [JsonProperty(PropertyName = "cardOrder")]
        public int CardOrder { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class SitesModel
    {
        [JsonProperty(PropertyName = "geography")]
        public CommonIdValueModel Geography { get; set; }

        [JsonProperty(PropertyName = "siteInititationTime")]
        public int SiteInititationTime { get; set; }

        [JsonProperty(PropertyName = "avgPatientsEnrolled")]
        public string AvgPatientsEnrolled { get; set; }

        [JsonProperty(PropertyName = "enrollmentCap")]
        public decimal EnrollmentCap { get; set; }

        [JsonProperty(PropertyName = "order")]
        public int Order { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class OperationalCostModel
    {
        [JsonProperty(PropertyName = "operationalCostID")]
        public string OperationalCostID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "costPerPatient")]
        public string CostPerPatient { get; set; }

        [JsonProperty(PropertyName = "fixedCost")]
        public string FixedCost { get; set; }

        [JsonProperty(PropertyName = "interimLookCost")]
        public string InterimLookCost { get; set; }

        [JsonProperty(PropertyName = "cardOrder")]
        public int CardOrder { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class MarketAccessModel
    {
        [JsonProperty(PropertyName = "marketAccessId")]
        public int MarketAccessId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "endpointId")]
        public string EndpointId { get; set; }

        [JsonProperty(PropertyName = "annualRevenueInPeakYear")]
        public string AnnualRevenueInPeakYear { get; set; }

        [JsonProperty(PropertyName = "timeToPeakAnnualRevenue")]
        public string TimeToPeakAnnualRevenue { get; set; }

        [JsonProperty(PropertyName = "proportionOfResidualSales")]
        public string ProportionOfResidualSales { get; set; }

        [JsonProperty(PropertyName = "anticipatedTreatmentEffect")]
        public string AnticipatedTreatmentEffect { get; set; }

        [JsonProperty(PropertyName = "timeToPatentExpiry")]
        public string TimeToPatentExpiry { get; set; }

        [JsonProperty(PropertyName = "discountRate")]
        public int DiscountRate { get; set; }

        [JsonProperty(PropertyName = "cardOrder")]
        public int CardOrder { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<ErrorModel> Error { get; set; }
    }

    public class DesignModel
    {
    }
}
