using Simulation.Models;
using Simulation.Models.StatisticalDesignModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Simulation.DataAccess.Interfaces
{
    public interface ISimulationDataAccess
    {
        public int GetModelCount();
        public void CreateProjectSimulation();
        public void CreateSimulationPopulationData();
        public void CreateSimulationEnrollmentData();
        public void CreateSimulationModelData();
        bool CreateSimulationData(string engineModel, Guid simulationModelId, int projectSimulationId, int resourceId);
        DataTable GetProjectJsonObject(int projectId, int resourceId);
        DataTable GetStatisticalEngineDetails(int StatisticalEngineId);
        int CreateProjectSimulationData(int projectId, int resourceId, string createdBy);
        bool UpdateProjectSimulationModelCount(int projectSimulationId, int modelCount);
    }
}
