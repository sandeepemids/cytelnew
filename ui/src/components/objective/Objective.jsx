import React, { Component } from "react";
import Grid from "@material-ui/core/Grid";
import objectiveStyle from "./objectiveStyle";
import { Typography, Button } from "@material-ui/core";
import { InputText } from "../../components/common/inputText";
import { EndPoint } from "./endPoint";
import { faClipboardCheck } from "@fortawesome/pro-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { withRouter } from "react-router-dom";
import { withStyles } from "@material-ui/core/styles";
import { connect } from "react-redux";
import { FormattedMessage, injectIntl, intlShape } from "react-intl"

class Objective extends Component {
  constructor(props) {
    super(props);
    this.state = {
      projectObj: {
        isEditMode: false,
        projectId: undefined,
      },
      objectiveData: {},
    };
  }
  componentDidMount = () => {
    const { state } = this.props.history.location;
    const { resourceId } = this.props.signedInUser;
    // when landing page to objective page
    if (state !== undefined) {
      const { isEditMode, projectId, createdBy, timeUnit } = state || {};
      let _isEditMode = true;
      if (state) {
        if (isEditMode) {
          _isEditMode = false;
        }
        this.setState({
          ...this.state,
          projectObj: { isEditMode: _isEditMode, projectId },
        });
      }
      this.props.updateCurrentProject({
        isEditMode: _isEditMode,
        projectId: projectId,
        createdBy: createdBy,
        timeUnit: timeUnit,
      });
      this.props.getInputAdvisorTemplate(resourceId, projectId);
    } else {
      //other menu to objective page

      const { projectId, isEditMode } = this.props.currentProject;
      this.setState({
        ...this.state,
        projectObj: { isEditMode: isEditMode, projectId },
      });
      this.props.getInputAdvisorTemplate(resourceId, projectId);
    }
    this.props.getEndpoints();
  };

  componentWillReceiveProps(nextProps) {
    // Any time props.inputAdvisorData changes, update state.

    if (nextProps.inputAdvisorData !== this.props.inputAdvisorData) {
      this.setState({
        objectiveData: nextProps.inputAdvisorData.objective,
      });
    }
  }
  componentWillUnmount = () => {
    let objectiveData = { ...this.state.objectiveData };

    if (objectiveData.endpoint)
      objectiveData.endpoint[0].Type = "Time to Event";

    delete objectiveData.Name;
    delete objectiveData.Type;
    delete objectiveData.Endpoint;

    Object.keys(objectiveData).forEach((element) => {
      if (typeof objectiveData[element] !== "object") {
        if (
          objectiveData.error.filter((err) => err && err.field === element)
            .length === 0
        ) {
          const errorObj = this.formValidation(element, objectiveData[element]);
          errorObj &&
            Object.keys(errorObj).length &&
            objectiveData.error.push(
              this.formValidation(element, objectiveData[element])
            );
        }
      } else if (element === "endpoint") {
        const innerEndpointObj = objectiveData.endpoint[0];
        Object.keys(innerEndpointObj).forEach((element) => {
          if (typeof innerEndpointObj[element] === "string") {
            if (
              innerEndpointObj.error.filter(
                (err) => err && err.field === element
              ).length === 0 &&
              innerEndpointObj[element] !== "Time to Event"
            ) {
              const errorObj = this.formValidation(
                element,
                innerEndpointObj[element]
              );

              errorObj &&
                Object.keys(errorObj).length &&
                innerEndpointObj.error.push(
                  this.formValidation(element, innerEndpointObj[element])
                );
            }
          }
        });
        objectiveData.endpoint[0].error = innerEndpointObj.error;
      }
    });

    let _FinalinputAdvisorData = {};

    //
    let _inputAdvisorData = { ...this.props.inputAdvisorData };

    _FinalinputAdvisorData.object = { ..._inputAdvisorData };
    _FinalinputAdvisorData.object.objective = { ...objectiveData };
    _FinalinputAdvisorData.createdBy = this.props.currentProject.createdBy;
    _FinalinputAdvisorData.projectID = this.props.currentProject.projectId;
    _FinalinputAdvisorData.resourceID = this.props.signedInUser.resourceId;

    // need add api here
    const pageID = "objective";
    this.props.updateInputAdvisorDataDB(pageID, _FinalinputAdvisorData);

    //update inputAdvisorData at store level
    this.props.updateObjectData(objectiveData);
  };

