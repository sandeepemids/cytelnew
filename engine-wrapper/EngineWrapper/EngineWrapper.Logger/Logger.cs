using Microsoft.Extensions.Logging;
using System;

namespace EngineWrapper.Logger
{
    public class Logging
    {
        private readonly ILogger logger;

        public Logging(string categoryName)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Cytel", LogLevel.Warning)
                    .AddFilter("application", LogLevel.Warning)
                    .AddFilter("EngineWrapper", LogLevel.Debug);
                                    
            });

            logger = loggerFactory.CreateLogger(categoryName);
        }

        public void Info(string log)
        {
            logger.LogInformation(log);
        }

        public void Debug(string log)
        {
            logger.LogDebug(log);
        }

        public void Error(string log)
        {
            logger.LogError(log);
        }

        public void Warn(string log)
        {
            logger.LogWarning(log);
        }
    }
}
