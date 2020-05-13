using ProjectManager.DataAccess.Interfaces;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Data;

namespace ProjectManager.DataAccess.Parameters
{
    public class ProgramParameters
    {
        public static List<IDbDataParameter> GetCreateProgramParameters(IProjectDBManager projectDBManager, Program program)
        {
            List<IDbDataParameter> programParameters = new List<IDbDataParameter>();
            programParameters.Add(projectDBManager.CreateParameter("@program_name", program.Name, DbType.String));
            programParameters.Add(projectDBManager.CreateParameter("@created_by", program.CreatedBy, DbType.String));
            programParameters.Add(projectDBManager.CreateParameter("@resource_id", program.ResourceID, DbType.Int32));
            programParameters.Add(projectDBManager.CreateParameter("@program_id", 1, DbType.Int32));
            return programParameters;
        }
        public static List<IDbDataParameter> GetProgramParameters(IProjectDBManager projectDBManager, int programID, int resourceID, bool listAllPrograms)
        {
            List<IDbDataParameter> programParams = new List<IDbDataParameter>();
            programParams.Add(projectDBManager.CreateParameter("@program_id", programID, DbType.Int32));
            programParams.Add(projectDBManager.CreateParameter("@resource_id", resourceID, DbType.Int32));
            programParams.Add(projectDBManager.CreateParameter("@list_all_programs", listAllPrograms, DbType.Boolean));
            return programParams;
        }

        public static List<IDbDataParameter> GetProgramNameParameter(IProjectDBManager projectDBManager, string programName, int resourceID)
        {
            List<IDbDataParameter> programParams = new List<IDbDataParameter>();
            programParams.Add(projectDBManager.CreateParameter("@program_name", programName, DbType.String));
            programParams.Add(projectDBManager.CreateParameter("@resource_id", resourceID, DbType.Int32));
            return programParams;
        }
    }
}
