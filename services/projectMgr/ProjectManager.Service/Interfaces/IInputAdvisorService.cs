using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Service.Interfaces
{
    public interface IInputAdvisorService
    {
        IEnumerable<Geography> GetGeographies();
    }
}