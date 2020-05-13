using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Api.Test.TestData
{
    public static class Statuses
    {
        public static List<Status> StatusList = new List<Status>
        {
           new Status { ID = 1, Value = "In Progress" },
           new Status { ID = 2, Value = "In Review" },
           new Status { ID = 3, Value = "Complete" },


        };
    }
}
