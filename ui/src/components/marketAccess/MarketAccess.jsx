import React, { Component } from "react";
import Grid from "@material-ui/core/Grid";
import MARKETACCESS from "./constants";
import marketAccessStyle from "./marketAccessStyle";
import { Typography, Button } from "@material-ui/core";
import { faCabinetFiling } from "@fortawesome/pro-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { MarketAccessModel } from "./marketAccessModel/MarketAccessModel";
import { withRouter } from "react-router-dom";
import { withStyles } from "@material-ui/core/styles";
import { connect } from "react-redux";

class MarketAccess extends Component {
  constructor(props) {
    super(props);
    this.state = {
      marketAccess: {},
      endPointValue: {},
      cardIndex: 0,
    };
  }

  componentDidMount() {
    const { resourceId } = this.props.signedInUser;
    this.props.getInputAdvisorTemplate(resourceId, this.props.projectId);
    const _endPointValue = this.props.endpoints.filter(
      (x) => x.id === this.props.objectiveData.endpoint[0].Endpoint
    );

    this.setState({
      endPointValue: _endPointValue,
    });
  }

  componentWillReceiveProps(nextProps) {
    // Any time props.inputAdvisorData changes, update state.

    const { cardIndex } = this.state;

    const { endPointValue } = this.state;

    if (nextProps.inputAdvisorData !== this.props.inputAdvisorData) {
      const objectValue = nextProps.inputAdvisorData.marketAccess;
      for (let i = 0; i < objectValue.length; i++) {
        if (!objectValue[i].annualRevenueInPeakYear) {
          objectValue[i].annualRevenueInPeakYear = "";
        }
        if (!objectValue[i].timeToPeakAnnualRevenue) {
          objectValue[i].timeToPeakAnnualRevenue = "";
        }
        if (!objectValue[i].proportionOfResidualSales) {
          objectValue[i].proportionOfResidualSales = "";
        }
        if (!objectValue[i].anticipatedTreatmentEffect) {
          objectValue[i].anticipatedTreatmentEffect = "";
        }
        if (!objectValue[i].timeToPatentExpiry) {
          objectValue[i].timeToPatentExpiry = "";
        }
        if (!objectValue[i].discountRate) {
          objectValue[i].discountRate = "";
        }
        if (!objectValue[i].endpointId) {
          objectValue[i].endpointId = "";
        }
      }
      if (endPointValue) {
        if (endPointValue[0]) {
          if (endPointValue[0].id) {
            nextProps.inputAdvisorData.marketAccess[cardIndex].endpointId =
              endPointValue[0].id;
          }
        }
      }
      this.setState({
        marketAccess: nextProps.inputAdvisorData.marketAccess[cardIndex],
      });
    }
  }

  componentWillUnmount = () => {
    let marketAccess = { ...this.state.marketAccess };
    const { endPointValue } = this.state;

    if (endPointValue) {
      if (endPointValue[0]) {
        marketAccess.endpointId = endPointValue[0].id;
      }
    }

    Object.keys(marketAccess).forEach((element) => {
      if (typeof marketAccess[element] !== "object") {
        if (
          marketAccess.error.filter((err) => err && err.field === element)
            .length === 0
        ) {
          const errorObj = this.formValidation(element, marketAccess[element]);
          errorObj &&
            Object.keys(errorObj).length &&
            marketAccess.error.push(
              this.formValidation(element, marketAccess[element])
            );
        }
      }
    });

    let marketAccessObj = [];
    marketAccessObj[0] = marketAccess;
    let _FinalinputAdvisorData = {};

    let _inputAdvisorData = { ...this.props.inputAdvisorData };

    _FinalinputAdvisorData.object = { ..._inputAdvisorData };
    _FinalinputAdvisorData.object.marketAccess.splice(
      0,
      _FinalinputAdvisorData.object.marketAccess.length,
      ...marketAccessObj
    );
    _FinalinputAdvisorData.createdBy = this.props.createdBy;
    _FinalinputAdvisorData.projectID = this.props.projectId;
    _FinalinputAdvisorData.resourceID = this.props.signedInUser.resourceId;

    // add market access data in DB
    const pageID = "Market Access";
    this.props.updateInputAdvisorDataDB(pageID, _FinalinputAdvisorData);

    //update inputAdvisorData at store level
    this.props.updateMarketAccessData(marketAccessObj);
  };

