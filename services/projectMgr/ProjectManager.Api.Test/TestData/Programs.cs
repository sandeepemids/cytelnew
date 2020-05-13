using ProjectManager.Models;
using System.Collections.Generic;
using ProgramModel = ProjectManager.Models.Program;

namespace ProjectManager.Api.Test.TestData
{
    public static class Programs
    {
        public static List<ProgramModel> ProgramsList = new List<ProgramModel>
        {
           new ProgramModel { ID = 1, Name = "Oncology" },
           new ProgramModel { ID = 2, Name = "Adrenocortical Carcinoma" }
        };

        public static NewProgram NewProgram = new NewProgram
        {
            ProgramName = "Program 1",
            CreatedBy = "User 1",
            ResourceID = 1
        };

        public static ProgramModel CreatedProgram = new ProgramModel
        {
            ID = 1,
            Name = "Program 1",
            CreatedBy = "User 1",
            ResourceID = 1
        };
    }
}