using Microsoft.Azure.Storage.Queue;
using System;
using System.Threading.Tasks;

namespace EngineWrapper.Interface
{
    public interface IQueueOperations
    {
        /// <summary>
        /// Read message from the Azure Storage Queue (Compute Queue)
        /// </summary>
        /// <param name="storageConnectionString">Azure Storage connection string</param>
        /// <param name="queueName">Azure Storage Queue Name</param>
        /// <returns></returns>
        Task<CloudQueueMessage> ReadMessage(string storageConnectionString, string queueName);

        /// <summary>
        /// Write message to the Azure Storage Queue (Output Queue)
        /// </summary>
        /// <param name="storageConnectionString">Azure Storage connection string</param>
        /// <param name="queueName">Azure Storage Queue Name</param>
        /// <param name="message">Write/Add message in the queue</param>
        /// <returns></returns>
        Task<bool> WriteMessage(string storageConnectionString, string queueName, string message);

        /// <summary>
        /// Delete message from queue.
        /// </summary>
        /// <param name="storageConnectionString">zure Storage connection string</param>
        /// <param name="queueName">Azure Storage Queue Name</param>
        /// <param name="cloudQueueMessage">Azure cloud queue message object</param>
        /// <returns></returns>
        Task<bool> DeleteMessage(string storageConnectionString, string queueName, CloudQueueMessage cloudQueueMessage);
    }
}
