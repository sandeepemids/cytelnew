using Newtonsoft.Json.Linq;
using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Service.Interfaces
{
    public interface IProjectService
    {
        Project CreateProject(NewProject project);
        Program CreateProgram(NewProgram program);
        void GetProject();
        IEnumerable<Project> GetProjects(int resourceID);
        IEnumerable<Indication> GetIndications();
        IEnumerable<Currency> GetCurrencies();
        IEnumerable<ProjectTimeUnit> GetTimeUnits();
        IEnumerable<Program> GetPrograms(int resourceID);
        IEnumerable<Status> GetStatuses();
        IEnumerable<StatisticalEngines> GetStatisticalEngines();
        StatisticalEngineDetails GetStatisticalEngineDetails(string name, string version);
        bool IsProjectIDExists(int projectID);
        bool IsProjectNameExists(string projectName);
        bool IsProtocolIDExists(string protocolID);
        bool IsProgramNameExists(string programName, int resourceID);
        bool IsProjectExistsForResourceID(int resourceID);
        bool IsProjectIDExistsForResourceID(int projectID, int resourceID);
        void EditProject();
        void UpdateStatus(ProjectStatus projectStatus);
        JObject GetInputAdvisorInputs(int resourceID, int projectID);
        InputAdvisor CreateInputAdvisorInputs(InputAdvisor inputAdvisor);
        IEnumerable<Endpoint> GetEndpoints();
        void ValidateInputAdvisorJson(string pageID, JObject inputAdvisorJsonObject);
    }
}
