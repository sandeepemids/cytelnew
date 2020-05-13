using Xunit;
using EngineWrapper.Utils;
using System.IO;

namespace EngineWrapper.Test
{
    public class JsonOperationsTest
    {

        public JsonOperationsTest()
        {
            ConfigurationConstant.ReadConfiguration();
        }

        [Fact]
        public void Invalid_JSON_Update_Message_With_TimeStamp()
        {
            string message = File.ReadAllText("./InputFiles/Invalid_FixedDesign_SimulationResults.json");
            JsonOperations jsonOperations = new JsonOperations();
            string updatedMessage = jsonOperations.UpdateInputMessageJsonField(message);
            Assert.True(string.IsNullOrEmpty(updatedMessage));
        }

        [Fact]
        public void Update_JSON_Message_With_TimeStamp()
        {
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            JsonOperations jsonOperations = new JsonOperations();
            string updatedMessage = jsonOperations.UpdateInputMessageJsonField(message);
            Assert.True(!string.IsNullOrEmpty(updatedMessage));
        }

        [Fact]
        public void Invalid_JSON_Add_Output_Message()
        {
            string message = File.ReadAllText("./InputFiles/Invalid_FixedDesign_SimulationResults.json");
            JsonOperations jsonOperations = new JsonOperations();
            string updatedMessage = jsonOperations.AddOutputMessageJsonField(message);
            Assert.True(string.IsNullOrEmpty(updatedMessage));
        }

        [Fact]
        public void Add_Output_Message_JSON_Field()
        {
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            JsonOperations jsonOperations = new JsonOperations();
            string updatedMessage = jsonOperations.AddOutputMessageJsonField(message);
            Assert.True(!string.IsNullOrEmpty(updatedMessage));
        }

        [Fact]
        public void Add_Output_Summary_JSON_Field()
        {
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            string engineOutput = File.ReadAllText("./InputFiles/FixedSampleSummaryResult.json");
            JsonOperations jsonOperations = new JsonOperations();
            string updatedMessage = jsonOperations.AddEngineOutputSummary(message, engineOutput);
            Assert.True(!string.IsNullOrEmpty(updatedMessage));
        }

     

        [Fact]
        public void Invalid_Add_Output_Summary_JSON_Field()
        {
            string message = File.ReadAllText("./InputFiles/Invalid_FixedDesign_SimulationResults.json");
            string engineOutput = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            JsonOperations jsonOperations = new JsonOperations();
            string updatedMessage = jsonOperations.AddEngineOutputSummary(message, engineOutput);
            Assert.True(string.IsNullOrEmpty(updatedMessage));
        }

        [Fact]
        public void Invalid_JSON_Find_Engine_Name()
        {
            string message = File.ReadAllText("./InputFiles/Invalid_FixedDesign_SimulationResults.json");
            JsonOperations jsonOperations = new JsonOperations();
            string engineName = jsonOperations.FindEngineName(message);
            Assert.True(string.IsNullOrEmpty(engineName));
        }

        [Fact]
        public void Find_Engine_Name_From_JSON()
        {
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            JsonOperations jsonOperations = new JsonOperations();
            string engineName = jsonOperations.FindEngineName(message);
            Assert.True(!string.IsNullOrEmpty(engineName));
        }

        [Fact]
        public void Invalid_JSON_Add_Engine_Stage_Field()
        {
            string message = File.ReadAllText("./InputFiles/Invalid_FixedDesign_SimulationResults.json");
            JsonOperations jsonOperations = new JsonOperations();
            string engineName = "2-arm-TimeToEvent-FixedDesign";
            string outputMessage = jsonOperations.AddEngineStageJsonField(message, engineName);
            Assert.True(string.IsNullOrEmpty(outputMessage));
        }

        [Fact]
        public void Add_Engine_Stage_Field_To_JSON()
        {
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            JsonOperations jsonOperations = new JsonOperations();
            string engineName = "2-arm-TimeToEvent-FixedDesign";
            string outputMessage = jsonOperations.AddEngineStageJsonField(message, engineName);
            Assert.True(!string.IsNullOrEmpty(outputMessage));
        }

        [Fact]
        public void Invalid_JSON_Update_Engine_Stage()
        {
            string message = File.ReadAllText("./InputFiles/Invalid_FixedDesign_SimulationResults.json");
            JsonOperations jsonOperations = new JsonOperations();
            string engineName = "2-arm-TimeToEvent-FixedDesign";
            string outputMessage = jsonOperations.UpdateEngineStageJsonField(message, engineName);
            Assert.True(string.IsNullOrEmpty(outputMessage));
        }

        [Fact]
        public void Update_Engine_Stage_To_JSON()
        {
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            JsonOperations jsonOperations = new JsonOperations();
            string engineName = "2-arm-TimeToEvent-FixedDesign";
            string outputMessage = jsonOperations.UpdateEngineStageJsonField(message, engineName);
            Assert.True(!string.IsNullOrEmpty(outputMessage));
        }
    }
}
