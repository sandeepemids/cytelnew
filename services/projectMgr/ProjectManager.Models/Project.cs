using System;

namespace ProjectManager.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Int16 Phase { get; set; }
        public string ProtocolID { get; set; }
        public int ResourceID { get; set; }
        public Program Program { get; set; }
        public Status Status { get; set; }
        public Indication Indication { get; set; }
        public ProjectTimeUnit ProjectTimeUnit { get; set; }
        public Currency Currency { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }

    }
}
