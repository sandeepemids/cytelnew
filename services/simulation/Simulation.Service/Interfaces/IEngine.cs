using Simulation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Simulation.Service.Interfaces
{
    public interface IEngine
    {
        public List<string> EngineModels { get; }
    }
}
