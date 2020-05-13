using System;
using System.Collections.Generic;
using System.Text;

namespace DataAugmentation.Models
{
   public class DataAugmentationSettings
    {
        public string DBConnectionString { get; set; }
        public string QueueConnectionString { get; set; }
    }
}
