using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Api.Test.TestData
{
    class Geographies
    {
        public static List<Geography> GeographyList = new List<Geography>
        {
           new Geography { ID = 1, Value = "USA"},
           new Geography { ID = 2, Value = "UK"},
           new Geography { ID = 3, Value = "Mexico"},
        };
    }
}