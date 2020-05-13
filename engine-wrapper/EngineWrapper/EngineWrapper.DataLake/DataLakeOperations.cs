using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Files.DataLake;
using EngineWrapper.Interface;
using EngineWrapper.Logger;

namespace EngineWrapper.DataLake
{
    public class DataLakeOperations : IDataLakeOperations
    {
        Logging logger;

        public DataLakeOperations()
        {
            logger = new Logging("DataLakeOperations");
        }

        /// <summary>
        /// Connect and upload the data as file to the Azure Data Lake. 
        /// </summary>
        /// <param name="storageAccountName">Azure storage account name</param>
        /// <param name="storageAccountKey">Azure storage account key</param>
        /// <param name="dataLakeUri">Azure Data Lake URI</param>
        /// <param name="directoryName">Azure Data Lake directory name</param>
        /// <param name="content">Upload data content</param>
        public async Task<bool> UploadData(string storageAccountName, string storageAccountKey, string dataLakeUri, string directoryName, string content)
        {
            try
            {
                Uri serviceUri = new Uri(dataLakeUri);

                StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);
                // Create DataLakeServiceClient using StorageSharedKeyCredentials
                DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);
                DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(directoryName);
                DataLakeDirectoryClient directoryClient =
                   filesystem.GetDirectoryClient(directoryName);
                DataLakeFileClient fileClient = await directoryClient.CreateFileAsync(string.Format("data-{0}.json", Guid.NewGuid().ToString()));
                using (MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(content)))
                {
                    await fileClient.AppendAsync(memoryStream, offset: 0);
                    await fileClient.FlushAsync(position: memoryStream.Length);
                }
                return true;
            }
            catch (Exception exception)
            {
                logger.Error(exception.StackTrace);
                return false;                
            }
            
        }
    }
}
