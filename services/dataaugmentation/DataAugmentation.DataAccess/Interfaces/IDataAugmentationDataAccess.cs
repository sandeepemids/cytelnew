using System;
using System.Collections.Generic;
using System.Text;

namespace DataAugmentation.DataAccess.Interfaces
{
   public interface IDataAugmentationDataAccess
    {

        public int GetModelCount();

        public void CreateDataAugmentation();

        public void CreateDataAugmentationModelData();
    }
}
