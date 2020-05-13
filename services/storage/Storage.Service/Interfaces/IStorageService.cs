using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Service.Interfaces
{
    public interface IStorageService
    {        
        int GetModelCount();
        void CreateStorageModels();
        
    }
}
