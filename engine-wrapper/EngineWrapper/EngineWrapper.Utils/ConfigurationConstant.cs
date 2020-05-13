
using Microsoft.Extensions.Configuration;
using System;

namespace EngineWrapper.Utils
{
    public static class ConfigurationConstant
    {
        public static int IntervalTime;
        public static string ComputQueueName;
        public static string OutputQueueName;
        public static string StorageAccountName;
        public static string StorageAccountKey;
        public static string DataLakeUri;
        public static string DataLakeDirectoryName;
        public static string FixedDesignStage = "FixedDesign";
        public static string GroupSeqStage = "Group Sequential";                        
        public static string OutputQueueStage = "OutputQueue";
        public static string InputQueueStage = "InputQueue";

        public const string FIXED_DESIGN_ENGIN_ENAME = "2-arm-timetoevent-fixeddesign";
        public const string GROUP_SEQ_ENGINE_NAME = "group sequential";

        public static void ReadConfiguration()
        {
            var config = new ConfigurationBuilder()
                   .AddJsonFile("config.json")
                   .Build();
            IntervalTime = Convert.ToInt32(config["IntervalTime"]);
            ComputQueueName = GetEnvVariableElseConfigVariable("ENGINE_QUEUE_NAME", config["ComputQueueName"]);
            OutputQueueName = GetEnvVariableElseConfigVariable("RESULT_QUEUE_NAME", config["OutputQueueName"]);
            StorageAccountName = GetEnvVariableElseConfigVariable("STORAGE_ACCOUNT_NAME", config["StorageAccountName"]);
            StorageAccountKey = GetEnvVariableElseConfigVariable("STORAGE_ACCOUNT_KEY", config["StorageAccountKey"]);
            DataLakeUri = config["DataLakeUri"];
            DataLakeDirectoryName = config["DataLakeDirectoryName"];
            
        }

        /// <summary>
        /// Get current time stamp.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentTime()
        {
            return DateTime.UtcNow.ToString("yyyyMMdd-hh:mm:ss.fff");
        }

        /// <summary>
        /// Read environment variables and set to constant. 
        /// </summary>
        /// <param name="envVar"></param>
        /// <param name="configVar"></param>
        /// <returns></returns>
        private static string GetEnvVariableElseConfigVariable(string envVar, string configVar)
        {
            var retStr = Environment.GetEnvironmentVariable(envVar);
            if (string.IsNullOrEmpty(retStr))
            {
                retStr = configVar;
            }
            return retStr;
        }
    }


    
}