  isErrorField = (value) => {
    if (this.state.marketAccess) {
      return (
        this.state.marketAccess.error &&
        this.state.marketAccess.error.findIndex((ele) => ele.field === value) >
        0
      );
    }
  };

  isErrorFieldEndpoint = (value) => {
    const { marketAccess } = this.state;
    if (marketAccess) {
      if (!marketAccess.endpointId) {
        return (
          this.state.marketAccess.error &&
          this.state.marketAccess.error.findIndex(
            (ele) => ele.field === value
          ) > 0
        );
      }
    }
  };

  isErrorMessageEndpoint = (value) => {
    const { marketAccess } = this.state;
    if (marketAccess) {
      if (!marketAccess.endpointId) {
        const errorObj =
          this.state.marketAccess.error &&
          this.state.marketAccess.error.filter((ele) => ele.field === value);

        return errorObj && errorObj.length
          ? errorObj && errorObj[0].message
          : null;
      }
    }
  };

  isErrorMessage = (value) => {
    if (this.state.marketAccess) {
      const errorObj =
        this.state.marketAccess.error &&
        this.state.marketAccess.error.filter((ele) => ele.field === value);

      return errorObj && errorObj.length
        ? errorObj && errorObj[0].message
        : null;
    }
  };

  handleChangeEvent = (event) => {
    const { name, value } = event.target;
    this.clearErrorMessage(name);
    const {
      modelName,
      annualRevenueInPeakYear,
      timeToPeakAnnualRevenue,
      proportionOfResidualSales,
      anticipatedTreatmentEffect,
      timeToPatentExpiry,
      discountRate,
    } = MARKETACCESS.FIELDS;

    let valueWithoutSpecialChar = value.replace(/[_\W]+/g, "");
    const pattern = /^[0-9 ]+$/i;

    switch (name) {
      case modelName:
        name.length <= 75 &&
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: value,
              },
            };
          });
        break;

      case annualRevenueInPeakYear:
        const isValidAnnualRevenueInPeakYear = pattern.test(
          valueWithoutSpecialChar
        );
        if (isValidAnnualRevenueInPeakYear || valueWithoutSpecialChar === "") {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        }
        break;

      case timeToPeakAnnualRevenue:
        const isValidTimeToPeakAnnualRevenue = pattern.test(
          valueWithoutSpecialChar
        );
        if (isValidTimeToPeakAnnualRevenue || valueWithoutSpecialChar === "") {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        }
        break;

      case proportionOfResidualSales:
        const isValidProportionOfResidualSales = pattern.test(
          valueWithoutSpecialChar
        );
        if (valueWithoutSpecialChar === "") {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        } else if (
          isValidProportionOfResidualSales &&
          valueWithoutSpecialChar >= 0 &&
          valueWithoutSpecialChar <= 100
        ) {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        }
        break;

      case anticipatedTreatmentEffect:
        const isValidanticipatedTreatmentEffect = pattern.test(
          valueWithoutSpecialChar
        );
        if (
          isValidanticipatedTreatmentEffect ||
          valueWithoutSpecialChar === ""
        ) {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        }
        break;

      case timeToPatentExpiry:
        const isValidTimeToPatentExpiry = pattern.test(valueWithoutSpecialChar);
        if (isValidTimeToPatentExpiry || valueWithoutSpecialChar === "") {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        }
        break;

      case discountRate:
        const isValidDiscountRate = pattern.test(valueWithoutSpecialChar);
        if (valueWithoutSpecialChar === "") {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        } else if (
          isValidDiscountRate &&
          valueWithoutSpecialChar >= 0 &&
          valueWithoutSpecialChar <= 100
        ) {
          this.setState((state) => {
            const _marketAccess = { ...state.marketAccess };
            return {
              ...this.state,
              marketAccess: {
                ..._marketAccess,
                [name]: valueWithoutSpecialChar,
              },
            };
          });
        }
        break;

      default:
        break;
    }
  };

  handleBlurEvent = (event) => {
    const error = this.validateFieldOnBlur(event);
    if (error !== undefined) {
      this.updateErrorToState(error);
    } else {
      const { name, value } = event.target;
      const { annualRevenueInPeakYear } = MARKETACCESS.FIELDS;
      if (name === annualRevenueInPeakYear) {
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
                marketAccess: {
                  ...this.state.marketAccess,
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
                marketAccess: {
                  ...this.state.marketAccess,
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
    if (this.state.marketAccess) {
      const { field, message } = errorObj;
      const errors = [...this.state.marketAccess.error];
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
        marketAccess: { ...this.state.marketAccess, error: errors },
      });
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

  clearErrorMessage = (name) => {
    if (this.state.marketAccess) {
      let temp;
      let errors = [...this.state.marketAccess.error];
      const index = errors.findIndex((ele) => ele.field === name);
      if (index > 0) {
        temp = [...errors.filter((ele) => ele.field !== name)];
      }
      this.setState({
        ...this.state,
        marketAccess: {
          ...this.state.marketAccess,
          error: temp ? temp : errors,
        },
      });
    }
  };

  formValidation = (name, value) => {
    const { marketAccess } = this.state;
    if (name === "endpointId") {
      if (value.toString().trim().length > 0) {
        let index;
        if (marketAccess) {
          if (marketAccess.error) {
            index = marketAccess.error.findIndex(
              (ele) => ele.field === "Endpoint"
            );
            if (index !== -1) {
              marketAccess.error.splice(index, 1);
            }
          }
        }
      } else {
        return {
          field: "Endpoint",
          message: `${this.replaceKeyName(name)} is required`,
        };
      }
    } else {
      if (value.toString().trim().length === 0)
        return {
          field: name,
          message: `${this.replaceKeyName(name)} is required`,
        };
    }
  };
  replaceKeyName = (name) => {
    const {
      modelName,
      endpoint,
      annualRevenueInPeakYear,
      timeToPeakAnnualRevenue,
      proportionOfResidualSales,
      anticipatedTreatmentEffect,
      timeToPatentExpiry,
      discountRate,
    } = MARKETACCESS.FIELDS;

    switch (name) {
      case modelName: {
        return "Name";
      }
      case endpoint: {
        return "Endpoint";
      }
      case annualRevenueInPeakYear: {
        return "Annual Revenue in Peak Year";
      }
      case timeToPeakAnnualRevenue: {
        return "Time to Peak Annual Revenue (Yrs)";
      }
      case proportionOfResidualSales: {
        return "Proportion of Residual Sales (%)";
      }
      case anticipatedTreatmentEffect: {
        return "Anticipated Treatment Effect (HR)";
      }
      case timeToPatentExpiry: {
        return "Time to Patent Expiry (Yrs)";
      }
      case discountRate: {
        return "Discount Rate (%)";
      }
    }
  };

  render() {
    const { classes } = this.props;
    const { endPointValue } = this.state;

    let dropDownValue = "";
    if (this.props.objectiveData) {
      if (this.props.objectiveData.endpoint) {
        if (this.props.objectiveData.endpoint[0]) {
          dropDownValue = this.props.objectiveData.endpoint[0].Endpoint;
        }
      }
    }

    return (
      <Grid className={classes.root} id="Market Access">
        <Grid container>
          <Grid item md={12} className={classes.inputAdvisorHeader}>
            <Typography variant="h6">
              <FontAwesomeIcon
                id="marketAccessIcon"
                className={classes.inputAdvisorIcon}
                icon={faCabinetFiling}
              />
              {MARKETACCESS.TITLE}
            </Typography>
          </Grid>
          <Grid item md={12}>
            <MarketAccessModel
              modelDetails={this.state.marketAccess}
              handleChangeEvent={this.handleChangeEvent}
              handleBlur={(event) => this.handleBlurEvent(event)}
              setName="name"
              setEndpoint="Endpoint"
              setAnnualRevenueInPeakYear="annualRevenueInPeakYear"
              setTimeToPeakAnnualRevenue="timeToPeakAnnualRevenue"
              setProportionOfResidualSales="proportionOfResidualSales"
              setAnticipatedTreatmentEffect="anticipatedTreatmentEffect"
              setTimeToPatentExpiry="timeToPatentExpiry"
              setDiscountRate="discountRate"
              nameValid={this.isErrorField("name")}
              endpointValid={this.isErrorFieldEndpoint("Endpoint")}
              annualRevenueInPeakYearValid={this.isErrorField(
                "annualRevenueInPeakYear"
              )}
              timeToPeakAnnualRevenueValid={this.isErrorField(
                "timeToPeakAnnualRevenue"
              )}
              proportionOfResidualSalesValid={this.isErrorField(
                "proportionOfResidualSales"
              )}
              anticipatedTreatmentEffectValid={this.isErrorField(
                "anticipatedTreatmentEffect"
              )}
              timeToPatentExpiryValid={this.isErrorField("timeToPatentExpiry")}
              discountRateValid={this.isErrorField("discountRate")}
              nameHelperText={this.isErrorMessage("name")}
              endpointHelperText={this.isErrorMessageEndpoint("Endpoint")}
              annualRevenueInPeakYearHelperText={this.isErrorMessage(
                "annualRevenueInPeakYear"
              )}
              timeToPeakAnnualRevenueHelperText={this.isErrorMessage(
                "timeToPeakAnnualRevenue"
              )}
              proportionOfResidualSalesHelperText={this.isErrorMessage(
                "proportionOfResidualSales"
              )}
              anticipatedTreatmentEffectHelperText={this.isErrorMessage(
                "anticipatedTreatmentEffect"
              )}
              timeToPatentExpiryHelperText={this.isErrorMessage(
                "timeToPatentExpiry"
              )}
              discountRateHelperText={this.isErrorMessage("discountRate")}
              isEditMode={this.props.isEditMode}
              textToDisplay="name"
              valueToReturn="id"
              setEndpointControlValues={!endPointValue ? "" : endPointValue}
              dropdownSelectedValue={dropDownValue === "" ? "" : dropDownValue}
              nameTabIndex={1}
              endpointTabIndex={2}
              annualRevenueInPeakYearTabIndex={3}
              timeToPeakAnnualRevenueTabIndex={4}
              proportionOfResidualSalesTabIndex={5}
              anticipatedTreatmentEffect={6}
              timeToPatentExpiry={7}
              discountRate={8}
            />
          </Grid>
        </Grid>
      </Grid>
    );
  }
}

const mapDispatchToProps = (dispatch) => {
  return {
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
    updateMarketAccessData: (marketAccess) =>
      dispatch({
        type: "INPUT_ADVISOR_WITH_MARKETACCESS_DATA",
        payload: marketAccess,
      }),
  };
};

const mapStateToProps = (state) => {
  return {
    marketAccess: state.inputAdvisorReducer.marketAccess,
    projectTimeUnit: state.projectReducer.projectTimeUnit,
    inputAdvisorData: state.inputAdvisorReducer.inputAdvisorData,
    projectId: state.projectReducer.projectId,
    signedInUser: state.loginReducer.signedInUser,
    createdBy: state.projectReducer.createdBy,
    isEditMode: state.projectReducer.isEditMode,
    objectiveData: state.inputAdvisorReducer.inputAdvisorData.objective,
    endpoints: state.projectReducer.endpoints,
  };
};

MarketAccess = connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(withStyles(marketAccessStyle)(MarketAccess)));
export { MarketAccess };