  handleChange = (event) => {
    const { target } = event;
    this.clearErrorMessage(event.target.name);
    const error = this.validateField(event);
    if (error === undefined) {
      this.setState((state) => {
        const _objectiveData = { ...state.objectiveData };
        return {
          ...this.state,
          objectiveData: {
            ..._objectiveData,
            [target.name]: target.value,
          },
        };
      });
    }
  };

  handleChangeEndpoint = (event, id) => {
    const { target } = event;
    this.clearErrorMessageEndpoint(event.target.name);
    const error = this.validateField(event);
    const _endpoints = this.state.objectiveData.endpoint;
    const index = _endpoints.findIndex((endpoint) => endpoint.id === id);
    const _endpoint = _endpoints[index];
    if (error === undefined) {
      _endpoint[event.target.name] = event.target.value;
      _endpoints[index] = _endpoint;

      this.setState((prevState) => {
        const _objectiveData = { ...prevState.objectiveData };
        _objectiveData.endpoint = _endpoints;
        return {
          ...this.prevState,
          objectiveData: {
            ..._objectiveData,
            [target.name]: target.value,
          },
        };
      });
    }
  };

  validateField = (e) => {
    const { name, value, placeholder } = e.target;
    const limitChars = 75;
    if (value.toString().trim().length <= limitChars) {
      const pattern = new RegExp('^[a-zA-Z0-9!@#$&()\\-`.+,/"]*$');
      const isValidMatch = pattern.test(value);
      if (!isValidMatch) {
        return {
          field: name,
          message: `${placeholder} will allow only alphanumeric and special characters`,
        };
      }
    } else {
      return {
        field: name,
        message: `${placeholder} allow only ${limitChars} characters`,
      };
    }
  };

  validateFieldOnBlur = (e) => {
    const { name, value, placeholder } = e.target;
    if (
      value.toString().trim().length === 0 ||
      value.toString().trim() === "select"
    ) {
      return {
        field: name,
        message: `${placeholder ? placeholder : name} is required`,
      };
    }
  };

  handleBlur = (e) => {
    const error = this.validateFieldOnBlur(e);
    if (error !== undefined) {
      this.updateErrorToState(error);
    }
  };

  handleBlurEndpoint = (e) => {
    const error = this.validateFieldOnBlur(e);
    if (error !== undefined) {
      this.updateEndpointErrorToState(error);
    }
  };

  updateErrorToState = (errorObj) => {
    const { field, message } = errorObj;
    const errors = [...this.state.objectiveData.error];
    //start- update existed error entry of the field
    const index = errors.findIndex((ele) => ele.field === field);
    if (index > 0) {
      let existError = errors[index];
      existError.message = message;
      errors[index] = existError;
    } else {
      errors.push(errorObj);
    }
    //end- update existed error entry of the field
    this.setState({
      ...this.state,
      objectiveData: { ...this.state.objectiveData, error: errors },
    });
  };

  updateEndpointErrorToState = (errorObj) => {
    const { field, message } = errorObj;
    const endpoints = [...this.state.objectiveData.endpoint];
    const errors = endpoints[0].error;

    //start- update existed error entry of the field
    const index = errors.findIndex((ele) => ele.field === field);
    if (index > 0) {
      let existError = errors[index];
      existError.message = message;
      errors[index] = existError;
    } else {
      errors.push(errorObj);
    }
    //end- update existed error entry of the field

    endpoints[0].error = errors;
    this.setState({
      ...this.state,
      objectiveData: { ...this.state.objectiveData, endpoint: endpoints },
    });
  };

  isErrorField = (name) => {
    return (
      this.state.objectiveData.error &&
      this.state.objectiveData.error.findIndex((ele) => ele.field === name) > 0
    );
  };

  isErrorFieldEndpoint = (name) => {
    return (
      this.state.objectiveData.endpoint &&
      this.state.objectiveData.endpoint[0].error.findIndex(
        (ele) => ele.field === name
      ) > 0
    );
  };

