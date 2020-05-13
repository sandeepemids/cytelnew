using ProjectManager.DataAccess.Interfaces;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Data;

namespace ProjectManager.DataAccess.Parameters
{
    public class InputAdvisorParameters
    {
        public static List<IDbDataParameter> GetInputAdvisorParameters(IProjectDBManager projectDBManager, int resourceID, int projectID)
        {
            List<IDbDataParameter> inputAdvisorParams = new List<IDbDataParameter>();
            inputAdvisorParams.Add(projectDBManager.CreateParameter("@project_id", projectID, DbType.Int32));
            inputAdvisorParams.Add(projectDBManager.CreateParameter("@resource_id", resourceID, DbType.Int32));
            return inputAdvisorParams;
        }

        public static List<IDbDataParameter> GetInputAdvisorIDParameter(IProjectDBManager projectDBManager, int inputAdvisorID)
        {
            List<IDbDataParameter> inputAdvisorParams = new List<IDbDataParameter>();
            inputAdvisorParams.Add(projectDBManager.CreateParameter("@input_advisor_id", inputAdvisorID, DbType.Int32));
            return inputAdvisorParams;
        }

        public static List<IDbDataParameter> GetCreateInputAdvisorInputParameters(IProjectDBManager projectDBManager, InputAdvisor inputAdvisor)
        {
            List<IDbDataParameter> saveInputAdvisorInputParameters = new List<IDbDataParameter>();
            saveInputAdvisorInputParameters.Add(projectDBManager.CreateParameter("@project_id", inputAdvisor.ProjectID, DbType.Int32));
            saveInputAdvisorInputParameters.Add(projectDBManager.CreateParameter("@resource_id", inputAdvisor.ResourceID, DbType.Int32));
            saveInputAdvisorInputParameters.Add(projectDBManager.CreateParameter("@created_by", inputAdvisor.CreatedBy, DbType.String));
            saveInputAdvisorInputParameters.Add(projectDBManager.CreateParameter("@input_advisor_object", inputAdvisor.Object.ToString(), DbType.String));
            saveInputAdvisorInputParameters.Add(projectDBManager.CreateParameter("@input_advisor_id", 1, DbType.Int32));
            return saveInputAdvisorInputParameters;
        }

        public static List<IDbDataParameter> GetStaticIdAndValueParameters(IProjectDBManager projectDBManager, int staticID, string staticValue)
        {
            List<IDbDataParameter> staticIdAndValueParameters = new List<IDbDataParameter>();
            staticIdAndValueParameters.Add(projectDBManager.CreateParameter("@static_id", staticID, DbType.Int32));
            staticIdAndValueParameters.Add(projectDBManager.CreateParameter("@static_value", staticValue, DbType.String));
            return staticIdAndValueParameters;
        }
    }
}
