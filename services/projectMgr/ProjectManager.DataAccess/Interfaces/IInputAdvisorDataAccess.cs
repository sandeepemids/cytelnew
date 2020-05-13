using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.DataAccess.Interfaces
{
    public interface IInputAdvisorDataAccess
    {
        IEnumerable<Geography> GetGeographies();
    }
}