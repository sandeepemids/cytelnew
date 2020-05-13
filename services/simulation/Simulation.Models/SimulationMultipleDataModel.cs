using System.Collections.Generic;

namespace Simulation.Models
{
    public class SimulationMultipleDataModel
    {
        public List<EndpointMultipleData> EndpointMultipleData { get; set; }
        public List<EnrollmentMultipleData> EnrollmentMultipleData { get; set; }
    }

    public class EndpointMultipleData
    {
        public string[] PopulationEndpointControl { get; set; }
        public string[] PopulationEndpointHazardRatio { get; set; }
        public string[] PopulationDropoutRateControl { get; set; }
        public string[] PopulationDropoutRateTreatment { get; set; }
        public PopulationModel Population { get; set; }
        public PopulationEndpointModel Endpoint { get; set; }
    }

    public class EnrollmentMultipleData
    {
        public string[] EnrollmentGeography { get; set; }
        public string[] PatientEnrolledPerUnit { get; set; }
        public EnrollmentModel Enrollment { get; set; }
        public SitesModel Site { get; set; }
    }
}
