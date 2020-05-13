using DataAugmentation.DataAccess.Interfaces;
using DataAugmentation.Models;
using DataAugmentationModel.Service.Interface;
using Microsoft.Extensions.Options;
using System;

namespace DataAugmentationModel.Service
{
    public class DataAugmentationModelService: IDataAugmentationModelService
    {
        private readonly IDataAugmentationDataAccess dataaugmentationDataAccess;
        private readonly string queueConnectionString;

        public DataAugmentationModelService(IDataAugmentationDataAccess dataaugmentationDataAccess,
                                      IOptions<DataAugmentationSettings> settings)
        {
            this.dataaugmentationDataAccess = dataaugmentationDataAccess;
            queueConnectionString = settings.Value.QueueConnectionString;
        }

        public void CreateDataAugmentationModels()
        {
            throw new NotImplementedException();
        }
    }
}
