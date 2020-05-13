using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.DataAccess.Interfaces
{
    public interface IStorageDataAccess
    {
        public int GetModelCount();

        public void CreateProjectStorage();

        public void CreateStorageModelData();
    }
}
