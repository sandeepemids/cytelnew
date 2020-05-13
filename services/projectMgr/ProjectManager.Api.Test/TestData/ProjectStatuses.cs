using ProjectManager.Models;

namespace ProjectManager.Api.Test.TestData
{
    public class ProjectStatuses
    {
        public static ProjectStatus ProjStatus = new ProjectStatus
        {
            ProjectID = 1,
            StatusID = 1,
            CreatedBy = "User 1",
            ResourceID = 1

        };

        public static ProjectStatus InvalidProjStatus = new ProjectStatus
        {
            ProjectID = 0,
            StatusID = 1,
            CreatedBy = "User 1",
            ResourceID = 1

        };
    }
}
