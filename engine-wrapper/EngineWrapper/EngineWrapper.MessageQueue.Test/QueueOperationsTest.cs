using EngineWrapper.Interface;
using System;
using System.IO;
using Xunit;
using EngineWrapper.Utils;

namespace EngineWrapper.MessageQueue.Test
{
    public class QueueOperationsTest
    {
        string storageConnectionString = string.Empty;

        public QueueOperationsTest()
        {
            ConfigurationConstant.ReadConfiguration();
            storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", ConfigurationConstant.StorageAccountName,  ConfigurationConstant.StorageAccountKey);
        }

        [Fact]
        public void Read_Message_From_Compute_Queue()
        {
            string outputName = ConfigurationConstant.ComputQueueName;
            IQueueOperations queueOperations = new QueueOperations();    
            string queueMessage = Convert.ToString(queueOperations.ReadMessage(storageConnectionString, ConfigurationConstant.ComputQueueName).Result.AsString);
            Assert.True(!string.IsNullOrEmpty(queueMessage));
        }

        [Fact]
        public void Write_Message_To_Compute_Queue()
        {
            IQueueOperations queueOperations = new QueueOperations();
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            bool result = queueOperations.WriteMessage(storageConnectionString, ConfigurationConstant.ComputQueueName, message).Result;
            Assert.True(result);
        }

        [Fact]
        public void Is_Queue_Name_Exits()
        {
            IQueueOperations queueOperations = new QueueOperations();
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            bool result = queueOperations.WriteMessage(storageConnectionString, ConfigurationConstant.OutputQueueName, message).Result;
            Assert.True(result);
        }

        [Fact]
        public void Write_Big_Message_Length()
        {
            IQueueOperations queueOperations = new QueueOperations();
            string message = File.ReadAllText("./InputFiles/FixedDesign_Simulation_big.json");
            bool result = queueOperations.WriteMessage(storageConnectionString, ConfigurationConstant.OutputQueueName, message).Result;
            Assert.True(!result);
        }

        [Fact]
        public void Delete_Queue_Message()
        {
            IQueueOperations queueOperations = new QueueOperations();            
            bool result = queueOperations.DeleteMessage(storageConnectionString, ConfigurationConstant.ComputQueueName, queueOperations.ReadMessage(storageConnectionString, ConfigurationConstant.ComputQueueName).Result).Result;
            Assert.True(result);
        }
    }
}
