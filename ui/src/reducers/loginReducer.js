const initState = {
    signedInUser:{},
  };
  
  const loginReducer = (state = initState, action) => {
    switch (action.type) {
      case "USER_SIGNEDIN_UPDATE": {
        return { ...state, signedInUser: action.signedInUser };
      }
      default:
        return state;
    }
  };
  
  export default loginReducer;