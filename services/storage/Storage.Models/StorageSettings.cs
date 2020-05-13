using System;

namespace Storage.Models
{
    public class StorageSettings
    {
        public string DBConnectionString { get; set; }
        public string QueueConnectionString { get; set; }
    }
}
