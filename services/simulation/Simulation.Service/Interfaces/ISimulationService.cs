using Simulation.Models;
using Simulation.Models.StatisticalDesignModels;
using System;
using System.Collections.Generic;
using System.Text;
using static Simulation.Service.SimulationService;

namespace Simulation.Service.Interfaces
{
    public interface ISimulationService
    {
        SimulationResponseModel Simulate(int projectId, int resourceId, int statisticalEngineId, string createdBy);
    }
}
