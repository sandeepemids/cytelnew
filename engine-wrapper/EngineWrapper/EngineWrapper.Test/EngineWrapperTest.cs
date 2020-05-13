using System;
using Xunit;
using EngineWrapper;
using EngineWrapper.Utils;
using System.IO;

namespace EngineWrapper.Test
{
    public class EngineWrapperTest
    {

        public EngineWrapperTest()
        {
            ConfigurationConstant.ReadConfiguration();
        }

        [Fact]
        public void Read_Write_Message_UploadData_DataLake()
        {
            EngineWrapper engineWrapper = new EngineWrapper();
            bool result = engineWrapper.WrapperOperations();
            Assert.True(result);
        }

        [Fact]
        public void Engine_call_failed()
        {
            EngineWrapper engineWrapper = new EngineWrapper();
            bool result = engineWrapper.WrapperOperations();
            Assert.True(!result);
        }

        [Fact]
        public void Read_Empty_message_from_queue()
        {
            EngineWrapper engineWrapper = new EngineWrapper();
            bool result = engineWrapper.WrapperOperations();
            Assert.True(!result);
        }
    }
}
