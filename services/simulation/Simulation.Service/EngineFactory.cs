using Simulation.Models;
using Simulation.Service.Interfaces;
using System;
using System.Data;
using Simulation.SimulationConstants;

namespace Simulation.Service
{
    public class EngineFactory
    {
        public IEngine CreateModels(DataTable inputAdvisor, DataTable statisticalEngine,
            string simulationReceivedTime, SimulationMultipleDataModel multipleModelData)
        {
            switch(statisticalEngine.Rows[0]["name"].ToString())
            {
                case Constants.FIXED_SAMPLE:
                    return new FixedSampleEngine(inputAdvisor, statisticalEngine, simulationReceivedTime, multipleModelData);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
