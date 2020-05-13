using Storage.DataAccess.Factory;
using Storage.DataAccess.Interfaces;
using System;

namespace Storage.DataAccess
{
    public class StorageDataAccess : IStorageDataAccess
    {
        private readonly IStorageDBManager StorageDBManager;

        public StorageDataAccess(string dbConnectionString)
        {
            StorageDBManager = new StorageDBManager(dbConnectionString);
        }

        public void CreateProjectStorage()
        {
            throw new NotImplementedException();
        }

        public void CreateStorageModelData()
        {
            throw new NotImplementedException();
        }

        public int GetModelCount()
        {
            throw new NotImplementedException();
        }
    }
}
