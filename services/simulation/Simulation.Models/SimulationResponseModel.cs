using System.Collections.Generic;

namespace Simulation.Models
{
    public class SimulationResponseModel
    {
        public long NoOfModels { get; set; }
        public int TimeInSeconds { get; set; }
        public List<IList<string>> ErrorMessages { get; set; }
    }
}
