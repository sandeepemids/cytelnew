using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectManager.Constants;
using ProjectManager.DataAccess.Factory;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.DataAccess.Parameters;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjectManager.DataAccess
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        private readonly IProjectDBManager projectDBManager;
        public ProjectDataAccess(string connectionString)
        {
            projectDBManager = new ProjectDBManager(connectionString);
        }

        public IEnumerable<Project> GetProjects(int resourceID, int projectID = 0, bool listAllProjects = true)
        {
            try
            {
                var projectParam = ProjectParameters.GetProjectParameters(projectDBManager, projectID, resourceID, listAllProjects);
                DataTable dtProject = projectDBManager.GetDataTable("SELECT * FROM project.get_project_list(@project_id,@resource_id,@list_all_projects)", CommandType.Text, projectParam.ToArray());
                List<Project> projects = dtProject.AsEnumerable()
                                       .Select(x => new Project()
                                       {
                                           ID = x.Field<int>("projectid"),
                                           Name = x.Field<string>("projectname"),
                                           ProtocolID = x.Field<string>("protocolid"),
                                           Phase = x.Field<Int16>("phase"),
                                           CreatedBy = x.Field<string>("createdby"),
                                           ResourceID = x.Field<int>("resourceid"),
                                           Program = new Program
                                           {
                                               ID = x.Field<int>("programid"),
                                               Name = x.Field<string>("programname")
                                           },
                                           Status = new Status
                                           {
                                               ID = x.Field<Int16>("statusid"),
                                               Value = x.Field<string>("projectstatus")
                                           },
                                           Indication = new Indication
                                           {
                                               ID = x.Field<Int16>("indicationid"),
                                               Value = x.Field<string>("indicationname")
                                           },
                                           ProjectTimeUnit = new ProjectTimeUnit
                                           {
                                               ID = x.Field<Int16>("timeunitid"),
                                               Value = x.Field<string>("timeunit")
                                           },
                                           Currency = new Currency
                                           {
                                               ID = x.Field<Int16>("currencyid"),
                                               Value = x.Field<string>("currencyname")
                                           },
                                           LastModified = x.Field<DateTime>("modifiedtimestamp"),
                                           CreatedDate = x.Field<DateTime>("createdtimestamp"),
                                       }).ToList();
                return projects;
            }
            catch (Exception getProjectsException)
            {
                throw new Exception(ExceptionMessages.GET_PROJECTS_DATA_ACCESS_ERROR_MSG, getProjectsException);
            }
        }
        public IEnumerable<Indication> GetIndications()
        {
            try
            {
                DataTable dtIndication = projectDBManager.GetDataTable("SELECT * FROM project.get_indication_list()", CommandType.Text);
                List<Indication> indications = dtIndication.AsEnumerable()
                                      .Select(x => new Indication()
                                      {
                                          ID = x.Field<Int16>("id"),
                                          Value = x.Field<string>("value")
                                      }).ToList();
                return indications;
            }
            catch (Exception getIndicationsException)
            {
                throw new Exception(ExceptionMessages.GET_INDICATIONS_DATA_ACCESS_ERROR_MSG, getIndicationsException);
            }
        }
        public IEnumerable<Currency> GetCurrencies()
        {
            try
            {
                DataTable dtCurrency = projectDBManager.GetDataTable("SELECT * FROM project.get_currency_list()", CommandType.Text);
                List<Currency> currencies = dtCurrency.AsEnumerable()
                                      .Select(x => new Currency()
                                      {
                                          ID = x.Field<int>("id"),
                                          Value = x.Field<string>("value")
                                      }).ToList();
                return currencies;
            }
            catch (Exception getCurrenciesException)
            {
                throw new Exception(ExceptionMessages.GET_CURRENCIES_DATA_ACCESS_ERROR_MSG, getCurrenciesException);
            }
        }
        public IEnumerable<ProjectTimeUnit> GetTimeUnits()
        {
            try
            {
                DataTable dtProject = projectDBManager.GetDataTable("SELECT * FROM project.get_timeunit_list()", CommandType.Text);
                List<ProjectTimeUnit> projectTimeUnits = dtProject.AsEnumerable()
                                      .Select(x => new ProjectTimeUnit()
                                      {
                                          ID = x.Field<Int16>("id"),
                                          Value = x.Field<string>("value")
                                      }).ToList();
                return projectTimeUnits;
            }
            catch (Exception getTimeUnitsException)
            {
                throw new Exception(ExceptionMessages.GET_TIME_UNITS_DATA_ACCESS_ERROR_MSG, getTimeUnitsException);
            }
        }
        public IEnumerable<Program> GetPrograms(int resourceID, int programID = 0, bool listAllPrograms = true)
        {
            try
            {
                var parameters = ProgramParameters.GetProgramParameters(projectDBManager, programID, resourceID, listAllPrograms);
                DataTable dtProject = projectDBManager.GetDataTable("SELECT * FROM project.get_program_list(@program_id,@resource_id,@list_all_programs)", CommandType.Text, parameters.ToArray());
                List<Program> programs = dtProject.AsEnumerable()
                                      .Select(x => new Program()
                                      {
                                          ID = x.Field<int>("programid"),
                                          Name = x.Field<string>("programname"),
                                          CreatedBy = x.Field<string>("createdby"),
                                          ResourceID = x.Field<int>("resourceid")
                                      }).ToList();
                return programs;
            }
            catch (Exception getProgramsException)
            {
                throw new Exception(ExceptionMessages.GET_PROGRAMS_DATA_ACCESS_ERROR_MSG, getProgramsException);
            }
        }
        public IEnumerable<Status> GetStatuses()
        {
            try
            {
                DataTable dtStatuses = projectDBManager.GetDataTable("SELECT * FROM project.get_status_list()", CommandType.Text);
                List<Status> statuses = dtStatuses.AsEnumerable()
                                      .Select(x => new Status()
                                      {
                                          ID = x.Field<Int16>("id"),
                                          Value = x.Field<string>("value")
                                      }).ToList();
                return statuses;
            }
            catch (Exception getStatusesException)
            {
                throw new Exception(ExceptionMessages.GET_STATUSES_DATA_ACCESS_ERROR_MSG, getStatusesException);
            }
        }
        public bool IsProjectIDExists(int projectID)
        {
            try
            {
                var param = ProjectStatusParameters.GetProjectIDParam(projectDBManager, projectID);
                return Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_project_id_exists(@project_id)", CommandType.Text, param.ToArray()));
            }
            catch (Exception isProjectIDExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_ID_EXISTS_DATA_ACCESS_ERROR_MSG, isProjectIDExistsException);
            }

        }

        public bool IsProjectNameExists(string projectName)
        {
            try
            {
                var param = ProjectParameters.GetProjectNameParameter(projectDBManager, projectName);
                return Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_project_name_exists(@project_name)", CommandType.Text, param.ToArray()));
            }
            catch (Exception isProjectNameExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_NAME_EXISTS_DATA_ACCESS_ERROR_MSG, isProjectNameExistsException);
            }

        }

        public bool IsProtocolIDExists(string protocolID)
        {
            try
            {
                var param = ProjectParameters.GetProtocolIDParameter(projectDBManager, protocolID);
                return Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_protocol_id_exists(@protocol_id)", CommandType.Text, param.ToArray()));
            }
            catch (Exception isProtocolIDExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROTOCOL_ID_EXISTS_DATA_ACCESS_ERROR_MSG, isProtocolIDExistsException);
            }

        }

        public bool IsProgramNameExists(string programName, int resourceID)
        {
            try
            {
                var param = ProgramParameters.GetProgramNameParameter(projectDBManager, programName, resourceID);
                return Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_program_name_exists(@program_name, @resource_id)", CommandType.Text, param.ToArray()));
            }
            catch (Exception isProgramNameExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROGRAM_NAME_EXISTS_DATA_ACCESS_ERROR_MSG, isProgramNameExistsException);
            }
        }

        public bool IsProjectExistsForResourceID(int resourceID)
        {
            try
            {
                var param = ProjectParameters.GetResourceIDParameter(projectDBManager, resourceID);
                return Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_project_exists_for_resource_id(@resource_id)", CommandType.Text, param.ToArray()));
            }
            catch (Exception isProjectExistsForResourceIDException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_EXISTS_FOR_RESOURCE_ID_DATA_ACCESS_ERROR_MSG, isProjectExistsForResourceIDException);
            }
        }

        public void UpdateStatus(ProjectStatus projectStatus)
        {
            try
            {
                var parameters = ProjectStatusParameters.GetUpdateStatusParameters(projectDBManager, projectStatus);
                projectDBManager.Update("CALL project.update_project_status(@project_id,@status_id,@resource_id,@created_by)", CommandType.Text, parameters.ToArray());
            }
            catch (Exception updateStatusException)
            {
                throw new Exception(ExceptionMessages.UPDATE_STATUS_DATA_ACCESS_ERROR_MSG, updateStatusException);
            }
        }
        public int CreateProject(Project project)
        {

            try
            {
                int projectID = 0;
                var parameters = ProjectParameters.GetCreateProjectParameters(projectDBManager, project);
                projectDBManager.Insert("CALL project.create_project(@project_name,@protocol_id,@program_id,@indication_id,@phase_id,@time_unit_id,@currency_id,@resource_id,@created_by,@project_id)", CommandType.Text, parameters.ToArray(), out projectID);
                return projectID;
            }
            catch (Exception createProjectException)
            {
                throw new Exception(ExceptionMessages.CREATE_PROJECT_DATA_ACCESS_ERROR_MSG, createProjectException);
            }
        }
        public void EditProject()
        {
            throw new NotImplementedException();
        }
        public int CreateProgram(Program program)
        {
            try
            {
                int programID = 0;
                var parameters = ProgramParameters.GetCreateProgramParameters(projectDBManager, program);
                programID = projectDBManager.Insert("CALL project.create_program(@program_name,@created_by,@resource_id,@program_id)", CommandType.Text, parameters.ToArray(), out programID);
                return programID;
            }
            catch (Exception createProgramException)
            {
                throw new Exception(ExceptionMessages.CREATE_PROGRAM_DATA_ACCESS_ERROR_MSG, createProgramException);
            }
        }

        public int CreateInputAdvisorInputs(InputAdvisor inputAdvisor)
        {
            try
            {
                int inputAdvisorID = 0;
                var parameters = InputAdvisorParameters.GetCreateInputAdvisorInputParameters(projectDBManager, inputAdvisor);
                inputAdvisorID = projectDBManager.Insert("CALL project.create_input_advisor_inputs(@project_id,@resource_id,@created_by,@input_advisor_object,@input_advisor_id)",
                                         CommandType.Text, parameters.ToArray(), out inputAdvisorID);
                return inputAdvisorID;
            }
            catch (Exception createInputAdvisorInputsException)
            {
                throw new Exception(ExceptionMessages.CREATE_INPUT_ADVISOR_INPUTS_DATA_ACCESS_ERROR_MSG, createInputAdvisorInputsException);
            }
        }

        public JObject GetInputAdvisorInputs(int resourceID, int projectID)
        {
            try
            {
                var inputAdvisorParam = InputAdvisorParameters.GetInputAdvisorParameters(projectDBManager, resourceID, projectID);
                JObject jObject = JObject.Parse(projectDBManager.GetScalarValue("SELECT project.get_input_advisor_inputs(@project_id, @resource_id)", CommandType.Text, inputAdvisorParam.ToArray()).ToString());
                return jObject;
            }
            catch (Exception getInputAdvisorInputException)
            {
                throw new Exception(ExceptionMessages.GET_INPUT_ADVISOR_INPUTS_DATA_ACCESS_ERROR_MSG, getInputAdvisorInputException);
            }
        }

        public bool IsProjectIDExistsForResourceID(int projectID, int resourceID)
        {
            try
            {
                var param = ProjectParameters.GetProjectIDResourceIDParameter(projectDBManager, projectID, resourceID);
                return Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_project_id_exists_for_resource_id(@project_id, @resource_id)", CommandType.Text, param.ToArray()));
            }
            catch (Exception isProjectIDExistsForResourceIDException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_ID_EXISTS_FOR_RESOURCE_ID_DATA_ACCESS_ERROR_MSG, isProjectIDExistsForResourceIDException);
            }
        }

        public IEnumerable<InputAdvisor> GetInputAdvisorInputs(int inputAdvisorID)
        {
            try
            {
                var inputAdvisorParam = InputAdvisorParameters.GetInputAdvisorIDParameter(projectDBManager, inputAdvisorID);
                DataTable dtInputAdvisor = projectDBManager.GetDataTable("SELECT * FROM project.get_input_advisor_inputs_by_id(@input_advisor_id)", CommandType.Text, inputAdvisorParam.ToArray());
                List<InputAdvisor> inputAdvisorInputs = dtInputAdvisor.AsEnumerable()
                                       .Select(x => new InputAdvisor()
                                       {
                                           ProjectID = x.Field<int>("projectid"),
                                           ResourceID = x.Field<int>("resourceid"),
                                           Object = JObject.Parse(x.Field<string>("object")),
                                           CreatedBy = x.Field<string>("createdby")
                                       }).ToList();
                return inputAdvisorInputs;
            }
            catch (Exception getInputAdvisorInputException)
            {
                throw new Exception(ExceptionMessages.GET_INPUT_ADVISOR_INPUTS_BY_ID_DATA_ACCESS_ERROR_MSG, getInputAdvisorInputException);
            }
        }

        public IEnumerable<Endpoint> GetEndpoints()
        {
            try
            {
                DataTable dtEndpoint = projectDBManager.GetDataTable("SELECT id, name, type FROM project.get_endpoint_list()", CommandType.Text);
                List<Endpoint> endpoints = dtEndpoint.AsEnumerable()
                                      .Select(x => new Endpoint()
                                      {
                                          ID = x.Field<Int16>("id"),
                                          Name = x.Field<string>("name"),
                                          Type = x.Field<string>("type")
                                      }).ToList();
                return endpoints;
            }
            catch (Exception getEndpointsException)
            {
                throw new Exception(ExceptionMessages.GET_ENDPOINTS_DATA_ACCESS_ERROR_MSG, getEndpointsException);
            }
        }

        public IEnumerable<StatisticalEngines> GetStatisticalEngines()
        {
            try
            {
                DataTable dtStatEngines = projectDBManager.GetDataTable("SELECT name, version, releasedate FROM project.get_statisticalengine_list()", CommandType.Text);
                List<StatisticalEngines> statisticalEngines = dtStatEngines.AsEnumerable()
                                      .Select(x => new StatisticalEngines()
                                      {
                                          Name = x.Field<string>("name"),
                                          Version = x.Field<string>("version"),
                                          ReleaseDate = x.Field<DateTime?>("releasedate")
                                      }).ToList();
                return statisticalEngines;
            }
            catch (Exception getStatisticalEnginesException)
            {
                throw new Exception(ExceptionMessages.GET_STAT_ENGINES_DATA_ACCESS_ERROR_MSG, getStatisticalEnginesException);
            }
        }

        public StatisticalEngineDetails GetStatisticalEngineDetails(string name, string version)
        {
            try
            {
                var projectParam = ProjectParameters.GetProjectParameters(projectDBManager, name, version);
                DataTable dtStatEngineDetails = projectDBManager.GetDataTable("SELECT schema, template,uischema,defaultformdata FROM project.get_enginedetails(@name, @version)", CommandType.Text, projectParam.ToArray());

                var statisticalEngineDetails = new StatisticalEngineDetails();

                if (dtStatEngineDetails.Rows.Count > 0)
                {
                    DataRow row = dtStatEngineDetails.Rows[0];

                    statisticalEngineDetails.Schema = JsonConvert.DeserializeObject(row["Schema"].ToString());
                    statisticalEngineDetails.Template = JsonConvert.DeserializeObject(row["Template"].ToString());
                    statisticalEngineDetails.UiSchema = JsonConvert.DeserializeObject(row["UiSchema"].ToString());
                    statisticalEngineDetails.DefaultFormData = JsonConvert.DeserializeObject(row["DefaultFormData"].ToString());

                }

                return statisticalEngineDetails;
            }
            catch (Exception getStatisticalEngineDatailsException)
            {
                throw new Exception(ExceptionMessages.GET_STAT_ENGINE_DETAILS_DATA_ACCESS_ERROR_MSG, getStatisticalEngineDatailsException);
            }

        }

        public bool IsStaticIdAndValueExist(int staticID, string staticValue, string staticModel)
        {
            try
            {
                bool isValid = false;
                var param = InputAdvisorParameters.GetStaticIdAndValueParameters(projectDBManager, staticID, staticValue);
                switch (staticModel.ToLower())
                {
                    case "endpoint":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_endpoint_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    case "populationmodel":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_populationmodel_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    case "populationinputmethod":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_population_inputmethod_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    case "population_dropout_model":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_population_dropoutmodel_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    case "population_dropout_inputmethod":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_population_dropout_inputmethod_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    case "enrollment_inputmethod":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_enrollment_inputmethod_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    case "enrollment_distribution":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_enrollment_distribution_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    case "enrollment_sites_geography":
                        isValid = Convert.ToBoolean(projectDBManager.GetScalarValue("SELECT project.is_enrollment_geography_id_and_value_exists(@static_id, @static_value)", CommandType.Text, param.ToArray()));
                        break;
                    default:
                        break;
                }
                return isValid;
            }
            catch (Exception isStaticIdAndValueExistException)
            {
                throw new Exception(ExceptionMessages.IS_STATIC_ID_AND_VALUE_EXIST_EXCEPTION, isStaticIdAndValueExistException);
            }
        }
    }
}
