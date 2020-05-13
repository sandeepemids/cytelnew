using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ProjectManager.Constants;
using ProjectManager.DataAccess;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.IO;

namespace ProjectManager.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectDataAccess projectDataAccess;
        public ProjectService(IOptions<ProjectManagerSettings> settings)
        {
            projectDataAccess = new ProjectDataAccess(settings.Value.ConnectionString);
        }

        #region Create Methods
        /// <summary>
        /// Create Project service method for creating new project
        /// </summary>
        /// <param name="newProject"></param>
        /// <returns></returns>
        public Project CreateProject(NewProject newProject)
        {
            try
            {
                Project project = new Project
                {
                    Name = newProject.ProjectName.Trim(),
                    Phase = newProject.Phase,
                    ProtocolID = newProject.ProtocolID.Trim(),
                    ResourceID = newProject.ResourceID,
                    CreatedBy = newProject.CreatedBy.Trim(),
                    Program = new Program
                    {
                        ID = newProject.ProgramID
                    },
                    Indication = new Indication
                    {
                        ID = newProject.IndicationID
                    },
                    ProjectTimeUnit = new ProjectTimeUnit
                    {
                        ID = newProject.TimeUnitID
                    },
                    Currency = new Currency
                    {
                        ID = newProject.CurrencyID
                    }
                };

                //Creates new project
                int projectID = projectDataAccess.CreateProject(project);

                //Reads creatd Project
                IEnumerable<Project> projects = projectDataAccess.GetProjects(project.ResourceID, projectID, false);
                Project newCreatedProject = new Project();
                using (IEnumerator<Project> enumer = projects.GetEnumerator())
                {
                    if (enumer.MoveNext()) newCreatedProject = enumer.Current;
                }
                return newCreatedProject;
            }
            catch (Exception createProjectException)
            {
                throw new Exception(ExceptionMessages.CREATE_PROJECT_SERVICE_ERROR_MSG, createProjectException);
            }
        }

        /// <summary>
        ///  Create Program service method for creating new program
        /// </summary>
        /// <param name="newProgram"></param>
        /// <returns></returns>
        public Program CreateProgram(NewProgram newProgram)
        {
            try
            {
                Program program = new Program
                {
                    Name = newProgram.ProgramName.Trim(),
                    CreatedBy = newProgram.CreatedBy.Trim(),
                    ResourceID = newProgram.ResourceID
                };

                //Creates new program
                int programID = projectDataAccess.CreateProgram(program);

                //Reads created program
                IEnumerable<Program> createdProgram = projectDataAccess.GetPrograms(program.ResourceID, programID, false);
                Program currentProgram = new Program();
                using (IEnumerator<Program> enumer = createdProgram.GetEnumerator())
                {
                    if (enumer.MoveNext()) currentProgram = enumer.Current;
                }
                return currentProgram;
            }
            catch (Exception createProgramException)
            {
                throw new Exception(ExceptionMessages.CREATE_PROGRAM_SERVICE_ERROR_MSG, createProgramException);
            }
        }
        #endregion

        #region Get Methods
        public void GetProject()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// projects service method for listing all projects of a particular resource id
        /// </summary>
        /// <param name="resourceID"></param>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects(int resourceID)
        {
            try
            {
                return projectDataAccess.GetProjects(resourceID);
            }
            catch (Exception getProjectsException)
            {
                throw new Exception(ExceptionMessages.GET_PROJECTS_SERVICE_ERROR_MSG, getProjectsException);
            }
        }

        /// <summary>
        /// programs service method for listing all programs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Program> GetPrograms(int resourceID)
        {
            try
            {
                return projectDataAccess.GetPrograms(resourceID);
            }
            catch (Exception getProgramsException)
            {
                throw new Exception(ExceptionMessages.GET_PROGRAMS_SERVICE_ERROR_MSG, getProgramsException);
            }
        }

        /// <summary>
        ///indications service method for listing all indications
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Indication> GetIndications()
        {
            try
            {
                return projectDataAccess.GetIndications();
            }
            catch (Exception getIndicationsException)
            {
                throw new Exception(ExceptionMessages.GET_INDICATIONS_SERVICE_ERROR_MSG, getIndicationsException);
            }

        }

        /// <summary>
        /// currency service for listing all currencies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Currency> GetCurrencies()
        {
            try
            {
                return projectDataAccess.GetCurrencies();
            }
            catch (Exception getCurrenciesException)
            {
                throw new Exception(ExceptionMessages.GET_CURRENCIES_SERVICE_ERROR_MSG, getCurrenciesException);
            }
        }

        /// <summary>
        /// time units service method for listing all time units
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectTimeUnit> GetTimeUnits()
        {
            try
            {
                return projectDataAccess.GetTimeUnits();
            }
            catch (Exception getTimeUnitsException)
            {
                throw new Exception(ExceptionMessages.GET_TIME_UNITS_SERVICE_ERROR_MSG, getTimeUnitsException);
            }

        }

        /// <summary>
        /// statuses service method for listing all statuses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Status> GetStatuses()
        {
            try
            {
                return projectDataAccess.GetStatuses();
            }
            catch (Exception getStatusesException)
            {
                throw new Exception(ExceptionMessages.GET_STATUSES_SERVICE_ERROR_MSG, getStatusesException);
            }
        }

        public IEnumerable<StatisticalEngines> GetStatisticalEngines()
        {
            try
            {
                return projectDataAccess.GetStatisticalEngines();
            }
            catch (Exception getStatisticalEnginesException)
            {
                throw new Exception(ExceptionMessages.GET_STAT_ENGINES_SERVICE_ERROR_MSG, getStatisticalEnginesException);
            }
        }
        public StatisticalEngineDetails GetStatisticalEngineDetails(string name, string version)
        {
            try
            {
                return projectDataAccess.GetStatisticalEngineDetails(name, version);
            }
            catch (Exception getStatisticalEngineDatailsException)
            {
                throw new Exception(ExceptionMessages.GET_STAT_ENGINE_DETAILS_SERVICE_ERROR_MSG, getStatisticalEngineDatailsException);
            }
        }
        #endregion

        #region isExistsCheckMethods
        /// <summary>
        /// service method that checks project id exists or not
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public bool IsProjectIDExists(int projectID)
        {
            try
            {
                return projectDataAccess.IsProjectIDExists(projectID);
            }
            catch (Exception isProjectIDExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_ID_EXISTS_SERVICE_ERROR_MSG, isProjectIDExistsException);
            }
        }

        /// <summary>
        /// service method that checks project name exists or not
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public bool IsProjectNameExists(string projectName)
        {
            try
            {
                return projectDataAccess.IsProjectNameExists(projectName);
            }
            catch (Exception isProjectNameExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_NAME_EXISTS_SERVICE_ERROR_MSG, isProjectNameExistsException);
            }
        }

        /// <summary>
        /// service method that checks protocolID exists or not
        /// </summary>
        /// <param name="protocolID"></param>
        /// <returns></returns>
        public bool IsProtocolIDExists(string protocolID)
        {
            try
            {
                return projectDataAccess.IsProtocolIDExists(protocolID);
            }
            catch (Exception isProtocolIDExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROTOCOL_ID_EXISTS_SERVICE_ERROR_MSG, isProtocolIDExistsException);
            }
        }

        /// <summary>
        /// Service method that checks program name exists or not
        /// </summary>
        /// <param name="programName"></param>
        /// <returns></returns>
        public bool IsProgramNameExists(string programName, int resourceID)
        {
            try
            {
                return projectDataAccess.IsProgramNameExists(programName, resourceID);
            }
            catch (Exception isProgramNameExistsException)
            {
                throw new Exception(ExceptionMessages.IS_PROGRAM_NAME_EXISTS_SERVICE_ERROR_MSG, isProgramNameExistsException);
            }
        }

        /// <summary>
        /// Service method that check for any projects exists for resource id 
        /// </summary>
        /// <param name="programName"></param>
        /// <returns></returns>
        public bool IsProjectExistsForResourceID(int resourceID)
        {
            try
            {
                return projectDataAccess.IsProjectExistsForResourceID(resourceID);
            }
            catch (Exception isProjectExistsForResourceIDException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_EXISTS_FOR_RESOURCE_ID_SERVICE_ERROR_MSG, isProjectExistsForResourceIDException);
            }
        }

        /// <summary>
        /// Service method that check whether project ID exists for given resource ID or not
        /// </summary>
        /// <param name="projectID">Project ID</param>
        /// <param name="resourceID">Resource ID</param>
        /// <returns></returns>
        public bool IsProjectIDExistsForResourceID(int projectID, int resourceID)
        {
            try
            {
                return projectDataAccess.IsProjectIDExistsForResourceID(projectID, resourceID);
            }
            catch (Exception isProjectIDExistsForResourceIDException)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_ID_EXISTS_FOR_RESOURCE_ID_SERVICE_ERROR_MSG, isProjectIDExistsForResourceIDException);
            }
        }

        #endregion

        #region Update Methods
        /// <summary>
        /// Service method that updates project status
        /// </summary>
        /// <param name="projectStatus"></param>
        public void UpdateStatus(ProjectStatus projectStatus)
        {
            try
            {
                projectDataAccess.UpdateStatus(projectStatus);
            }
            catch (Exception updateStatusException)
            {
                throw new Exception(ExceptionMessages.UPDATE_STATUS_SERVICE_ERROR_MSG, updateStatusException);
            }
        }

        #endregion

        /// <summary>
        /// Creates Input Advisor Inputs record inside the InputAdvisor Table
        /// </summary>
        /// <param name="inputAdvisor">Input Advisor Inputs Object</param>
        /// <returns></returns>
        public InputAdvisor CreateInputAdvisorInputs(InputAdvisor inputAdvisor)
        {
            try
            {
                int inputAdvisorID = projectDataAccess.CreateInputAdvisorInputs(inputAdvisor);

                InputAdvisor createdInputAdvisorInputs = GetInputAdvisorInputs(inputAdvisorID);

                return createdInputAdvisorInputs;
            }
            catch (Exception createInputAdvisorInputsException)
            {
                throw new Exception(ExceptionMessages.CREATE_INPUT_ADVISOR_INPUTS_SERVICE_ERROR_MSG, createInputAdvisorInputsException);
            }
        }

        private InputAdvisor GetInputAdvisorInputs(int inputAdvisorID)
        {
            try
            {
                IEnumerable<InputAdvisor> inputAdvisorInputs = projectDataAccess.GetInputAdvisorInputs(inputAdvisorID);

                InputAdvisor inputAdvisorObject = new InputAdvisor();

                using (IEnumerator<InputAdvisor> enumer = inputAdvisorInputs.GetEnumerator())
                {
                    if (enumer.MoveNext()) inputAdvisorObject = enumer.Current;
                }

                return inputAdvisorObject;
            }
            catch (Exception getInputAdvisorInputsException)
            {
                throw new Exception(ExceptionMessages.GET_INPUT_ADVISOR_INPUTS_BY_ID_SERVICE_ERROR_MSG, getInputAdvisorInputsException);
            }
        }

        #region Update Methods

        public void EditProject()
        {
            throw new NotImplementedException();
        }

        #endregion
        /// <summary>
        ///Endpoints service method for listing all Endpoints
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Endpoint> GetEndpoints()
        {
            try
            {
                return projectDataAccess.GetEndpoints();
            }
            catch (Exception getEndpointsException)
            {
                throw new Exception(ExceptionMessages.GET_ENDPOINTS_SERVICE_ERROR_MSG, getEndpointsException);
            }
        }

        /// <summary>
        /// Retrieves Input Advisor Inputs for a given Project ID and Resource ID with latest Createdtimestamp. 
        /// If not exists, Default template from InputAdvisorSchema table will be written
        /// </summary>
        /// <param name="resourceID">Resource ID</param>
        /// <param name="projectID">Project ID</param>
        /// <returns></returns>
        public JObject GetInputAdvisorInputs(int resourceID, int projectID)
        {
            try
            {
                JObject jObject = projectDataAccess.GetInputAdvisorInputs(resourceID, projectID);

                return jObject;
            }
            catch (Exception getInputAdvisorInputsException)
            {
                throw new Exception(ExceptionMessages.GET_INPUT_ADVISOR_INPUTS_SERVICE_ERROR_MSG, getInputAdvisorInputsException);
            }
        }

        /// <summary>
        /// Validate input advisor json object
        /// </summary>
        /// <param name="inputAdvisorJsonObject">Input Advisor Json Object</param>
        /// <param name="pageID">Page Identifier from where Save is triggered</param>
        public void ValidateInputAdvisorJson(string pageID, JObject inputAdvisorJsonObject)
        {
            if (!inputAdvisorJsonObject.HasValues)
            {
                return;
            }

            switch (pageID.ToLower())
            {
                case InputAdvisorConstants.PAGE_OBJECTIVE:
                    ValidateObjectiveSchema(inputAdvisorJsonObject);
                    break;
                case InputAdvisorConstants.PAGE_POPULATION:
                    ValidatePopulationSchema(inputAdvisorJsonObject);
                    break;
                case InputAdvisorConstants.PAGE_ENROLLMENT:
                    ValidateEnrollmentSchema(inputAdvisorJsonObject);
                    break;
                case InputAdvisorConstants.PAGE_DESIGN:
                    ValidateDesignSchema(inputAdvisorJsonObject);
                    break;
                case InputAdvisorConstants.PAGE_OPERATIONAL_COST:
                    ValidateOperationalCostSchema(inputAdvisorJsonObject);
                    break;
                case InputAdvisorConstants.PAGE_MARKET_ACCESS:
                    ValidateMarketAccessSchema(inputAdvisorJsonObject);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Validate input advisor Objective Schema and update errors if any
        /// </summary>
        /// <param name="inputAdvisorJsonObject">Input Advisor Json Object</param>
        private void ValidateObjectiveSchema(JObject inputAdvisorJsonObject)
        {
            //// This is for temporary, will remove in future
            string schema = @"{
  '$schema': 'http://json-schema.org/draft-07/schema',
  '$id': 'http://example.com/example.json',
  'type': 'object',
  'title': 'The Root Schema',
  'description': 'The root schema comprises the entire JSON document.',
  'default': {},
  'additionalProperties': true,
  'required': [
    'populationName',
    'treatmentArm',
    'controlArm',
    'endpoint'
  ],
  'properties': {
    'populationName': {
      '$id': '#/properties/populationName',
      'type': 'string',
      'title': 'The Populationname Schema',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        'Name of the population'
      ]
    },
    'treatmentArm': {
      '$id': '#/properties/treatmentArm',
      'type': 'string',
      'title': 'The Treatmentarm Schema',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        'TArm'
      ]
    },
    'controlArm': {
      '$id': '#/properties/controlArm',
      'type': 'string',
      'title': 'The Controlarm Schema',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        'CArm'
      ]
    },
    'endpoint': {
      '$id': '#/properties/endpoint',
      'type': 'array',
      'title': 'The Endpoint Schema',
      'description': 'An explanation about the purpose of this instance.',
      'default': [],
      'examples': [
        [
          {
            'Type': 'Time to event',
            'error': [
              {
                'field': 'Name',
                'message': 'Error Message'
              }
            ],
            'cardOrder': 1.0,
            'Endpoint': 'Overall Survival',
            'id': 1.0,
            'Name': 'Name 1'
          }
        ]
      ],
      'additionalItems': true,
      'items': {
        '$id': '#/properties/endpoint/items',
        'type': 'object',
        'title': 'The Items Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'cardOrder': 1.0,
            'error': [
              {
                'field': 'Name',
                'message': 'Error Message'
              }
            ],
            'Endpoint': 'Overall Survival',
            'id': 1.0,
            'Name': 'Name 1',
            'Type': 'Time to event'
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'Name',
          'Endpoint',
          'Type',
          'cardOrder'
        ],
        'properties': {
          'id': {
            '$id': '#/properties/endpoint/items/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'Name': {
            '$id': '#/properties/endpoint/items/properties/Name',
            'type': 'string',
            'title': 'The Name Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Name 1'
            ]
          },
          'Endpoint': {
            '$id': '#/properties/endpoint/items/properties/Endpoint',
            'type': 'string',
            'title': 'The Endpoint Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Overall Survival'
            ]
          },
          'Type': {
            '$id': '#/properties/endpoint/items/properties/Type',
            'type': 'string',
            'title': 'The Type Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Time to event'
            ]
          },
          'cardOrder': {
            '$id': '#/properties/endpoint/items/properties/cardOrder',
            'type': 'integer',
            'title': 'The Cardorder Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'error': {
            '$id': '#/properties/endpoint/items/properties/error',
            'type': 'array',
            'title': 'The Error Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': [],
            'examples': [
              [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ]
            ],
            'additionalItems': true,
            'items': {
              '$id': '#/properties/endpoint/items/properties/error/items',
              'type': 'object',
              'title': 'The Items Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': {},
              'examples': [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ],
              'additionalProperties': true,
              'required': [
                'field',
                'message'
              ],
              'properties': {
                'field': {
                  '$id': '#/properties/endpoint/items/properties/error/items/properties/field',
                  'type': 'string',
                  'title': 'The Field Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': '',
                  'examples': [
                    'Name'
                  ]
                },
                'message': {
                  '$id': '#/properties/endpoint/items/properties/error/items/properties/message',
                  'type': 'string',
                  'title': 'The Message Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': '',
                  'examples': [
                    'Error Message'
                  ]
                }
              }
            }
          }
        }
      }
    },
    'error': {
      '$id': '#/properties/error',
      'type': 'array',
      'title': 'The Error Schema',
      'description': 'An explanation about the purpose of this instance.',
      'default': [],
      'examples': [
        [
          {
            'message': 'Error Message',
            'field': 'Name'
          }
        ]
      ],
      'additionalItems': true,
      'items': {
        '$id': '#/properties/error/items',
        'type': 'object',
        'title': 'The Items Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'field': 'Name',
            'message': 'Error Message'
          }
        ],
        'additionalProperties': true,
        'required': [
          'field',
          'message'
        ],
        'properties': {
          'field': {
            '$id': '#/properties/error/items/properties/field',
            'type': 'string',
            'title': 'The Field Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Name'
            ]
          },
          'message': {
            '$id': '#/properties/error/items/properties/message',
            'type': 'string',
            'title': 'The Message Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Error Message'
            ]
          }
        }
      }
    }
  }
}";

            bool isValidObjective = true;
            string objectiveJsonStr = inputAdvisorJsonObject["objective"].ToString();
            
            JObject objectiveJsonToReturn = JObject.Parse(objectiveJsonStr);
            if (!objectiveJsonToReturn.HasValues)
            {
                return;
            }
            JArray endpointArrayToReturn = (JArray)objectiveJsonToReturn["endpoint"];
            JArray objectiveErrorArrayToReturn = (JArray)objectiveJsonToReturn["error"];

            //// Following commented code will be using in future
            //string schemaPath = Path.GetFullPath(@"..\ProjectManager.Service\InputAdvisorSchema\ObjectiveSchema.json");
            //JSchema objectiveSchema = JSchema.Parse(File.ReadAllText(schemaPath));
            JSchema objectiveSchema = JSchema.Parse(schema);

            IList<ValidationError> validationErrors;
            bool isValid = objectiveJsonToReturn.IsValid(objectiveSchema, out validationErrors);
            isValidObjective = !isValid ? isValid : isValidObjective;

            objectiveErrorArrayToReturn.Clear();

            var objectiveErrors = from v in validationErrors where !v.Path.Contains("endpoint") select new { v.Path, v.Message };
            
            foreach (var error in objectiveErrors)
            {
                objectiveErrorArrayToReturn.Add(ErrorWriter(error.Path, error.Message));
            }

            int endpointCount = 0;
            foreach (var endpoint in endpointArrayToReturn)
            {
                JObject endpointJsonObjectReturn = (JObject)endpoint;
                JArray endpointErrorArray = (JArray)endpointJsonObjectReturn["error"];
                endpointErrorArray.Clear();

                var endpointErrors = from v in validationErrors
                                     where v.Path.Contains("endpoint[" + endpointCount + "]")
                                     select new { v.Path, v.Message };

                foreach (var error in endpointErrors)
                {
                    endpointErrorArray.Add(ErrorWriter(error.Path, error.Message));
                }

                int endpointID = (int)endpointJsonObjectReturn["id"];
                string endpointValue = endpointJsonObjectReturn["Endpoint"].ToString();
                bool isValidEndpoint = ValidateStaticIdAndValue(endpointID, endpointValue, "endpoint");
                if (!isValidEndpoint)
                {
                    isValidObjective = false;
                    endpointErrorArray.Add(ErrorWriter("Endpoint", InputAdvisorConstants.JSON_INVALID_ENDPOINT_OR_ID));
                }

                endpointCount++;
            }

            inputAdvisorJsonObject.Property("validated").Value = isValidObjective;
            inputAdvisorJsonObject.Property("objective").Value = objectiveJsonToReturn;
        }

        private void ValidatePopulationSchema(JObject inputAdvisorJsonObject)
        {
            //// This is for temporary, will remove in future
            string schema = @"{
  '$schema': 'http://json-schema.org/draft-07/schema',
  '$id': 'http://example.com/example.json',
  'type': 'array',
  'title': 'The Root Schema',
  'description': 'The root schema comprises the entire JSON document.',
  'default': [],
  'additionalItems': true,
  'items': {
    '$id': '#/items',
    'type': 'object',
    'title': 'The Items Schema',
    'description': 'An explanation about the purpose of this instance.',
    'default': {},
    'examples': [
      {
        'populationId': 1.0,
        'virtualPopulationSize': 10000.0,
        'name': 'Population Name',
        'dropoutRateModel': {
          'inputMethod': {
            'id': 1.0,
            'value': 'Probability of Dropout'
          },
          'error': [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ],
          'byTime': 10.0,
          'control': '0.035',
          'treatment': '0.017',
          'model': {
            'value': 'Exponential',
            'id': 1.0
          },
          'numberOfPieces': 1.0
        },
        'cardOrder': 1.0,
        'endpointModel': [
          {
            'control': '0.035, 0.045',
            'treatment': '0.017',
            'hazardRatio': '0.486',
            'model': {
              'value': 'Exponential',
              'id': 1.0
            },
            'endpointId': 1.0,
            'numberOfPieces': 1.0,
            'inputMethod': {
              'value': 'Median Event Time',
              'id': 1.0
            },
            'error': [
              {
                'field': 'Name',
                'message': 'Error Message'
              }
            ]
          }
        ],
        'error': [
          {
            'field': 'Name',
            'message': 'Error Message'
          }
        ]
      }
    ],
    'additionalProperties': true,
    'required': [
      'populationId',
      'name',
      'virtualPopulationSize',
      'endpointModel',
      'dropoutRateModel',
      'cardOrder'
    ],
    'properties': {
      'populationId': {
        '$id': '#/items/properties/populationId',
        'type': 'integer',
        'title': 'The Populationid Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'name': {
        '$id': '#/items/properties/name',
        'type': 'string',
        'title': 'The Name Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          'Population Name'
        ]
      },
      'virtualPopulationSize': {
        '$id': '#/items/properties/virtualPopulationSize',
        'type': 'integer',
        'title': 'The Virtualpopulationsize Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          10000.0
        ]
      },
      'endpointModel': {
        '$id': '#/items/properties/endpointModel',
        'type': 'array',
        'title': 'The Endpointmodel Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': [],
        'examples': [
          [
            {
              'control': '0.035, 0.045',
              'treatment': '0.017',
              'model': {
                'value': 'Exponential',
                'id': 1.0
              },
              'hazardRatio': '0.486',
              'endpointId': 1.0,
              'numberOfPieces': 1.0,
              'inputMethod': {
                'id': 1.0,
                'value': 'Median Event Time'
              },
              'error': [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ]
            }
          ]
        ],
        'additionalItems': true,
        'items': {
          '$id': '#/items/properties/endpointModel/items',
          'type': 'object',
          'title': 'The Items Schema',
          'description': 'An explanation about the purpose of this instance.',
          'default': {},
          'examples': [
            {
              'treatment': '0.017',
              'model': {
                'value': 'Exponential',
                'id': 1.0
              },
              'hazardRatio': '0.486',
              'endpointId': 1.0,
              'numberOfPieces': 1.0,
              'inputMethod': {
                'id': 1.0,
                'value': 'Median Event Time'
              },
              'error': [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ],
              'control': '0.035, 0.045'
            }
          ],
          'additionalProperties': true,
          'required': [
            'endpointId',
            'model',
            'inputMethod',
            'numberOfPieces',
            'control',
            'treatment',
            'hazardRatio'
          ],
          'properties': {
            'endpointId': {
              '$id': '#/items/properties/endpointModel/items/properties/endpointId',
              'type': 'integer',
              'title': 'The Endpointid Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': 0,
              'examples': [
                1.0
              ]
            },
            'model': {
              '$id': '#/items/properties/endpointModel/items/properties/model',
              'type': 'object',
              'title': 'The Model Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': {},
              'examples': [
                {
                  'value': 'Exponential',
                  'id': 1.0
                }
              ],
              'additionalProperties': true,
              'required': [
                'id',
                'value'
              ],
              'properties': {
                'id': {
                  '$id': '#/items/properties/endpointModel/items/properties/model/properties/id',
                  'type': 'integer',
                  'title': 'The Id Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': 0,
                  'examples': [
                    1.0
                  ]
                },
                'value': {
                  '$id': '#/items/properties/endpointModel/items/properties/model/properties/value',
                  'type': 'string',
                  'title': 'The Value Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': '',
                  'examples': [
                    'Exponential'
                  ]
                }
              }
            },
            'inputMethod': {
              '$id': '#/items/properties/endpointModel/items/properties/inputMethod',
              'type': 'object',
              'title': 'The Inputmethod Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': {},
              'examples': [
                {
                  'id': 1.0,
                  'value': 'Median Event Time'
                }
              ],
              'additionalProperties': true,
              'required': [
                'id',
                'value'
              ],
              'properties': {
                'id': {
                  '$id': '#/items/properties/endpointModel/items/properties/inputMethod/properties/id',
                  'type': 'integer',
                  'title': 'The Id Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': 0,
                  'examples': [
                    1.0
                  ]
                },
                'value': {
                  '$id': '#/items/properties/endpointModel/items/properties/inputMethod/properties/value',
                  'type': 'string',
                  'title': 'The Value Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': '',
                  'examples': [
                    'Median Event Time'
                  ]
                }
              }
            },
            'numberOfPieces': {
              '$id': '#/items/properties/endpointModel/items/properties/numberOfPieces',
              'type': 'integer',
              'title': 'The Numberofpieces Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': 0,
              'examples': [
                1.0
              ]
            },
            'control': {
              '$id': '#/items/properties/endpointModel/items/properties/control',
              'type': 'string',
              'title': 'The Control Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                '0.035, 0.045'
              ]
            },
            'treatment': {
              '$id': '#/items/properties/endpointModel/items/properties/treatment',
              'type': 'string',
              'title': 'The Treatment Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                '0.017'
              ]
            },
            'hazardRatio': {
              '$id': '#/items/properties/endpointModel/items/properties/hazardRatio',
              'type': 'string',
              'title': 'The Hazardratio Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                '0.486'
              ]
            },
            'error': {
              '$id': '#/items/properties/endpointModel/items/properties/error',
              'type': 'array',
              'title': 'The Error Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': [],
              'examples': [
                [
                  {
                    'field': 'Name',
                    'message': 'Error Message'
                  }
                ]
              ],
              'additionalItems': true,
              'items': {
                '$id': '#/items/properties/endpointModel/items/properties/error/items',
                'type': 'object',
                'title': 'The Items Schema',
                'description': 'An explanation about the purpose of this instance.',
                'default': {},
                'examples': [
                  {
                    'field': 'Name',
                    'message': 'Error Message'
                  }
                ],
                'additionalProperties': true,
                'required': [
                  'field',
                  'message'
                ],
                'properties': {
                  'field': {
                    '$id': '#/items/properties/endpointModel/items/properties/error/items/properties/field',
                    'type': 'string',
                    'title': 'The Field Schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                      'Name'
                    ]
                  },
                  'message': {
                    '$id': '#/items/properties/endpointModel/items/properties/error/items/properties/message',
                    'type': 'string',
                    'title': 'The Message Schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                      'Error Message'
                    ]
                  }
                }
              }
            }
          }
        }
      },
      'dropoutRateModel': {
        '$id': '#/items/properties/dropoutRateModel',
        'type': 'object',
        'title': 'The Dropoutratemodel Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'control': '0.035',
            'treatment': '0.017',
            'model': {
              'id': 1.0,
              'value': 'Exponential'
            },
            'numberOfPieces': 1.0,
            'inputMethod': {
              'id': 1.0,
              'value': 'Probability of Dropout'
            },
            'byTime': 10.0,
            'error': [
              {
                'message': 'Error Message',
                'field': 'Name'
              }
            ]
          }
        ],
        'additionalProperties': true,
        'required': [
          'model',
          'inputMethod',
          'numberOfPieces',
          'byTime',
          'control',
          'treatment'
        ],
        'properties': {
          'model': {
            '$id': '#/items/properties/dropoutRateModel/properties/model',
            'type': 'object',
            'title': 'The Model Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': {},
            'examples': [
              {
                'id': 1.0,
                'value': 'Exponential'
              }
            ],
            'additionalProperties': true,
            'required': [
              'id',
              'value'
            ],
            'properties': {
              'id': {
                '$id': '#/items/properties/dropoutRateModel/properties/model/properties/id',
                'type': 'integer',
                'title': 'The Id Schema',
                'description': 'An explanation about the purpose of this instance.',
                'default': 0,
                'examples': [
                  1.0
                ]
              },
              'value': {
                '$id': '#/items/properties/dropoutRateModel/properties/model/properties/value',
                'type': 'string',
                'title': 'The Value Schema',
                'description': 'An explanation about the purpose of this instance.',
                'default': '',
                'examples': [
                  'Exponential'
                ]
              }
            }
          },
          'inputMethod': {
            '$id': '#/items/properties/dropoutRateModel/properties/inputMethod',
            'type': 'object',
            'title': 'The Inputmethod Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': {},
            'examples': [
              {
                'value': 'Probability of Dropout',
                'id': 1.0
              }
            ],
            'additionalProperties': true,
            'required': [
              'id',
              'value'
            ],
            'properties': {
              'id': {
                '$id': '#/items/properties/dropoutRateModel/properties/inputMethod/properties/id',
                'type': 'integer',
                'title': 'The Id Schema',
                'description': 'An explanation about the purpose of this instance.',
                'default': 0,
                'examples': [
                  1.0
                ]
              },
              'value': {
                '$id': '#/items/properties/dropoutRateModel/properties/inputMethod/properties/value',
                'type': 'string',
                'title': 'The Value Schema',
                'description': 'An explanation about the purpose of this instance.',
                'default': '',
                'examples': [
                  'Probability of Dropout'
                ]
              }
            }
          },
          'numberOfPieces': {
            '$id': '#/items/properties/dropoutRateModel/properties/numberOfPieces',
            'type': 'integer',
            'title': 'The Numberofpieces Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'byTime': {
            '$id': '#/items/properties/dropoutRateModel/properties/byTime',
            'type': 'integer',
            'title': 'The Bytime Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              10.0
            ]
          },
          'control': {
            '$id': '#/items/properties/dropoutRateModel/properties/control',
            'type': 'string',
            'title': 'The Control Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              '0.035'
            ]
          },
          'treatment': {
            '$id': '#/items/properties/dropoutRateModel/properties/treatment',
            'type': 'string',
            'title': 'The Treatment Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              '0.017'
            ]
          },
          'error': {
            '$id': '#/items/properties/dropoutRateModel/properties/error',
            'type': 'array',
            'title': 'The Error Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': [],
            'examples': [
              [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ]
            ],
            'additionalItems': true,
            'items': {
              '$id': '#/items/properties/dropoutRateModel/properties/error/items',
              'type': 'object',
              'title': 'The Items Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': {},
              'examples': [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ],
              'additionalProperties': true,
              'required': [
                'field',
                'message'
              ],
              'properties': {
                'field': {
                  '$id': '#/items/properties/dropoutRateModel/properties/error/items/properties/field',
                  'type': 'string',
                  'title': 'The Field Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': '',
                  'examples': [
                    'Name'
                  ]
                },
                'message': {
                  '$id': '#/items/properties/dropoutRateModel/properties/error/items/properties/message',
                  'type': 'string',
                  'title': 'The Message Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': '',
                  'examples': [
                    'Error Message'
                  ]
                }
              }
            }
          }
        }
      },
      'cardOrder': {
        '$id': '#/items/properties/cardOrder',
        'type': 'integer',
        'title': 'The Cardorder Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'error': {
        '$id': '#/items/properties/error',
        'type': 'array',
        'title': 'The Error Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': [],
        'examples': [
          [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ]
        ],
        'additionalItems': true,
        'items': {
          '$id': '#/items/properties/error/items',
          'type': 'object',
          'title': 'The Items Schema',
          'description': 'An explanation about the purpose of this instance.',
          'default': {},
          'examples': [
            {
              'message': 'Error Message',
              'field': 'Name'
            }
          ],
          'additionalProperties': true,
          'required': [
            'field',
            'message'
          ],
          'properties': {
            'field': {
              '$id': '#/items/properties/error/items/properties/field',
              'type': 'string',
              'title': 'The Field Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Name'
              ]
            },
            'message': {
              '$id': '#/items/properties/error/items/properties/message',
              'type': 'string',
              'title': 'The Message Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Error Message'
              ]
            }
          }
        }
      }
    }
  }
}";

            bool isValidPopulation = true;
            string populationJsonStr = inputAdvisorJsonObject["population"].ToString();

            JArray populationJsonArrayToReturn = JArray.Parse(populationJsonStr);
            if (!populationJsonArrayToReturn.HasValues)
            {
                return;
            }

            //// Following commented code will be using in future
            //string schemaPath = Path.GetFullPath(@"..\ProjectManager.Service\InputAdvisorSchema\PopulationSchema.json");
            //JSchema populationSchema = JSchema.Parse(File.ReadAllText(schemaPath));
            JSchema populationSchema = JSchema.Parse(schema);

            IList<ValidationError> validationErrors;
            bool isValid = populationJsonArrayToReturn.IsValid(populationSchema, out validationErrors);
            isValidPopulation = !isValid ? isValid : isValidPopulation;

            //// Updating errors to the json
            int populationCount = 0;
            foreach (var item in populationJsonArrayToReturn)
            {
                JObject populationJsonObjectReturn = (JObject)item;
                JArray populationErrorArrayReturn = (JArray)populationJsonObjectReturn["error"];
                populationErrorArrayReturn.Clear();

                var populationErrors = from v in validationErrors 
                                        where !v.Path.Contains("endpointModel") && !v.Path.Contains("dropoutRateModel") 
                                            && v.Path.Contains("["+ populationCount + "]")
                                        select new { v.Path, v.Message };

                foreach (var error in populationErrors)
                {
                    populationErrorArrayReturn.Add(ErrorWriter(error.Path, error.Message));
                }

                //// Updating endpointModel errors
                JArray endpointModelArrayReturn = (JArray)populationJsonObjectReturn["endpointModel"];

                int enpointModelCount = 0;
                foreach (var endpoint in endpointModelArrayReturn)
                {
                    JObject endpointModelJsonObjectReturn = (JObject)endpoint;
                    JArray endpointModelErrorArray = (JArray)endpointModelJsonObjectReturn["error"];
                    endpointModelErrorArray.Clear();

                    var endpointModelErrors = from v in validationErrors
                                              where v.Path.Contains("["+ populationCount + "]."+"endpointModel[" + enpointModelCount + "]")
                                              select new { v.Path, v.Message };

                    foreach (var error in endpointModelErrors)
                    {
                        endpointModelErrorArray.Add(ErrorWriter(error.Path, error.Message));
                    }

                    //// Id validation endpointModel: model
                    int populationModelID = (int)endpointModelJsonObjectReturn["model"]["id"];
                    string populationModelValue = endpointModelJsonObjectReturn["model"]["value"].ToString();
                    bool isValidPopulationModel = ValidateStaticIdAndValue(populationModelID, populationModelValue, "populationmodel");
                    if (!isValidPopulationModel)
                    {
                        isValidPopulation = false;
                        endpointModelErrorArray.Add(ErrorWriter("model", InputAdvisorConstants.JSON_INVALID_ID_OR_VALUE));
                    }

                    //// Validate InputMethod Id and value
                    int inputMethodID = (int)endpointModelJsonObjectReturn["inputMethod"]["id"];
                    string inputMethodValue = endpointModelJsonObjectReturn["inputMethod"]["value"].ToString();
                    bool isValidInputMethod = ValidateStaticIdAndValue(inputMethodID, inputMethodValue, "populationinputmethod");
                    if (!isValidInputMethod)
                    {
                        isValidPopulation = false;
                        endpointModelErrorArray.Add(ErrorWriter("inputMethod", InputAdvisorConstants.JSON_INVALID_ID_OR_VALUE));
                    }

                    enpointModelCount++;
                }

                //// Updating dropoutRateModel errors
                JObject dropoutRateModelReturn = (JObject)populationJsonObjectReturn["dropoutRateModel"];
                JArray dropoutRateModelErrorArray = (JArray)dropoutRateModelReturn["error"];
                dropoutRateModelErrorArray.Clear();

                var dropoutRateModelErrors = from v in validationErrors
                                          where v.Path.Contains("[" + populationCount + "]." + "dropoutRateModel")
                                          select new { v.Path, v.Message };

                foreach (var error in dropoutRateModelErrors)
                {
                    dropoutRateModelErrorArray.Add(ErrorWriter(error.Path, error.Message));
                }

                //// Id validation dropoutRateModel: model, inputMethod
                int dropoutModelID = (int)dropoutRateModelReturn["model"]["id"];
                string dropoutModelValue = dropoutRateModelReturn["model"]["value"].ToString();
                bool isValidDropoutModelD = ValidateStaticIdAndValue(dropoutModelID, dropoutModelValue, "population_dropout_model");
                if (!isValidDropoutModelD)
                {
                    isValidPopulation = false;
                    dropoutRateModelErrorArray.Add(ErrorWriter("model", InputAdvisorConstants.JSON_INVALID_ID_OR_VALUE));
                }

                //// Id validation dropoutRateModel: inputMethod
                int dropoutInputMethodID = (int)dropoutRateModelReturn["inputMethod"]["id"];
                string dropoutInputMethodValue = dropoutRateModelReturn["inputMethod"]["value"].ToString();
                bool isValidDropoutInputMethod = ValidateStaticIdAndValue(dropoutInputMethodID, dropoutInputMethodValue, "population_dropout_inputmethod");
                if (!isValidDropoutInputMethod)
                {
                    isValidPopulation = false;
                    dropoutRateModelErrorArray.Add(ErrorWriter("inputMethod", InputAdvisorConstants.JSON_INVALID_ID_OR_VALUE));
                }

                populationCount++;
            }

            inputAdvisorJsonObject.Property("validated").Value = isValidPopulation;
            inputAdvisorJsonObject.Property("population").Value = populationJsonArrayToReturn;
        }

        private void ValidateEnrollmentSchema(JObject inputAdvisorJsonObject)
        {
            //// This is for temporary, will remove in future
            string schema = @"{
  '$schema': 'http://json-schema.org/draft-07/schema',
  '$id': 'http://example.com/example.json',
  'type': 'array',
  'title': 'The Root Schema',
  'description': 'The root schema comprises the entire JSON document.',
  'default': [],
  'additionalItems': true,
  'items': {
    '$id': '#/items',
    'type': 'object',
    'title': 'The Items Schema',
    'description': 'An explanation about the purpose of this instance.',
    'default': {},
    'examples': [
      {
        'inputMethod': {
          'value': 'Accrual Rate',
          'id': 1.0
        },
        'error': [
          {
            'field': 'Name',
            'message': 'Error Message'
          }
        ],
        'cardOrder': 1.0,
        'distribution': {
          'value': 'Uniform',
          'id': 1.0
        },
        'enrollmentId': 1.0,
        'name': 'Enrollment Name 1',
        'sites': [
          {
            'avgPatientsEnrolled': 20.0,
            'order': 1.0,
            'error': [
              {
                'field': 'Name',
                'message': 'Error Message'
              }
            ],
            'siteInititationTime': 0.0,
            'enrollmentCap': 33.33,
            'geography': {
              'id': 1.0,
              'value': 'USA'
            }
          }
        ]
      }
    ],
    'additionalProperties': true,
    'required': [
      'enrollmentId',
      'name',
      'inputMethod',
      'distribution',
      'sites',
      'cardOrder'
    ],
    'properties': {
      'enrollmentId': {
        '$id': '#/items/properties/enrollmentId',
        'type': 'integer',
        'title': 'The Enrollmentid Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'name': {
        '$id': '#/items/properties/name',
        'type': 'string',
        'title': 'The Name Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          'Enrollment Name 1'
        ]
      },
      'inputMethod': {
        '$id': '#/items/properties/inputMethod',
        'type': 'object',
        'title': 'The Inputmethod Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'value': 'Accrual Rate',
            'id': 1.0
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/inputMethod/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/inputMethod/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Accrual Rate'
            ]
          }
        }
      },
      'distribution': {
        '$id': '#/items/properties/distribution',
        'type': 'object',
        'title': 'The Distribution Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'value': 'Uniform',
            'id': 1.0
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/distribution/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/distribution/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Uniform'
            ]
          }
        }
      },
      'sites': {
        '$id': '#/items/properties/sites',
        'type': 'array',
        'title': 'The Sites Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': [],
        'examples': [
          [
            {
              'avgPatientsEnrolled': 20.0,
              'order': 1.0,
              'error': [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ],
              'enrollmentCap': 33.33,
              'siteInititationTime': 0.0,
              'geography': {
                'id': 1.0,
                'value': 'USA'
              }
            }
          ]
        ],
        'additionalItems': true,
        'items': {
          '$id': '#/items/properties/sites/items',
          'type': 'object',
          'title': 'The Items Schema',
          'description': 'An explanation about the purpose of this instance.',
          'default': {},
          'examples': [
            {
              'error': [
                {
                  'field': 'Name',
                  'message': 'Error Message'
                }
              ],
              'siteInititationTime': 0.0,
              'enrollmentCap': 33.33,
              'geography': {
                'value': 'USA',
                'id': 1.0
              },
              'avgPatientsEnrolled': 20.0,
              'order': 1.0
            }
          ],
          'additionalProperties': true,
          'required': [
            'geography',
            'siteInititationTime',
            'avgPatientsEnrolled',
            'enrollmentCap',
            'order'
          ],
          'properties': {
            'geography': {
              '$id': '#/items/properties/sites/items/properties/geography',
              'type': 'object',
              'title': 'The Geography Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': {},
              'examples': [
                {
                  'id': 1.0,
                  'value': 'USA'
                }
              ],
              'additionalProperties': true,
              'required': [
                'id',
                'value'
              ],
              'properties': {
                'id': {
                  '$id': '#/items/properties/sites/items/properties/geography/properties/id',
                  'type': 'integer',
                  'title': 'The Id Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': 0,
                  'examples': [
                    1.0
                  ]
                },
                'value': {
                  '$id': '#/items/properties/sites/items/properties/geography/properties/value',
                  'type': 'string',
                  'title': 'The Value Schema',
                  'description': 'An explanation about the purpose of this instance.',
                  'default': '',
                  'examples': [
                    'USA'
                  ]
                }
              }
            },
            'siteInititationTime': {
              '$id': '#/items/properties/sites/items/properties/siteInititationTime',
              'type': 'integer',
              'title': 'The Siteinititationtime Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': 0,
              'examples': [
                0.0
              ]
            },
            'avgPatientsEnrolled': {
              '$id': '#/items/properties/sites/items/properties/avgPatientsEnrolled',
              'type': 'integer',
              'title': 'The Avgpatientsenrolled Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': 0,
              'examples': [
                20.0
              ]
            },
            'enrollmentCap': {
              '$id': '#/items/properties/sites/items/properties/enrollmentCap',
              'type': 'number',
              'title': 'The Enrollmentcap Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': 0,
              'examples': [
                33.33
              ]
            },
            'order': {
              '$id': '#/items/properties/sites/items/properties/order',
              'type': 'integer',
              'title': 'The Order Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': 0,
              'examples': [
                1.0
              ]
            },
            'error': {
              '$id': '#/items/properties/sites/items/properties/error',
              'type': 'array',
              'title': 'The Error Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': [],
              'examples': [
                [
                  {
                    'field': 'Name',
                    'message': 'Error Message'
                  }
                ]
              ],
              'additionalItems': true,
              'items': {
                '$id': '#/items/properties/sites/items/properties/error/items',
                'type': 'object',
                'title': 'The Items Schema',
                'description': 'An explanation about the purpose of this instance.',
                'default': {},
                'examples': [
                  {
                    'message': 'Error Message',
                    'field': 'Name'
                  }
                ],
                'additionalProperties': true,
                'required': [
                  'field',
                  'message'
                ],
                'properties': {
                  'field': {
                    '$id': '#/items/properties/sites/items/properties/error/items/properties/field',
                    'type': 'string',
                    'title': 'The Field Schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                      'Name'
                    ]
                  },
                  'message': {
                    '$id': '#/items/properties/sites/items/properties/error/items/properties/message',
                    'type': 'string',
                    'title': 'The Message Schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                      'Error Message'
                    ]
                  }
                }
              }
            }
          }
        }
      },
      'cardOrder': {
        '$id': '#/items/properties/cardOrder',
        'type': 'integer',
        'title': 'The Cardorder Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'error': {
        '$id': '#/items/properties/error',
        'type': 'array',
        'title': 'The Error Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': [],
        'examples': [
          [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ]
        ],
        'additionalItems': true,
        'items': {
          '$id': '#/items/properties/error/items',
          'type': 'object',
          'title': 'The Items Schema',
          'description': 'An explanation about the purpose of this instance.',
          'default': {},
          'examples': [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ],
          'additionalProperties': true,
          'required': [
            'field',
            'message'
          ],
          'properties': {
            'field': {
              '$id': '#/items/properties/error/items/properties/field',
              'type': 'string',
              'title': 'The Field Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Name'
              ]
            },
            'message': {
              '$id': '#/items/properties/error/items/properties/message',
              'type': 'string',
              'title': 'The Message Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Error Message'
              ]
            }
          }
        }
      }
    }
  }
}";

            bool isValidEnrollment = true;
            string enrollmentJsonStr = inputAdvisorJsonObject["enrollment"].ToString();

            JArray enrollmentJsonArrayToReturn = JArray.Parse(enrollmentJsonStr);
            if (!enrollmentJsonArrayToReturn.HasValues)
            {
                return;
            }

            //// Following commented code will be using in future. GetFullPath won't work while deploy.
            //string schemaPath = Path.GetFullPath(@"..\ProjectManager.Service\InputAdvisorSchema\EnrollmentSchema.json");
            //JSchema enrollmentSchema = JSchema.Parse(File.ReadAllText(schemaPath));
            JSchema enrollmentSchema = JSchema.Parse(schema);

            IList<ValidationError> validationErrors;
            bool isValid = enrollmentJsonArrayToReturn.IsValid(enrollmentSchema, out validationErrors);

            isValidEnrollment = !isValid ? isValid : isValidEnrollment;

            //// Validate and Update errors to the json
            int enrollmentCount = 0;
            foreach (var enrollment in enrollmentJsonArrayToReturn)
            {
                JObject enrollmentModelJsonObjectReturn = (JObject)enrollment;
                JArray enrollmentModelErrorArray = (JArray)enrollmentModelJsonObjectReturn["error"];
                enrollmentModelErrorArray.Clear();

                var enrollmentErrors = from v in validationErrors
                                        where v.Path.StartsWith("[" + enrollmentCount + "]") && !v.Path.Contains("sites")
                                        select new { v.Path, v.Message };

                foreach (var error in enrollmentErrors)
                {
                    enrollmentModelErrorArray.Add(ErrorWriter(error.Path, error.Message));
                }

                //// Id validation
                int enrollmentInputMethodID = (int)enrollmentModelJsonObjectReturn["inputMethod"]["id"];
                string enrollmentInputMethodValue = enrollmentModelJsonObjectReturn["inputMethod"]["value"].ToString();
                bool isValidEnrollmentInputMethod = ValidateStaticIdAndValue(enrollmentInputMethodID, enrollmentInputMethodValue, "enrollment_inputmethod");
                if (!isValidEnrollmentInputMethod)
                {
                    isValidEnrollment = false;
                    enrollmentModelErrorArray.Add(ErrorWriter("inputMethod", InputAdvisorConstants.JSON_INVALID_ID_OR_VALUE));
                }

                //// Id validation : distribution
                int enrollmentDistributionID = (int)enrollmentModelJsonObjectReturn["distribution"]["id"];
                string enrollmentDistributionValue = enrollmentModelJsonObjectReturn["distribution"]["value"].ToString();
                bool isValidEnrollmentDistribution = ValidateStaticIdAndValue(enrollmentDistributionID, enrollmentDistributionValue, "enrollment_distribution");
                if (!isValidEnrollmentDistribution)
                {
                    isValidEnrollment = false;
                    enrollmentModelErrorArray.Add(ErrorWriter("distribution", InputAdvisorConstants.JSON_INVALID_ID_OR_VALUE));
                }

                JArray enrollmentModelSites = (JArray)enrollmentModelJsonObjectReturn["sites"];
                int siteCount = 0;
                foreach (var site in enrollmentModelSites)
                {
                    JObject siteObj = (JObject)site;
                    JArray siteErrorArray = (JArray)siteObj["error"];
                    siteErrorArray.Clear();

                    var siteErrors = from v in validationErrors
                                     where v.Path.Contains("[" + enrollmentCount + "].sites" + "[" + siteCount + "]")
                                     select new { v.Path, v.Message };
                    
                    foreach (var error in siteErrors)
                    {
                        siteErrorArray.Add(ErrorWriter(error.Path, error.Message));
                    }

                    //// Id validation: geography
                    int geographyID = (int)siteObj["geography"]["id"];
                    string geographyValue = siteObj["geography"]["value"].ToString();
                    bool isValidGeography = ValidateStaticIdAndValue(geographyID, geographyValue, "enrollment_sites_geography");
                    if (!isValidGeography)
                    {
                        isValidEnrollment = false;
                        siteErrorArray.Add(ErrorWriter("geography", InputAdvisorConstants.JSON_INVALID_ID_OR_VALUE));
                    }

                    siteCount++;
                }
                enrollmentCount++;
            }

            inputAdvisorJsonObject.Property("validated").Value = isValidEnrollment;
            inputAdvisorJsonObject.Property("enrollment").Value = enrollmentJsonArrayToReturn;
        }

        private void ValidateOperationalCostSchema(JObject inputAdvisorJsonObject)
        {
            //// This is for temporary, will remove in future
            string schema = @"{
  '$schema': 'http://json-schema.org/draft-07/schema',
  '$id': 'http://example.com/example.json',
  'type': 'array',
  'title': 'The Root Schema',
  'description': 'The root schema comprises the entire JSON document.',
  'default': [],
  'additionalItems': true,
  'items': {
    '$id': '#/items',
    'type': 'object',
    'title': 'The Items Schema',
    'description': 'An explanation about the purpose of this instance.',
    'default': {},
    'examples': [
      {
        'error': [
          {
            'field': 'Name',
            'message': 'Error Message'
          }
        ],
        'cardOrder': 1.0,
        'fixedCost': 1000000.0,
        'interimLookCost': 10000.0,
        'name': 'Name operationalCost1',
        'operationalCostID': 1.0,
        'costPerPatient': 10.0
      }
    ],
    'additionalProperties': true,
    'required': [
      'operationalCostID',
      'name',
      'costPerPatient',
      'fixedCost',
      'interimLookCost',
      'cardOrder'
    ],
    'properties': {
      'operationalCostID': {
        '$id': '#/items/properties/operationalCostID',
        'type': 'integer',
        'title': 'The Operationalcostid Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'name': {
        '$id': '#/items/properties/name',
        'type': 'string',
        'title': 'The Name Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          'Name operationalCost1'
        ]
      },
      'costPerPatient': {
        '$id': '#/items/properties/costPerPatient',
        'type': 'number',
        'title': 'The Costperpatient Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          10.0
        ]
      },
      'fixedCost': {
        '$id': '#/items/properties/fixedCost',
        'type': 'number',
        'title': 'The Fixedcost Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1000000.0
        ]
      },
      'interimLookCost': {
        '$id': '#/items/properties/interimLookCost',
        'type': 'number',
        'title': 'The Interimlookcost Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          10000.0
        ]
      },
      'cardOrder': {
        '$id': '#/items/properties/cardOrder',
        'type': 'integer',
        'title': 'The Cardorder Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'error': {
        '$id': '#/items/properties/error',
        'type': 'array',
        'title': 'The Error Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': [],
        'examples': [
          [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ]
        ],
        'additionalItems': true,
        'items': {
          '$id': '#/items/properties/error/items',
          'type': 'object',
          'title': 'The Items Schema',
          'description': 'An explanation about the purpose of this instance.',
          'default': {},
          'examples': [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ],
          'additionalProperties': true,
          'required': [
            'field',
            'message'
          ],
          'properties': {
            'field': {
              '$id': '#/items/properties/error/items/properties/field',
              'type': 'string',
              'title': 'The Field Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Name'
              ]
            },
            'message': {
              '$id': '#/items/properties/error/items/properties/message',
              'type': 'string',
              'title': 'The Message Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Error Message'
              ]
            }
          }
        }
      }
    }
  }
}";

            bool isValidOperationalCost = true;
            string operationalCostJsonStr = inputAdvisorJsonObject["operationalCost"].ToString();

            JArray operationalCostJsonArrayToReturn = JArray.Parse(operationalCostJsonStr);
            if (!operationalCostJsonArrayToReturn.HasValues)
            {
                return;
            }

            JArray operationalCostJsonArrayModified = JArray.Parse(operationalCostJsonStr);

            //// Following commented code will be using in future. GetFullPath won't work while deploy.
            //string schemaPath = Path.GetFullPath(@"..\ProjectManager.Service\InputAdvisorSchema\OperationalCostSchema.json");
            //JSchema operationalCostSchema = JSchema.Parse(File.ReadAllText(schemaPath));
            JSchema operationalCostSchema = JSchema.Parse(schema);

            IList<ValidationError> validationErrors;
            bool isValid = operationalCostJsonArrayToReturn.IsValid(operationalCostSchema, out validationErrors);

            isValidOperationalCost = !isValid ? isValid : isValidOperationalCost;

            int operationalCostCount = 0;
            foreach (var operationalCost in operationalCostJsonArrayToReturn)
            {
                JObject operationalCostJsonObjectReturn = (JObject)operationalCost;
                JArray operationalCostErrorArray = (JArray)operationalCostJsonObjectReturn["error"];
                operationalCostErrorArray.Clear();

                var operationalCostErrors = from v in validationErrors
                                            where v.Path.StartsWith("[" + operationalCostCount + "]")
                                            select new { v.Path, v.Message };

                foreach (var error in operationalCostErrors)
                {
                    operationalCostErrorArray.Add(ErrorWriter(error.Path, error.Message));
                }

                operationalCostCount++;
            }

            inputAdvisorJsonObject.Property("validated").Value = isValidOperationalCost;
            inputAdvisorJsonObject.Property("operationalCost").Value = operationalCostJsonArrayToReturn;
        }

        private void ValidateMarketAccessSchema(JObject inputAdvisorJsonObject)
        {
            //// This is for temporary, will remove in future
            string schema = @"{
  '$schema': 'http://json-schema.org/draft-07/schema',
  '$id': 'http://example.com/example.json',
  'type': 'array',
  'title': 'The Root Schema',
  'description': 'The root schema comprises the entire JSON document.',
  'default': [],
  'additionalItems': true,
  'items': {
    '$id': '#/items',
    'type': 'object',
    'title': 'The Items Schema',
    'description': 'An explanation about the purpose of this instance.',
    'default': {},
    'examples': [
      {
        'proportionOfResidualSales': 10.0,
        'annualRevenueInPeakYear': 10000.0,
        'name': 'Name MarketAccess1',
        'anticipatedTreatmentEffect': 10.0,
        'timeToPatentExpiry': 10.0,
        'timeToPeakAnnualRevenue': 102.0,
        'endpointId': 1.0,
        'marketAccessId': 1.0,
        'discountRate': 0.5,
        'cardOrder': 1.0,
        'error': [
          {
            'field': 'Name',
            'message': 'Error Message'
          }
        ]
      }
    ],
    'additionalProperties': true,
    'required': [
      'marketAccessId',
      'name',
      'endpointId',
      'annualRevenueInPeakYear',
      'timeToPeakAnnualRevenue',
      'proportionOfResidualSales',
      'anticipatedTreatmentEffect',
      'timeToPatentExpiry',
      'discountRate',
      'cardOrder'
    ],
    'properties': {
      'marketAccessId': {
        '$id': '#/items/properties/marketAccessId',
        'type': 'integer',
        'title': 'The Marketaccessid Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'name': {
        '$id': '#/items/properties/name',
        'type': 'string',
        'title': 'The Name Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          'Name MarketAccess1'
        ]
      },
      'endpointId': {
        '$id': '#/items/properties/endpointId',
        'type': 'integer',
        'title': 'The Endpointid Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'annualRevenueInPeakYear': {
        '$id': '#/items/properties/annualRevenueInPeakYear',
        'type': 'number',
        'title': 'The Annualrevenueinpeakyear Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          10000.0
        ]
      },
      'timeToPeakAnnualRevenue': {
        '$id': '#/items/properties/timeToPeakAnnualRevenue',
        'type': 'integer',
        'title': 'The Timetopeakannualrevenue Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          102.0
        ]
      },
      'proportionOfResidualSales': {
        '$id': '#/items/properties/proportionOfResidualSales',
        'type': 'integer',
        'title': 'The Proportionofresidualsales Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          10.0
        ]
      },
      'anticipatedTreatmentEffect': {
        '$id': '#/items/properties/anticipatedTreatmentEffect',
        'type': 'integer',
        'title': 'The Anticipatedtreatmenteffect Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          10.0
        ]
      },
      'timeToPatentExpiry': {
        '$id': '#/items/properties/timeToPatentExpiry',
        'type': 'integer',
        'title': 'The Timetopatentexpiry Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          10.0
        ]
      },
      'discountRate': {
        '$id': '#/items/properties/discountRate',
        'type': 'number',
        'title': 'The Discountrate Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          0.5
        ]
      },
      'cardOrder': {
        '$id': '#/items/properties/cardOrder',
        'type': 'integer',
        'title': 'The Cardorder Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'error': {
        '$id': '#/items/properties/error',
        'type': 'array',
        'title': 'The Error Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': [],
        'examples': [
          [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ]
        ],
        'additionalItems': true,
        'items': {
          '$id': '#/items/properties/error/items',
          'type': 'object',
          'title': 'The Items Schema',
          'description': 'An explanation about the purpose of this instance.',
          'default': {},
          'examples': [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ],
          'additionalProperties': true,
          'required': [
            'field',
            'message'
          ],
          'properties': {
            'field': {
              '$id': '#/items/properties/error/items/properties/field',
              'type': 'string',
              'title': 'The Field Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Name'
              ]
            },
            'message': {
              '$id': '#/items/properties/error/items/properties/message',
              'type': 'string',
              'title': 'The Message Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Error Message'
              ]
            }
          }
        }
      }
    }
  }
}";

            bool isValidMarketAccess = true;
            string marketAccessJsonStr = inputAdvisorJsonObject["marketAccess"].ToString();

            JArray marketAccessJsonArrayToReturn = JArray.Parse(marketAccessJsonStr);
            if (!marketAccessJsonArrayToReturn.HasValues)
            {
                return;
            }

            //// Following commented code will be using in future. GetFullPath won't work while deploy.
            //string schemaPath = Path.GetFullPath(@"..\ProjectManager.Service\InputAdvisorSchema\MarketAccessSchema.json");
            //JSchema marketAccessSchema = JSchema.Parse(File.ReadAllText(schemaPath));
            JSchema marketAccessSchema = JSchema.Parse(schema);

            IList<ValidationError> validationErrors;
            bool isValid = marketAccessJsonArrayToReturn.IsValid(marketAccessSchema, out validationErrors);

            isValidMarketAccess = !isValid ? isValid : isValidMarketAccess;

            int marketAccessCount = 0;
            foreach (var marketAccess in marketAccessJsonArrayToReturn)
            {
                JObject marketAccessJsonObjectReturn = (JObject)marketAccess;
                JArray marketAccessErrorArray = (JArray)marketAccessJsonObjectReturn["error"];
                marketAccessErrorArray.Clear();

                var marketAccessErrors = from v in validationErrors
                                         where v.Path.StartsWith("[" + marketAccessCount + "]")
                                         select new { v.Path, v.Message };

                foreach (var error in marketAccessErrors)
                {
                    marketAccessErrorArray.Add(ErrorWriter(error.Path, error.Message));
                }

                marketAccessCount++;
            }

            inputAdvisorJsonObject.Property("validated").Value = isValidMarketAccess;
            inputAdvisorJsonObject.Property("marketAccess").Value = marketAccessJsonArrayToReturn;
        }

        private void ValidateDesignSchema(JObject inputAdvisorJsonObject)
        {
            //// This is for temporary, will remove in future
            string schema = @"{
  '$schema': 'http://json-schema.org/draft-07/schema',
  '$id': 'http://example.com/example.json',
  'type': 'array',
  'title': 'The Root Schema',
  'description': 'The root schema comprises the entire JSON document.',
  'default': [],
  'additionalItems': true,
  'items': {
    '$id': '#/items',
    'type': 'object',
    'title': 'The Items Schema',
    'description': 'An explanation about the purpose of this instance.',
    'default': {},
    'examples': [
      {
        'type1Error': '0.5',
        'numberOfArms': 2.0,
        'error': [
          {
            'field': 'Name',
            'message': 'Error Message'
          }
        ],
        'testType': {
          'id': 1.0,
          'value': '1-Sided'
        },
        'designKey': 'gh63e92767231we1ea4570b9e81dab753',
        'numberOfEvents': '120',
        'tailType': {
          'id': 1.0,
          'value': 'Left Tail'
        },
        'statisticalDesign': {
          'version': '1.0.01',
          'value': 'Fixed Sample',
          'id': 1.0
        },
        'designId': 1.0,
        'allocationRatio': '3.5',
        'subjectsAreFollowedPeriod': 3.0,
        'subjectsAreFollowedType': {
          'id': 2.0,
          'value': 'Fixed Period'
        },
        'regulatoryRiskAssessment': {
          'id': 1.0,
          'value': 'Low'
        },
        'testStatistics': {
          'id': 1.0,
          'value': 'Logrank'
        },
        'hypothesis': {
          'value': 'Superiority',
          'id': 1.0
        },
        'criticalPoint': -1.96,
        'name': 'Name of Design 1',
        'sampleSize': '400',
        'endpointId': 1.0
      },
      {
        'designKey': 'fr45e92453231gh1ea4570b9e81dab56r',
        'numberOfEvents': '120',
        'tailType': {
          'id': 1.0,
          'value': 'Left Tail'
        },
        'designId': 2.0,
        'statisticalDesign': {
          'value': 'Group Sequential',
          'id': 2.0,
          'version': '1.0.01'
        },
        'efficacy': {
          'boundaries': [
            -1.96,
            -1.96,
            -1.96,
            -1.96
          ],
          'boundaryScale': {
            'value': 'HR Scale',
            'id': 1.0
          },
          'boundaryFamily': {
            'id': 1.0,
            'value': 'Spending Functions'
          },
          'parameter': '2.1',
          'spendingFunction': {
            'value': 'Gamma Family',
            'id': 1.0
          }
        },
        'allocationRatio': '3.5',
        'subjectsAreFollowedPeriod': 3.0,
        'regulatoryRiskAssessment': {
          'value': 'Low',
          'id': 1.0
        },
        'subjectsAreFollowedType': {
          'id': 2.0,
          'value': 'Fixed Period'
        },
        'testStatistics': {
          'id': 1.0,
          'value': 'Logrank'
        },
        'hypothesis': {
          'id': 1.0,
          'value': 'Superiority'
        },
        'interimAnalysesSpacing': [
          30.0,
          50.0,
          70.99
        ],
        'name': 'Name of Design 2',
        'numberOfInterimAnalysis': 3.0,
        'sampleSize': '400',
        'endpointId': 1.0,
        'numberOfArms': 2.0,
        'type1Error': '0.5',
        'testType': {
          'value': '1-Sided',
          'id': 1.0
        },
        'error': [
          {
            'field': 'Name',
            'message': 'Error Message'
          }
        ]
      }
    ],
    'additionalProperties': true,
    'required': [
      'designId',
      'designKey',
      'name',
      'endpointId',
      'numberOfArms',
      'regulatoryRiskAssessment',
      'statisticalDesign',
      'hypothesis',
      'numberOfEvents',
      'sampleSize',
      'allocationRatio',
      'subjectsAreFollowedType',
      'subjectsAreFollowedPeriod',
      'type1Error',
      'testStatistics',
      'testType',
      'tailType',
      'criticalPoint'
    ],
    'properties': {
      'designId': {
        '$id': '#/items/properties/designId',
        'type': 'integer',
        'title': 'The Designid Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'designKey': {
        '$id': '#/items/properties/designKey',
        'type': 'string',
        'title': 'The Designkey Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          'gh63e92767231we1ea4570b9e81dab753'
        ]
      },
      'name': {
        '$id': '#/items/properties/name',
        'type': 'string',
        'title': 'The Name Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          'Name of Design 1'
        ]
      },
      'endpointId': {
        '$id': '#/items/properties/endpointId',
        'type': 'integer',
        'title': 'The Endpointid Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          1.0
        ]
      },
      'numberOfArms': {
        '$id': '#/items/properties/numberOfArms',
        'type': 'integer',
        'title': 'The Numberofarms Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          2.0
        ]
      },
      'regulatoryRiskAssessment': {
        '$id': '#/items/properties/regulatoryRiskAssessment',
        'type': 'object',
        'title': 'The Regulatoryriskassessment Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'value': 'Low',
            'id': 1.0
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/regulatoryRiskAssessment/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/regulatoryRiskAssessment/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Low'
            ]
          }
        }
      },
      'statisticalDesign': {
        '$id': '#/items/properties/statisticalDesign',
        'type': 'object',
        'title': 'The Statisticaldesign Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'id': 1.0,
            'version': '1.0.01',
            'value': 'Fixed Sample'
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value',
          'version'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/statisticalDesign/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/statisticalDesign/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Fixed Sample'
            ]
          },
          'version': {
            '$id': '#/items/properties/statisticalDesign/properties/version',
            'type': 'string',
            'title': 'The Version Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              '1.0.01'
            ]
          }
        }
      },
      'hypothesis': {
        '$id': '#/items/properties/hypothesis',
        'type': 'object',
        'title': 'The Hypothesis Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'id': 1.0,
            'value': 'Superiority'
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/hypothesis/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/hypothesis/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Superiority'
            ]
          }
        }
      },
      'numberOfEvents': {
        '$id': '#/items/properties/numberOfEvents',
        'type': 'string',
        'title': 'The Numberofevents Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          '120'
        ]
      },
      'sampleSize': {
        '$id': '#/items/properties/sampleSize',
        'type': 'string',
        'title': 'The Samplesize Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          '400'
        ]
      },
      'allocationRatio': {
        '$id': '#/items/properties/allocationRatio',
        'type': 'string',
        'title': 'The Allocationratio Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          '3.5'
        ]
      },
      'subjectsAreFollowedType': {
        '$id': '#/items/properties/subjectsAreFollowedType',
        'type': 'object',
        'title': 'The Subjectsarefollowedtype Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'value': 'Fixed Period',
            'id': 2.0
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/subjectsAreFollowedType/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              2.0
            ]
          },
          'value': {
            '$id': '#/items/properties/subjectsAreFollowedType/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Fixed Period'
            ]
          }
        }
      },
      'subjectsAreFollowedPeriod': {
        '$id': '#/items/properties/subjectsAreFollowedPeriod',
        'type': 'integer',
        'title': 'The Subjectsarefollowedperiod Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          3.0
        ]
      },
      'type1Error': {
        '$id': '#/items/properties/type1Error',
        'type': 'string',
        'title': 'The Type1error Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': '',
        'examples': [
          '0.5'
        ]
      },
      'testStatistics': {
        '$id': '#/items/properties/testStatistics',
        'type': 'object',
        'title': 'The Teststatistics Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'value': 'Logrank',
            'id': 1.0
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/testStatistics/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/testStatistics/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Logrank'
            ]
          }
        }
      },
      'testType': {
        '$id': '#/items/properties/testType',
        'type': 'object',
        'title': 'The Testtype Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'value': '1-Sided',
            'id': 1.0
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/testType/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/testType/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              '1-Sided'
            ]
          }
        }
      },
      'tailType': {
        '$id': '#/items/properties/tailType',
        'type': 'object',
        'title': 'The Tailtype Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': {},
        'examples': [
          {
            'id': 1.0,
            'value': 'Left Tail'
          }
        ],
        'additionalProperties': true,
        'required': [
          'id',
          'value'
        ],
        'properties': {
          'id': {
            '$id': '#/items/properties/tailType/properties/id',
            'type': 'integer',
            'title': 'The Id Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
              1.0
            ]
          },
          'value': {
            '$id': '#/items/properties/tailType/properties/value',
            'type': 'string',
            'title': 'The Value Schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
              'Left Tail'
            ]
          }
        }
      },
      'criticalPoint': {
        '$id': '#/items/properties/criticalPoint',
        'type': 'number',
        'title': 'The Criticalpoint Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': 0,
        'examples': [
          -1.96
        ]
      },
      'error': {
        '$id': '#/items/properties/error',
        'type': 'array',
        'title': 'The Error Schema',
        'description': 'An explanation about the purpose of this instance.',
        'default': [],
        'examples': [
          [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ]
        ],
        'additionalItems': true,
        'items': {
          '$id': '#/items/properties/error/items',
          'type': 'object',
          'title': 'The Items Schema',
          'description': 'An explanation about the purpose of this instance.',
          'default': {},
          'examples': [
            {
              'field': 'Name',
              'message': 'Error Message'
            }
          ],
          'additionalProperties': true,
          'required': [
            'field',
            'message'
          ],
          'properties': {
            'field': {
              '$id': '#/items/properties/error/items/properties/field',
              'type': 'string',
              'title': 'The Field Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Name'
              ]
            },
            'message': {
              '$id': '#/items/properties/error/items/properties/message',
              'type': 'string',
              'title': 'The Message Schema',
              'description': 'An explanation about the purpose of this instance.',
              'default': '',
              'examples': [
                'Error Message'
              ]
            }
          }
        }
      }
    }
  }
}";

            bool isValidDesign = true;
            string designJsonStr = inputAdvisorJsonObject["design"].ToString();

            JArray designJsonArrayToReturn = JArray.Parse(designJsonStr);
            if (!designJsonArrayToReturn.HasValues)
            {
                return;
            }

            //// Following commented code will be using in future. GetFullPath won't work while deploy.
            //string schemaPath = Path.GetFullPath(@"..\ProjectManager.Service\InputAdvisorSchema\DesignSchema.json");
            //JSchema designSchema = JSchema.Parse(File.ReadAllText(schemaPath));
            JSchema designSchema = JSchema.Parse(schema);

            IList<ValidationError> validationErrors;
            bool isValid = designJsonArrayToReturn.IsValid(designSchema, out validationErrors);

            isValidDesign = !isValid ? isValid : isValidDesign;

            int designCount = 0;
            foreach (var design in designJsonArrayToReturn)
            {
                JObject designJsonObjectReturn = (JObject)design;
                JArray designErrorArray = (JArray)designJsonObjectReturn["error"];
                designErrorArray.Clear();

                var designErrors = from v in validationErrors
                                         where v.Path.StartsWith("[" + designCount + "]")
                                         select new { v.Path, v.Message };

                foreach (var error in designErrors)
                {
                    designErrorArray.Add(ErrorWriter(error.Path, error.Message));
                }

                //// ToDO: Id validation

                designCount++;
            }

            inputAdvisorJsonObject.Property("validated").Value = isValidDesign;
            inputAdvisorJsonObject.Property("design").Value = designJsonArrayToReturn;
        }

        private JToken ErrorWriter(string errorPath, string errorMessage)
        {
            using (JTokenWriter writer = new JTokenWriter())
            {
                writer.WriteStartObject();
                writer.WritePropertyName("field");
                writer.WriteValue(errorPath);
                writer.WritePropertyName("message");
                writer.WriteValue(errorMessage);
                writer.WriteEndObject();
                return writer.Token;
            }
        }

        private bool ValidateStaticIdAndValue(int staticID, string staticValue, string staicModel)
        {
            try
            {
                return projectDataAccess.IsStaticIdAndValueExist(staticID, staticValue, staicModel);
            }
            catch (Exception validateStaticIdAndValue)
            {
                throw new Exception(ExceptionMessages.IS_PROJECT_ID_EXISTS_FOR_RESOURCE_ID_SERVICE_ERROR_MSG, validateStaticIdAndValue);
            }
        }
    }
}


