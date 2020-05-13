using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Api.Test.TestData
{
    class Endpoints
    {
        public static List<Endpoint> EndpointList = new List<Endpoint>
        {
           new Endpoint { ID = 1, Name = "Overal Survival", Type = "Time to Event" },
           new Endpoint { ID = 2, Name = "Progression-Free Survival", Type = "Time to Event" },
           new Endpoint { ID = 3, Name = "Custom", Type = "Time to Event" },
        };
    }
}
