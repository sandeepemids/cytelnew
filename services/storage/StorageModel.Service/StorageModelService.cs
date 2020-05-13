using Microsoft.Extensions.Options;
using Storage.DataAccess.Interfaces;
using Storage.Models;
using StorageModel.Service.Interfaces;
using System;

namespace StorageModel.Service
{
    public class StorageModelService : IStorageModelService
    {
        private readonly IStorageDataAccess storageDataAccess;
        private readonly string queueConnectionString;

        public StorageModelService(IStorageDataAccess storageDataAccess,
                                      IOptions<StorageSettings> settings)
        {
            this.storageDataAccess = storageDataAccess;
            queueConnectionString = settings.Value.QueueConnectionString;
        }

        public void CreateStorageModels()
        {
            throw new NotImplementedException();
        }
    }
}
