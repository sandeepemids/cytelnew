using EngineWrapper.Interface;
using EngineWrapper.Utils;
using System;
using System.IO;
using Xunit;

namespace EngineWrapper.DataLake.Test
{
    public class DataLakeOperationsTest
    {
        public DataLakeOperationsTest()
        {
            ConfigurationConstant.ReadConfiguration();
        }

        [Fact]
        public void UploadFileToDataLake()
        {
            IDataLakeOperations dataLakeOperations = new DataLakeOperations();
            string jsonMessage = File.ReadAllText("./InputFiles/FixedDesign_Simulation.json");
            bool result = dataLakeOperations.UploadData(ConfigurationConstant.StorageAccountName, ConfigurationConstant.StorageAccountKey, ConfigurationConstant.DataLakeUri, ConfigurationConstant.DataLakeDirectoryName, jsonMessage).Result;
            Assert.True(result);
        }

        [Fact]
        public void UploadFileNotToDataLake()
        {
            IDataLakeOperations dataLakeOperations = new DataLakeOperations();
            string jsonMessage = string.Empty;
            bool result = dataLakeOperations.UploadData(ConfigurationConstant.StorageAccountName, ConfigurationConstant.StorageAccountKey, ConfigurationConstant.DataLakeUri, ConfigurationConstant.DataLakeDirectoryName, jsonMessage).Result;
            Assert.True(!result);
        }
    }
}
