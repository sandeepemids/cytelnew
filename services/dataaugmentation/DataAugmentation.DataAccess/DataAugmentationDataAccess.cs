using DataAugmentation.DataAccess.Factory;
using DataAugmentation.DataAccess.Interfaces;
using System;

namespace DataAugmentation.DataAccess
{
    public class DataAugmentationDataAccess : IDataAugmentationDataAccess
    {
        private readonly IDataAugmentationDBManager DataAugmentationDBManager;

        public DataAugmentationDataAccess(string dbConnectionString)
        {
            DataAugmentationDBManager = new DataAugmentationDBManager(dbConnectionString);
        }
        public void CreateDataAugmentationModelData()
        {
            throw new NotImplementedException();
        }

        public void CreateDataAugmentation()
        {
            throw new NotImplementedException();
        }

        public int GetModelCount()
        {
            throw new NotImplementedException();
        }
    }
}
