using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Api.Test.TestData
{
    public static class TimeUnits
    {
        public static List<ProjectTimeUnit> TimesUnitList = new List<ProjectTimeUnit>
        {
           new ProjectTimeUnit { ID = 1, Value = "Day" },
           new ProjectTimeUnit { ID = 2, Value = "Week" },
           new ProjectTimeUnit { ID = 3, Value = "Month" },
           new ProjectTimeUnit { ID = 4, Value = "Year" },

        };
    }
}