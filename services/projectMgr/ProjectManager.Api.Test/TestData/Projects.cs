using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Api.Test.TestData
{
    public static class Projects
    {
        public static List<Project> ProjectsList = new List<Project>
        {
          new Project
          {
              ID=1,
              Name="Oncology",
              Phase=1,
              ProtocolID="Oncology 1",
              Program=Programs.ProgramsList[0],
              Indication= Indications.IndicationsList[0],
              ProjectTimeUnit=TimeUnits.TimesUnitList[0],
              Currency= Currencies.CurrencyList[0],
              Status=Statuses.StatusList[0]
          },
          new Project
          {
              ID=2,
              Name="Oncology-2",
              Phase=1,
              ProtocolID="Oncology 2",
              Program=Programs.ProgramsList[1],
              Indication= Indications.IndicationsList[1],
              ProjectTimeUnit=TimeUnits.TimesUnitList[1],
              Currency= Currencies.CurrencyList[1],
              Status=Statuses.StatusList[1]
          }
        };

        public static Project CreatedProject = new Project
        {
            ID = 1,
            Name = "Oncology",
            Phase = 1,
            ProtocolID = "Oncology 1",
            Program = Programs.ProgramsList[0],
            Indication = Indications.IndicationsList[0],
            ProjectTimeUnit = TimeUnits.TimesUnitList[0],
            Currency = Currencies.CurrencyList[0],
            Status = Statuses.StatusList[0]
        };

        public static NewProject NewProject = new NewProject
        {
            ProjectName = "Oncology",
            ProtocolID = "Oncology 1",
            ProgramID = 1,
            IndicationID = 1,
            Phase = 1,
            CurrencyID = 1,
            TimeUnitID = 1,
            ResourceID = 1,
            CreatedBy = "User 1"
        };
    }
}
