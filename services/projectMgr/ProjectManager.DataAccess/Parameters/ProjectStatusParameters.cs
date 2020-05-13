using ProjectManager.DataAccess.Interfaces;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Data;

namespace ProjectManager.DataAccess.Parameters
{
    public static class ProjectStatusParameters
    {
        public static List<IDbDataParameter> GetUpdateStatusParameters(IProjectDBManager projectDBManager, ProjectStatus projectStatus)
        {
            List<IDbDataParameter> statusParameters = new List<IDbDataParameter>();
            statusParameters.Add(projectDBManager.CreateParameter("@project_id", projectStatus.ProjectID, DbType.Int32));
            statusParameters.Add(projectDBManager.CreateParameter("@status_id", projectStatus.StatusID, DbType.Int16));
            statusParameters.Add(projectDBManager.CreateParameter("@resource_id", projectStatus.ResourceID, DbType.Int32));
            statusParameters.Add(projectDBManager.CreateParameter("@created_by", projectStatus.CreatedBy, DbType.String));
            return statusParameters;
        }

        public static List<IDbDataParameter> GetProjectIDParam(IProjectDBManager projectDBManager, int projectID)
        {
            List<IDbDataParameter> statusParameters = new List<IDbDataParameter>();
            statusParameters.Add(projectDBManager.CreateParameter("@project_id", projectID, DbType.Int32));
            return statusParameters;
        }
    }
}
