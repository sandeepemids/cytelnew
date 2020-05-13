using Microsoft.Extensions.Options;
using Storage.DataAccess;
using Storage.DataAccess.Interfaces;
using Storage.Models;
using Storage.Service.Interfaces;
using StorageModel.Service;
using StorageModel.Service.Interfaces;
using System;

namespace Storage.Service
{
    public class StorageService : IStorageService
    {
        private readonly IStorageDataAccess storageDataAccess;
        private readonly IStorageModelService storageModelService;

        public StorageService(IOptions<StorageSettings> settings)
        {
            storageDataAccess = new StorageDataAccess(settings.Value.DBConnectionString);
            storageModelService = new StorageModelService(storageDataAccess, settings);
        }

        public void GenerateMultipleModels()
        {
            throw new NotImplementedException();
        }

        public void CreateProjectStorage()
        {
            storageDataAccess.CreateProjectStorage();
        }

        public int GetModelCount()
        {
            return storageDataAccess.GetModelCount();
        }

        public void CreateStorageModels()
        {
            storageModelService.CreateStorageModels();
        }
    }
}
