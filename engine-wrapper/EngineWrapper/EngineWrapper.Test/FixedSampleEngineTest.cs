using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace EngineWrapper.Test
{
    public class FixedSampleEngineTest
    {
        [Fact]
        public void Send_Valid_Input_To_Engine()
        {
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            string summaryResult = FixedSampleEngine.ComputeOutput(message);
            Assert.True(!string.IsNullOrEmpty(summaryResult));
        }

        [Fact]
        public void Send_Invalid_Input_To_Engine()
        {
            string message = File.ReadAllText("./InputFiles/FixedSampleSummaryResult.json");
            string summaryResult = FixedSampleEngine.ComputeOutput(message);
            Assert.True(!string.IsNullOrEmpty(summaryResult));
        }
    }
}
