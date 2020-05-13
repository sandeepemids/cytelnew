using DataAugmentation.DataAccess;
using DataAugmentation.DataAccess.Interfaces;
using DataAugmentation.Models;
using DataAugmentation.Service.Interface;
using DataAugmentationModel.Service;
using DataAugmentationModel.Service.Interface;
using Microsoft.Extensions.Options;
using System;

namespace DataAugmentation.Service
{
    public class DataAugmentationService : IDataAugmentationService
    {
        private readonly IDataAugmentationDataAccess dataaugmentationDataAccess;
        private readonly IDataAugmentationModelService dataaugmentationModelService;

        public DataAugmentationService(IOptions<DataAugmentationSettings> settings)
        {
            dataaugmentationDataAccess = new DataAugmentationDataAccess(settings.Value.DBConnectionString);
            dataaugmentationModelService = new DataAugmentationModelService(dataaugmentationDataAccess, settings);
        }

        public void GenerateMultipleModels()
        {
            throw new NotImplementedException();
        }

        public void CreateProjectDataAugmentation()
        {
            dataaugmentationDataAccess.CreateDataAugmentation();
        }

        public int GetModelCount()
        {
            return dataaugmentationDataAccess.GetModelCount();
        }

        public void CreateDataAugmentationModels()
        {
            dataaugmentationModelService.CreateDataAugmentationModels();
        }
    }
}
