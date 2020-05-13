using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EngineWrapper.Interface
{
    public interface IDataLakeOperations
    {
        /// <summary>
        /// Connect and upload the data as file to the Azure Data Lake. 
        /// </summary>
        /// <param name="storageAccountName">Azure storage account name</param>
        /// <param name="storageAccountKey">Azure storage account key</param>
        /// <param name="dataLakeUri">Azure Data Lake URI</param>
        /// <param name="directoryName">Azure Data Lake directory name</param>
        /// <param name="content">Upload data content</param>
        Task<bool> UploadData(string storageAccountName, string storageAccountKey, string dataLakeUri, string directoryName, string content);
    }
}
