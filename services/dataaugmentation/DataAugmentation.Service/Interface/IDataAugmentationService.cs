using System;
using System.Collections.Generic;
using System.Text;

namespace DataAugmentation.Service.Interface
{
   public interface IDataAugmentationService
    {
        int GetModelCount();
        void CreateDataAugmentationModels();
    }
}
