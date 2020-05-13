using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Models
{
    public class SimulationSettings
    {
        public string DBConnectionString { get; set; }
        public string QueueConnectionString { get; set; }
        public string JsonSchemaFilePath { get; set; }
        public string QueueName { get; set; }
    }
}
