import React, { Component } from "react";
import Grid from "@material-ui/core/Grid";
import OPERATINALCOSTS from "./constants";
import operationalCostsStyle from "./operationalCostsStyle";
import { Typography, Button } from "@material-ui/core";
import { faReceipt } from "@fortawesome/pro-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useHistory } from "react-router-dom";
import { Model } from "./model/Model";
import { withRouter } from "react-router-dom";
import { withStyles } from "@material-ui/core/styles";
import { connect } from "react-redux";

class OperationalCosts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      operationalCost: {},
      cardIndex: 0,
    };
  }

  componentDidMount() {
    const { resourceId } = this.props.signedInUser;
    this.props.getInputAdvisorTemplate(resourceId, this.props.projectId);
  }

  componentWillReceiveProps(nextProps) {
    // Any time props.inputAdvisorData changes, update state.
    const { cardIndex } = this.state;
    if (nextProps.inputAdvisorData !== this.props.inputAdvisorData) {
      if (!nextProps.inputAdvisorData.operationalCost[cardIndex].costPerPatient) {
        nextProps.inputAdvisorData.operationalCost[cardIndex].costPerPatient = "";
      }
      if (!nextProps.inputAdvisorData.operationalCost[cardIndex].fixedCost) {
        nextProps.inputAdvisorData.operationalCost[cardIndex].fixedCost = "";
      }
      if (!nextProps.inputAdvisorData.operationalCost[cardIndex].interimLookCost) {
        nextProps.inputAdvisorData.operationalCost[cardIndex].interimLookCost = "";
      }
      this.setState({
        operationalCost: nextProps.inputAdvisorData.operationalCost[cardIndex],
      });
    }
  }

  componentWillUnmount = () => {
    let operationalCost = { ...this.state.operationalCost };
    let operationalCostObj = [];
    operationalCostObj[0] = operationalCost;

    Object.keys(operationalCost).forEach((element) => {
      if (typeof operationalCost[element] !== "object") {
        if (
          operationalCost.error.filter((err) => err && err.field === element)
            .length === 0
        ) {
          const errorObj = this.formValidation(
            element,
            operationalCost[element]
          );
          errorObj &&
            Object.keys(errorObj).length &&
            operationalCost.error.push(
              this.formValidation(element, operationalCost[element])
            );
        }
      }
    });

    let _FinalinputAdvisorData = {};

    let _inputAdvisorData = { ...this.props.inputAdvisorData };

    _FinalinputAdvisorData.object = { ..._inputAdvisorData };
    _FinalinputAdvisorData.object.operationalCost.splice(0, _FinalinputAdvisorData.object.operationalCost.length, ...operationalCostObj)
    _FinalinputAdvisorData.createdBy = this.props.createdBy;
    _FinalinputAdvisorData.projectID = this.props.projectId;
    _FinalinputAdvisorData.resourceID = this.props.signedInUser.resourceId;

    // need add api here
    const pageID = "operational-costs";
    this.props.updateInputAdvisorDataDB(pageID, _FinalinputAdvisorData);

    //update inputAdvisorData at store level
    this.props.updateOperationalCostData(operationalCostObj);
  };

  validateFieldOnBlur = (e) => {
    const { name, value, placeholder } = e.target;
    if (name !== "fixedCost") {
      if (
        value.toString().trim().length === 0 ||
        value.toString().trim() === "select"
      ) {
        return {
          field: name,
          message: `${placeholder ? placeholder : name} is required`,
        };
      }
    }
  };

  clearErrorMessage = (name) => {
    if (this.state.operationalCost) {
      if (name !== "fixedCost") {
        let temp;
        let errors = [...this.state.operationalCost.error];
        const index = errors.findIndex((ele) => ele.field === name);
        if (index > 0) {
          temp = [...errors.filter((ele) => ele.field !== name)];
        }
        this.setState({
          ...this.state,
          operationalCost: {
            ...this.state.operationalCost,
            error: temp ? temp : errors,
          },
        });
      }
    }
  };

  handleOperationalCostsChange = (event) => {
    const { name, value } = event.target;
    this.clearErrorMessage(name);
    if (name === "name" && value.length <= 75) {
      this.setState((state) => {
        const _operationalCost = { ...state.operationalCost };
        return {
          ...this.state,
          operationalCost: {
            ..._operationalCost,
            [name]: value,
          },
        };
      });
    } else if (name === "costPerPatient") {
      let valueWithoutSpecialChar = value.replace(/[_\W]+/g, "");
      const pattern = /^[0-9 ]+$/i;
      const isValidcostPerPatient = pattern.test(valueWithoutSpecialChar);
      if (isValidcostPerPatient || valueWithoutSpecialChar === "") {
        this.setState((state) => {
          const _operationalCost = { ...state.operationalCost };
          return {
            ...this.state,
            operationalCost: {
              ..._operationalCost,
              [name]: valueWithoutSpecialChar,
            },
          };
        });
      }
    } else if (name === "fixedCost") {
      let valueWithoutSpecialChar = value.replace(/[_\W]+/g, "");
      const pattern = /^[0-9 ]+$/i;
      const isValidfixedCost = pattern.test(valueWithoutSpecialChar);
      if (isValidfixedCost || valueWithoutSpecialChar === "") {
        this.setState({
          operationalCost: {
            ...this.state.operationalCost,
            [name]: valueWithoutSpecialChar,
          },
        });
      }
    } else if (name === "interimLookCost") {
      let valueWithoutSpecialChar = value.replace(/[_\W]+/g, "");
      const pattern = /^[0-9 ]+$/i;
      const isValidinterimLookCost = pattern.test(valueWithoutSpecialChar);
      if (isValidinterimLookCost || valueWithoutSpecialChar === "") {
        this.setState((state) => {
          const _operationalCost = { ...state.operationalCost };
          return {
            ...this.state,
            operationalCost: {
              ..._operationalCost,
              [name]: valueWithoutSpecialChar,
            },
          };
        });
      }
    }
  };

  isErrorField = (value) => {
    if (this.state.operationalCost) {
      if (value.name !== "fixedCost") {
        return (
          this.state.operationalCost.error &&
          this.state.operationalCost.error.findIndex(
            (ele) => ele.field === value
          ) > 0
        );
      }
    }
  };

  isErrorMessage = (value) => {
    if (this.state.operationalCost) {
      if (value.name !== "fixedCost") {
        const errorObj =
          this.state.operationalCost.error &&
          this.state.operationalCost.error.filter((ele) => ele.field === value);

        return errorObj && errorObj.length
          ? errorObj && errorObj[0].message
          : null;
      }
    }
  };

  handleBlurEvent = (event) => {
    const error = this.validateFieldOnBlur(event);
    if (error !== undefined) {
      this.updateErrorToState(error);
    } else {
      const { name, value } = event.target;
      if (name !== "name") {
        if (value) {
          //check if entered value in textbox has special character in it. if yes then remove those and then Add $
          if (/^[a-zA-Z0-9- ]*$/.test(value) == false) {
            let valueWithoutChar = value.replace(/[_\W]+/g, "");
            const valueDisplay = parseInt(valueWithoutChar).toLocaleString(
              "en-US",
              {
                minimumFractionDigits: 0,
                style: "currency",
                currency: "USD",
              }
            );
            if (valueDisplay) {
              this.setState({
                operationalCost: {
                  ...this.state.operationalCost,
                  [name]: valueDisplay,
                },
              });
            }
          } else {
            const valueDisplay = parseInt(value).toLocaleString("en-US", {
              minimumFractionDigits: 0,
              style: "currency",
              currency: "USD",
            });
            if (valueDisplay) {
              this.setState({
                operationalCost: {
                  ...this.state.operationalCost,
                  [name]: valueDisplay,
                },
              });
            }
          }
        }
      }
    }
  };

  updateErrorToState = (errorObj) => {
    if (this.state.operationalCost) {
      const { field, message } = errorObj;
      const errors = [...this.state.operationalCost.error];
      //start- update existed error entry of the field

      const index = errors.findIndex((ele) => ele.field === field);
      if (index > 0) {
        let existError = errors[index];
        existError.message = message;
        errors[index] = existError;
      } else {
        errors && errors.push(errorObj);
      }
      //end- update existed error entry of the field
      this.setState({
        ...this.state,
        operationalCost: { ...this.state.operationalCost, error: errors },
      });
    }
  };

  formValidation = (name, value) => {
    if (name !== "fixedCost") {
      if (value.toString().trim().length === 0)
        return {
          field: name,
          message: `${this.replaceKeyName(name)} is required`,
        };
    }
  };
  replaceKeyName = (name) => {
    switch (name) {
      case "name": {
        return "Name";
      }
      case "costPerPatient": {
        return "Cost per Interim Analysis";
      }
      case "interimLookCost": {
        return `Cost per Patient ${this.props.timeUnitValue}`;
      }
    }
  };

  render() {
    const { classes } = this.props;

    return (
      <Grid className={classes.root} id="operational-costs">
        <Grid container>
          <Grid item md={12} className={classes.inputAdvisorHeader}>
            <Typography variant="h6">
              <FontAwesomeIcon
                id="operationalCostsIcon"
                className={classes.inputAdvisorIcon}
                icon={faReceipt}
              />
              {OPERATINALCOSTS.TITLE}
            </Typography>
          </Grid>
          <Grid item md={12}>
            <Model
              modelDetails={this.state.operationalCost}
              handleOperationalCosts={this.handleOperationalCostsChange}
              handleBlur={(event) => this.handleBlurEvent(event)}
              timeUnitValue={this.props.projectTimeUnit}
              setName="name"
              setCostPerPatient="costPerPatient"
              setFixedCost="fixedCost"
              setInterimLookCost="interimLookCost"
              isNameValid={this.isErrorField("name")}
              isCostPerPatientValid={this.isErrorField("costPerPatient")}
              isInterimLookCostValid={this.isErrorField("interimLookCost")}
              nameHelperText={this.isErrorMessage("name")}
              costPerPatientHelperText={this.isErrorMessage("costPerPatient")}
              interimLookCostHelperText={this.isErrorMessage("interimLookCost")}
              isEditMode={this.props.isEditMode}
              nameTabIndex={1}
              costPerPatientTabIndex={2}
              fixedCostTabIndex={3}
              interimLookCostTabIndex={4}
            />
          </Grid>
        </Grid>
      </Grid>
    );
  }
}

const mapDispatchToProps = (dispatch) => {
  return {
    updateOperationalCostData: (operationalCost) =>
      dispatch({
        type: "INPUT_ADVISOR_WITH_OPERATIONALCOST_DATA",
        payload: operationalCost,
      }),
    getInputAdvisorTemplate: (resourceID, projectID) =>
      dispatch({
        type: "INPUT_ADVISOR",
        payload: { resourceID: resourceID, projectID: projectID },
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
    operationalCost: state.inputAdvisorReducer.operationalCost,
    projectTimeUnit: state.projectReducer.projectTimeUnit,
    inputAdvisorData: state.inputAdvisorReducer.inputAdvisorData,
    projectId: state.projectReducer.projectId,
    signedInUser: state.loginReducer.signedInUser,
    createdBy: state.projectReducer.createdBy,
    isEditMode: state.projectReducer.isEditMode,
  };
};

OperationalCosts = connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(withStyles(operationalCostsStyle)(OperationalCosts)));
export { OperationalCosts };
