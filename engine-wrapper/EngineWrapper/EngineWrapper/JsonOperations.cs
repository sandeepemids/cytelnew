using EngineWrapper.Logger;
using EngineWrapper.Utils;
using System;
using System.Text.Json;

namespace EngineWrapper
{
    public class JsonOperations
    {
        Logging logger;
        public JsonOperations()
        {
            logger = new Logging("JsonOperations");
        }

        /// <summary>
        /// Update input message json field
        /// </summary>
        /// <param name="inputMessage">input message string</param>
        /// <returns>Updated input message</returns>
        public string UpdateInputMessageJsonField(string inputMessage)
        {
            try
            {                
                Rootobject rootobject = JsonSerializer.Deserialize<Rootobject>(inputMessage);
                if (rootobject.computeInfo != null)
                {
                    foreach (var item in rootobject.computeInfo)
                    {
                        if (item.stage.Equals(ConfigurationConstant.InputQueueStage))
                            item.sentTime = ConfigurationConstant.GetCurrentTime();
                    }
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };                     
                   return JsonSerializer.Serialize(rootobject, options);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return string.Empty;
            }
        }

        /// <summary>
        /// Add compute info in the input message.
        /// </summary>
        /// <param name="inputMessage">input message</param>
        /// <returns>Updated output message</returns>
        public string AddEngineStageJsonField(string jsonMessage, string engineName)
        {
            try
            {                
                Rootobject rootobject = JsonSerializer.Deserialize<Rootobject>(jsonMessage);
                Computeinfo computeinfo = new Computeinfo() { stage = GetStageName(engineName), receviedTime = ConfigurationConstant.GetCurrentTime() };
                rootobject.computeInfo.Add(computeinfo);
                var options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    WriteIndented = true
                };
                return JsonSerializer.Serialize(rootobject, options);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return string.Empty;
            }
        }

        /// <summary>
        /// Update Engine stage timestamp in ComputeInfo in JSON. 
        /// </summary>
        /// <param name="inputMessage"></param>
        /// <returns></returns>
        public string UpdateEngineStageJsonField(string inputMessage, string engineName)
        {
            try
            {
                Rootobject rootobject = JsonSerializer.Deserialize<Rootobject>(inputMessage);
                if (rootobject.computeInfo != null)
                {
                    foreach (var item in rootobject.computeInfo)
                    {
                        if (item.stage.Equals(GetStageName(engineName)))
                            item.sentTime = ConfigurationConstant.GetCurrentTime();
                    }
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    return JsonSerializer.Serialize(rootobject , options);
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return string.Empty;
            }            
        }

        /// <summary>
        /// Add compute info in the input message.
        /// </summary>
        /// <param name="inputMessage">input message</param>
        /// <returns>Updated output message</returns>
        public string AddOutputMessageJsonField(string inputMessage)
        {
            try
            {
                Rootobject rootobject = JsonSerializer.Deserialize<Rootobject>(inputMessage);
                Computeinfo computeinfo = new Computeinfo() { stage = ConfigurationConstant.OutputQueueStage, receviedTime = ConfigurationConstant.GetCurrentTime() };
                rootobject.computeInfo.Add(computeinfo);
                var options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    WriteIndented = true
                };
                return JsonSerializer.Serialize<Rootobject>(rootobject, options);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return string.Empty;
            }
        }

        /// <summary>
        /// Add engine output summary in JSON message.
        /// </summary>
        /// <param name="inputMessage">queue message string</param>
        /// <param name="engineOutput">engine ouput string</param>
        /// <returns>Output message string</returns>
        public string AddEngineOutputSummary(string inputMessage, string engineOutput)
        {
            try
            {
                Rootobject inputMessageObj = JsonSerializer.Deserialize<Rootobject>(inputMessage);
                Rootobject engingOutputObj = JsonSerializer.Deserialize<Rootobject>(engineOutput);
                if (engingOutputObj.summaryResult != null)
                {
                    inputMessageObj.summaryResult = engingOutputObj.summaryResult;
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    return JsonSerializer.Serialize(inputMessageObj, options);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return string.Empty;
            }
        }

        /// <summary>
        /// Find the Engine Name from JSON message.
        /// </summary>
        /// <param name="inputMessage"></param>
        /// <returns>Engine Name</returns>
        public string FindEngineName(string inputMessage)
        {
            try
            {
                Rootobject rootobject = JsonSerializer.Deserialize<Rootobject>(inputMessage);
                return rootobject.target.name;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                return string.Empty;
            }            
        }

        private string GetStageName(string engineName)
        {
            string engineStageName = string.Empty;
            switch (engineName.ToLower())
            {
                case ConfigurationConstant.FIXED_DESIGN_ENGIN_ENAME:
                    engineStageName = ConfigurationConstant.FixedDesignStage;
                    break;
                case ConfigurationConstant.GROUP_SEQ_ENGINE_NAME:
                    engineStageName = ConfigurationConstant.GroupSeqStage;
                    break;                
            }
            
            return engineStageName;
        }
    }
}
