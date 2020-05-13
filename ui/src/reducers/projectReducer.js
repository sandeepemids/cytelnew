const initState = {
  projects: [],
  projectStatusList: [],
  errorData: {},
  isNewProject: false,
  endpoints: [],
  currentProject: {},
  projectTimeUnit: "",
  projectId: null,
  createdBy: "",
  isEditMode: null,
};

const projectReducer = (state = initState, action) => {
  switch (action.type) {
    case "PROJECTS_UPDATE": {
      return { ...state, projects: action.projects };
    }
    case "PROJECT_STATUS_LIST_UPDATE": {
      return { ...state, projectStatusList: action.projectStatusList };
    }
    case "INDICATIONS_UPDATE": {
      return { ...state, indications: action.indications };
    }
    case "TIMEUNITS_UPDATE": {
      return { ...state, timeunits: action.timeunits };
    }
    case "CURRENCIES_UPDATE": {
      return { ...state, currencies: action.currencies };
    }
    case "PROGRAMS_UPDATE": {
      return { ...state, programs: action.programs };
    }
    case "PROJECT_ERROR_UPDATE": {
      return { ...state, errorData: action.errorData };
    }
    case "NEW_PROGRAM_UPDATE": {
      return { ...state, newProgram: action.newProgram };
    }
    case "IS_NEW_PROJECT_UPDATE": {
      return { ...state, isNewProject: action.isNewProject };
    }
    case "ENDPOINTS_UPDATE": {
      return { ...state, endpoints: action.endpoints };
    }
    case "CURRENT_PROJECT": {
      return { ...state, currentProject: action.currentProject };
    }
    case "PROJECT_TIMEUNIT_UPDATE": {
      return {
        ...state,
        projectTimeUnit: action.projectTimeUnit,
        projectId: action.projectId,
        createdBy: action.createdBy,
        isEditMode: action.isEditMode,
      };
    }
    default:
      return state;
  }
};

export default projectReducer;
