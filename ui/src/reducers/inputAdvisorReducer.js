const initState = {
  inputAdvisorData: {
    objective: {
      endpoint: [
        {
          error: [],
        },
      ],
      error: [],
    },
    population: [
      {
        error: [],
        endpointModel: [
          {
            error: [],
            model: {},
            inputMethod: {},
          },
        ],
        dropoutRateModel: {
          error: [],
          model: {},
          inputMethod: {},
        },
      },
    ],
    operationalCost: [{ error: [] }],
    marketAccess: [
      {
        error: [],
      },
    ],
  },
};

const inputAdvisorReducer = (state = initState, action) => {
  switch (action.type) {
    case "INPUT_ADVISOR_UPDATE": {
      return { ...state, inputAdvisorData: action.inputAdvisorData };
    }
    case "INPUT_ADVISOR_UPDATE_OBJECTIVE_DATA": {
      return {
        ...state,
        inputAdvisorData: {
          ...state.inputAdvisorData,
          objective: action.objectiveData.payload,
        },
      };
    }
    case "UPDATE_ISUPDATED": {
      return { ...state, isUpdated: true };
    }
    case "INPUT_ADVISOR_UPDATE_OPERATIONALCOST_DATA": {
      return {
        ...state,
        inputAdvisorData: {
          ...state.inputAdvisorData,
          operationalCost: action.operationalCost.payload,
        },
      };
    }
    case "INPUT_ADVISOR_UPDATE_MARKETACCESS_DATA": {
      return {
        ...state,
        inputAdvisorData: {
          ...state.inputAdvisorData,
          marketAccess: action.marketAccess.payload,
        },
      };
    }
    default:
      return state;
  }
};

export default inputAdvisorReducer;