  isErrorMessage = (name) => {
    const errorObj =
      this.state.objectiveData.error &&
      this.state.objectiveData.error.filter((ele) => ele.field === name);

    return errorObj && errorObj.length ? errorObj && errorObj[0].message : null;
  };
  isErrorMessageEndpoint = (name) => {
    const errorObj =
      this.state.objectiveData.endpoint &&
      this.state.objectiveData.endpoint[0].error.filter(
        (ele) => ele.field === name
      );
    return errorObj && errorObj.length ? errorObj && errorObj[0].message : null;
  };

  clearErrorMessage = (name) => {
    let temp;
    let errors = [...this.state.objectiveData.error];
    const index = errors.findIndex((ele) => ele.field === name);
    if (index > 0) {
      temp = [...errors.filter((ele) => ele.field !== name)];
    }
    this.setState({
      ...this.state,
      objectiveData: {
        ...this.state.objectiveData,
        error: temp ? temp : errors,
      },
    });
  };

  clearErrorMessageEndpoint = (name) => {
    let temp;
    let endpoints = [...this.state.objectiveData.endpoint];
    let errors = [...endpoints[0].error];
    const index = errors.findIndex((ele) => ele.field === name);
    if (index > 0) {
      temp = [...errors.filter((ele) => ele.field !== name)];
    }
    endpoints[0].error = temp ? temp : errors;
  };

  formValidation = (name, value) => {
    if (
      value.toString().trim().length === 0 ||
      value.toString().trim() === "select"
    ) {
      return {
        field: name,
        message: `${this.replaceKeyName(name)} is required`,
      };
    }
  };
  replaceKeyName = (name) => {
    switch (name) {
      case "populationName": {
        return "Target Population";
      }
      case "treatmentArm": {
        return "Treatment Arm";
      }
      case "controlArm": {
        return "Control Arm";
      }
      case "Name": {
        return "Name";
      }
      case "Endpoint": {
        return "Endpoint";
      }
      case "Type": {
        return "Type";
      }
    }
  };

