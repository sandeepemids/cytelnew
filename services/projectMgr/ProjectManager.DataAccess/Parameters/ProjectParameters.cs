using ProjectManager.DataAccess.Interfaces;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Data;

namespace ProjectManager.DataAccess.Parameters
{
    public class ProjectParameters
    {
        public static List<IDbDataParameter> GetCreateProjectParameters(IProjectDBManager projectDBManager, Project project)
        {
            List<IDbDataParameter> projectParameters = new List<IDbDataParameter>();
            projectParameters.Add(projectDBManager.CreateParameter("@project_name", project.Name, DbType.String));
            projectParameters.Add(projectDBManager.CreateParameter("@protocol_id", project.ProtocolID, DbType.String));
            projectParameters.Add(projectDBManager.CreateParameter("@program_id", project.Program.ID, DbType.Int32));
            projectParameters.Add(projectDBManager.CreateParameter("@indication_id", project.Indication.ID, DbType.Int16));
            projectParameters.Add(projectDBManager.CreateParameter("@phase_id", project.Phase, DbType.Int16));
            projectParameters.Add(projectDBManager.CreateParameter("@time_unit_id", project.ProjectTimeUnit.ID, DbType.Int16));
            projectParameters.Add(projectDBManager.CreateParameter("@currency_id", project.Currency.ID, DbType.Int16));
            projectParameters.Add(projectDBManager.CreateParameter("@resource_id", project.ResourceID, DbType.Int32));
            projectParameters.Add(projectDBManager.CreateParameter("@created_by", project.CreatedBy, DbType.String));
            projectParameters.Add(projectDBManager.CreateParameter("@project_id", 1, DbType.Int32));
            return projectParameters;
        }

        public static List<IDbDataParameter> GetProjectParameters(IProjectDBManager projectDBManager, int projectID, int resourceID, bool listAllProjects)
        {
            List<IDbDataParameter> projectParams = new List<IDbDataParameter>();
            projectParams.Add(projectDBManager.CreateParameter("@project_id", projectID, DbType.Int32));
            projectParams.Add(projectDBManager.CreateParameter("@resource_id", resourceID, DbType.Int32));
            projectParams.Add(projectDBManager.CreateParameter("@list_all_projects", listAllProjects, DbType.Boolean));
            return projectParams;
        }

        public static List<IDbDataParameter> GetProjectNameParameter(IProjectDBManager projectDBManager, string projectName)
        {
            List<IDbDataParameter> projectParams = new List<IDbDataParameter>();
            projectParams.Add(projectDBManager.CreateParameter("@project_name", projectName, DbType.String));
            return projectParams;
        }

        public static List<IDbDataParameter> GetProtocolIDParameter(IProjectDBManager projectDBManager, string protocolID)
        {
            List<IDbDataParameter> projectParams = new List<IDbDataParameter>();
            projectParams.Add(projectDBManager.CreateParameter("@protocol_id", protocolID, DbType.String));
            return projectParams;
        }

        public static List<IDbDataParameter> GetResourceIDParameter(IProjectDBManager projectDBManager, int resourceID)
        {
            List<IDbDataParameter> projectParams = new List<IDbDataParameter>();
            projectParams.Add(projectDBManager.CreateParameter("@resource_id", resourceID, DbType.Int32));
            return projectParams;
        }

        public static List<IDbDataParameter> GetProjectIDResourceIDParameter(IProjectDBManager projectDBManager, int projectID, int resourceID)
        {
            List<IDbDataParameter> projectParams = new List<IDbDataParameter>();
            projectParams.Add(projectDBManager.CreateParameter("@project_id", projectID, DbType.Int32));
            projectParams.Add(projectDBManager.CreateParameter("@resource_id", resourceID, DbType.Int32));
            return projectParams;
        }

        public static List<IDbDataParameter> GetProjectParameters(IProjectDBManager projectDBManager, string name, string version)
        {
            List<IDbDataParameter> projectParams = new List<IDbDataParameter>();
            projectParams.Add(projectDBManager.CreateParameter("@name", name, DbType.String));
            projectParams.Add(projectDBManager.CreateParameter("@version", version, DbType.String));
           return projectParams;
        }
    }
}
