using Newtonsoft.Json.Linq;
using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.DataAccess.Interfaces
{
    public interface IProjectDataAccess
    {
        int CreateProject(Project project);
        int CreateProgram(Program porgram);
        IEnumerable<Project> GetProjects(int resourceID, int projectID = 0, bool listAllProjects = true);
        IEnumerable<Indication> GetIndications();
        IEnumerable<Currency> GetCurrencies();
        IEnumerable<ProjectTimeUnit> GetTimeUnits();
        IEnumerable<Program> GetPrograms(int resourceID, int programID = 0, bool listAllPrograms = true);
        IEnumerable<Status> GetStatuses();
        IEnumerable<StatisticalEngines> GetStatisticalEngines();
        StatisticalEngineDetails GetStatisticalEngineDetails(string name, string version);
        void EditProject();
        void UpdateStatus(ProjectStatus projectStatus);
        bool IsProjectIDExists(int projectID);
        bool IsProjectNameExists(string projectName);
        bool IsProtocolIDExists(string protocolID);
        bool IsProgramNameExists(string protocolID, int resourceID);
        bool IsProjectExistsForResourceID(int resourceID);
        bool IsProjectIDExistsForResourceID(int projectID, int resourceID);
        JObject GetInputAdvisorInputs(int resourceID, int projectID);
        int CreateInputAdvisorInputs(InputAdvisor inputAdvisor);
        IEnumerable<InputAdvisor> GetInputAdvisorInputs(int inputAdvisorID);
        IEnumerable<Endpoint> GetEndpoints();
        bool IsStaticIdAndValueExist(int staticID, string staticValue, string staticModel);
    }
}
