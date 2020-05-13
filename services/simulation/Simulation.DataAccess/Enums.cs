using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.DataAccess
{
    public static class Enums
    {
        public enum SimulationState
        {
            Queued = 'Q',
            Processed = 'P',
            Error = 'E',
            Cancel = 'C'
        }
    }
}
