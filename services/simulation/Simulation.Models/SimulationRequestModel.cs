namespace Simulation.Models
{
    public class SimulationRequestModel
    {
        public int ProjectId { get; set; }

        public int StatisticalEngineId { get; set; }

        public int ResourceId { get; set; }

        public string CreatedBy { get; set; }
    }
}
