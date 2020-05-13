using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationModel.Service
{
    public class SimulationResponse
    {
        public string QueueMessage { get; set; }

        public IList<string> ErrorMessages { get; set; }
    }
}