  render() {
    const intl = this.props.intl;
    const { classes } = this.props;
    return (
      <Grid className={classes.root} id="objective">
        <Grid container>
          <Grid item md={12} className={classes.inputAdvisorHeader}>
            <Typography variant="h6">
              <FontAwesomeIcon
                id="objectiveIcon"
                className={classes.inputAdvisorIcon}
                icon={faClipboardCheck}
              />
              <FormattedMessage id="objective.objective"></FormattedMessage>
            </Typography>
          </Grid>
          <Grid item md={12} className={classes.inputControl}>
            <Grid container spacing={2}>
              <Grid item md={4}>
                <FormattedMessage id="objective.targetPopulation">
                  {
                    placeholder => <InputText
                      isDisabled={this.state.projectObj.isEditMode}
                      id="target"
                      label={placeholder}
                      value={this.state.objectiveData.populationName}
                      handleChange={(event) => this.handleChange(event)}
                      name="populationName"
                      handleBlur={(event) => this.handleBlur(event)}
                      error={this.isErrorField("populationName")}
                      helperText={this.isErrorMessage("populationName")}
                    ></InputText>}
                </FormattedMessage>                
              </Grid>
              <Grid item md={4}>
                <FormattedMessage id="objective.treatmentArm">
                  {
                    placeholder => <InputText
                    isDisabled={this.state.projectObj.isEditMode}
                    id="treatment"
                    label={placeholder}
                    value={this.state.objectiveData.treatmentArm}
                    handleChange={(event) => this.handleChange(event)}
                    name="treatmentArm"
                    handleBlur={(event) => this.handleBlur(event)}
                    error={this.isErrorField("treatmentArm")}
                    helperText={this.isErrorMessage("treatmentArm")}
                    tabIndex={2}
                    ></InputText>
                  }
                </FormattedMessage>
              </Grid>
              <Grid item md={4}>
                <FormattedMessage id="objective.controlArm">
                  {
                    placeholder => <InputText
                    isDisabled={this.state.projectObj.isEditMode}
                    id="control"
                    label={placeholder}
                    value={this.state.objectiveData.controlArm}
                    handleChange={(event) => this.handleChange(event)}
                    name="controlArm"
                    handleBlur={(event) => this.handleBlur(event)}
                    error={this.isErrorField("controlArm")}
                    helperText={this.isErrorMessage("controlArm")}
                    tabIndex={3}
                    ></InputText>
                  }
                </FormattedMessage>
              </Grid>
            </Grid>
          </Grid>
          <Grid item md={12}>
            <EndPoint
              setEndpointControlName="Name"
              setEndpointControlTypeName="Type"
              setEndpointControlEndpointName="Endpoint"
              setEndpointControlNameValue={
                this.state.objectiveData.endpoint &&
                this.state.objectiveData.endpoint[0].Name
              }
              setEndpointControlTypeValue={
                this.state.objectiveData.endpoint &&
                this.state.objectiveData.endpoint[0].Type === ""
                  ? "Time to Event"
                  : this.state.objectiveData.endpoint &&
                    this.state.objectiveData.endpoint[0].Type
              }
              setEndpointControlValues={this.props.endpoints}
              textToDisplay="name"
              valueToReturn="id"
              dropdownSelectedValue={
                this.state.objectiveData.endpoint &&
                this.state.objectiveData.endpoint[0].Endpoint === ""
                  ? ""
                  : this.state.objectiveData.endpoint &&
                    this.state.objectiveData.endpoint[0].Endpoint
              }
              handleInputSelectChange={(event, id) =>
                this.handleChangeEndpoint(
                  event,
                  this.state.objectiveData.endpoint[0].id
                )
              }
              handleChange={(event, id) =>
                this.handleChangeEndpoint(
                  event,
                  this.state.objectiveData.endpoint[0].id
                )
              }
              isDisabled={this.state.projectObj.isEditMode}
              handleBlur={(event) => this.handleBlurEndpoint(event)}
              isNameValid={this.isErrorFieldEndpoint("Name")}
              isEndpointValid={this.isErrorFieldEndpoint("Endpoint")}
              isTypeValid={this.isErrorFieldEndpoint("Type")}
              nameHelperText={this.isErrorMessageEndpoint("Name")}
              endpointHelperText={this.isErrorMessageEndpoint("Endpoint")}
              typeHelperText={this.isErrorMessageEndpoint("Type")}
              nameTabIndex={4}
              endpointTabIndex={5}
              typeTabIndex={6}
            />
          </Grid>
        </Grid>
      </Grid>
    );
  }
}

const mapDispatchToProps = (dispatch) => {
  return {
    updateObjectData: (objectiveData) =>
      dispatch({
        type: "INPUT_ADVISOR_WITH_OBJ_DATA",
        payload: objectiveData,
      }),
    getInputAdvisorTemplate: (resourceID, projectID) =>
      dispatch({
        type: "INPUT_ADVISOR",
        payload: { resourceID: resourceID, projectID: projectID },
      }),
    getEndpoints: () =>
      dispatch({
        type: "ENDPOINT_LIST_UPDATE",
      }),
    updateCurrentProject: ({ isEditMode, projectId, createdBy, timeUnit }) =>
      dispatch({
        type: "CURRENT_PROJECT_OBJ_UPDATE",
        payload: {
          isEditMode: isEditMode,
          projectId: projectId,
          createdBy: createdBy,
          timeUnit: timeUnit,
        },
      }),
    updateInputAdvisorDataDB: (pageID, InputAdvisorData) => {
      dispatch({
        type: "INPUT_ADVISOR_DATA_UPDATE",
        payload: { pageID, InputAdvisorData },
      });
    },
  };
};

const mapStateToProps = (state) => {
  return {
    objectiveData: state.inputAdvisorReducer.objectiveData,
    inputAdvisorData: state.inputAdvisorReducer.inputAdvisorData,
    endpoints: state.projectReducer.endpoints,
    signedInUser: state.loginReducer.signedInUser,
    currentProject: state.projectReducer.currentProject,
  };
};

Objective = connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(withStyles(objectiveStyle)(Objective)));
export default injectIntl(Objective) ;
