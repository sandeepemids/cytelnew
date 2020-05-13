using Newtonsoft.Json;
using NpgsqlTypes;
using Simulation.DataAccess.Factory;
using Simulation.DataAccess.Interfaces;
using Simulation.Models.StatisticalDesignModels;
using System;
using System.Data;
using static Simulation.DataAccess.Enums;
using Simulation.SimulationConstants;

namespace Simulation.DataAccess
{
    public class SimulationDataAccess : ISimulationDataAccess
    {
        private readonly ISimulationDBManager simulationDBManager;

        public SimulationDataAccess(string dbConnectionString)
        {
            simulationDBManager = new SimulationDBManager(dbConnectionString);
        }

        public void CreateProjectSimulation()
        {
            throw new NotImplementedException();
        }

        public void CreateSimulationEnrollmentData()
        {
            throw new NotImplementedException();
        }

        public void CreateSimulationModelData()
        {
            throw new NotImplementedException();
        }

        public void CreateSimulationPopulationData()
        {
            throw new NotImplementedException();
        }

        public int GetModelCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create Simulation Data
        /// </summary>
        /// <param name="fixSampleScenario"></param>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public bool CreateSimulationData(string engineModel, Guid simulationModelId, int projectSimulationId, int resourceId)
        {
            try
            {
                IDbDataParameter[] parameter = new[] {
                simulationDBManager.CreateParameter("simulationmodelid", simulationModelId, NpgsqlDbType.Uuid),
                simulationDBManager.CreateParameter("projectsimulationid", projectSimulationId, NpgsqlDbType.Integer),
                simulationDBManager.CreateParameter("objectjson", engineModel, NpgsqlDbType.Json),
                simulationDBManager.CreateParameter("simulationstate", ((char)SimulationState.Queued).ToString(), NpgsqlDbType.Varchar),
                simulationDBManager.CreateParameter("resourceid", resourceId, NpgsqlDbType.Integer)
            };

                simulationDBManager.InsertWithTransaction("CALL simulation.insert_simulation_data(" +
                    "@simulationmodelid, @projectsimulationid, @objectjson, @simulationstate, @resourceid)",
                    CommandType.Text, parameter);
                return true;
            }
            catch(Exception createSimulationDataException)
            {
                throw new Exception(SimulationException.CREATE_SIMULATION_DATA_ERROR_MSG, createSimulationDataException);
            }
        }

        /// <summary>
        /// Get Project Json Object
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public DataTable GetProjectJsonObject(int projectId, int resourceId)
        {
            try
            {
                IDbDataParameter[] parameter = new[] {
                simulationDBManager.CreateParameter("projectid", projectId, NpgsqlDbType.Integer),
                simulationDBManager.CreateParameter("resourceid", resourceId, NpgsqlDbType.Integer)
                };
                return simulationDBManager.GetDataTable("SELECT object, name, numberofsim, simseed from project.get_project_json_object(@projectid, @resourceid)", CommandType.Text, parameter);
            }
            catch (Exception getProjectJsonObjectException)
            {
                throw new Exception(SimulationException.GET_PROJECT_JSON_OBJECT, getProjectJsonObjectException); 
            }
        }

        /// <summary>
        /// Get Statistical Engine Details
        /// </summary>
        /// <param name="StatisticalEngineId"></param>
        /// <returns></returns>
        public DataTable GetStatisticalEngineDetails(int statisticalEngineId)
        {
            try
            {
                IDbDataParameter[] parameter = new[] {
                simulationDBManager.CreateParameter("statisticalengineid", statisticalEngineId, NpgsqlDbType.Integer)
                };
                return simulationDBManager.GetDataTable("SELECT engineid, name, location, version, schemafilename from project.get_statistical_engine_details(@statisticalengineid)", CommandType.Text, parameter);
            }
            catch (Exception getStatisticalEngineDetailsException)
            {
                throw new Exception(SimulationException.GET_STATISTICAL_ENGINE_DETAILS_EXCEPTION, getStatisticalEngineDetailsException); 
            }
        }

        /// <summary>
        /// Create Project Simulation Data
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="resourceId"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public int CreateProjectSimulationData(int projectId, int resourceId, string createdBy)
        {
            try
            {
                int projectSimulationId;
                IDbDataParameter[] parameter = new[] {
                simulationDBManager.CreateParameter("projectid", projectId, NpgsqlDbType.Integer),
                simulationDBManager.CreateParameter("resourceid", resourceId, NpgsqlDbType.Integer),
                simulationDBManager.CreateParameter("createdBy", createdBy, NpgsqlDbType.Varchar),
                simulationDBManager.CreateParameter("projectsimulationid", 1, NpgsqlDbType.Integer),
            };

               simulationDBManager.Insert("CALL simulation.insert_project_simulation_data(" +
                    "@projectid, @resourceid, @createdby, @projectsimulationid)",
                    CommandType.Text, parameter, out projectSimulationId);
                return projectSimulationId;
            }
            catch (Exception createProjectSimulationDataException)
            {
                throw new Exception(SimulationException.CREATE_PROJECT_SIMULATION_DATA_ERROR_MSG, createProjectSimulationDataException);
            }
        }

        /// <summary>
        /// Update Project Simulation Model Count
        /// </summary>
        /// <param name="projectSimulationId"></param>
        /// <param name="modelCount"></param>
        /// <returns></returns>
        public bool UpdateProjectSimulationModelCount(int projectSimulationId, int modelCount)
        {
            try
            {
                IDbDataParameter[] parameter = new[] {
                simulationDBManager.CreateParameter("projectsimulationid", projectSimulationId, NpgsqlDbType.Integer),
                simulationDBManager.CreateParameter("modelcount", modelCount, NpgsqlDbType.Integer)
            };

                simulationDBManager.Update("CALL simulation.update_project_simulation_model_count(" +
                     "@projectsimulationid, @modelcount)",
                     CommandType.Text, parameter);
                return true;
            }
            catch (Exception updateProjectSimulationException)
            {
                throw new Exception(SimulationException.UPDATE_PROJECT_SIMULATION_MODEL_COUNT_ERROR_MSG, updateProjectSimulationException);
            }
        }
    }
}
