using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Models
{
    public class ProjectSimulation
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public Int16 Index { get; set; }

        public int ModelCount { get; set; }

        public int ProcessedModelCount { get; set; }

        public int ErrorModelCount { get; set; }

        public int CancelAfter { get; set; }

        public int ResourceID { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedTimestamp { get; set; }
    }
}
