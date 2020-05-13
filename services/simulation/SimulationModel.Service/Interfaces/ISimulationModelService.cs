using Simulation.Models;
using Simulation.Models.StatisticalDesignModels;
using System;

namespace SimulationModel.Service.Interfaces
{
    public interface ISimulationModelService
    {
        int GetModelCount();

        void CreateProjectSimulation();

        void GenerateMultipleModels();

        void CreateSimulationModels();

        SimulationResponse SimulateModel(string statisticalEngineType, string jsonMessage);

        bool CreateSimulationQueue(string queueMessage);

        bool CreateSimulationData(string engineModel, Guid simulationModelId, int projectSimulationId, int resourceId);
    }
}
