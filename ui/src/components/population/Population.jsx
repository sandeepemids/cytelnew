import React, { Component } from "react";
import Grid from "@material-ui/core/Grid";
import populationStyle from "./populationStyle";
import { withRouter } from "react-router-dom";
import { faUserFriends } from "@fortawesome/pro-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { withStyles } from "@material-ui/core/styles";
import { Typography } from "@material-ui/core";
import { Scenario } from "./scenario";
import { connect } from "react-redux";
import POPULATION from "./constants";

class Population extends Component {
  constructor(props) {
    super(props);
    const endPointName = this.props.endPointName;
    const populationObj = this.props.inputAdvisorData.population;
    this.state = {
      tabs: [endPointName || "Endpoint", "Dropout Rate"],
      populationObj: populationObj,
      cardIndex: 0,
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleError = this.handleError.bind(this);
  }

  componentWillUnmount() {
    const cardIndex = this.state.cardIndex;
    const pageID = "population-scenarios";
    const { createdBy, projectId } = this.props.currentProject || {};
    const { resourceId } = this.props.signedInUser || {};

    const object = {
      ...this.props.inputAdvisorData,
      population: [...this.state.populationObj],
    };

    !object.population[cardIndex].name &&
      object.population[cardIndex].error.findIndex(
        (item) => item.field === "name"
      ) === -1 &&
      object.population[cardIndex].error.push({
        field: "name",
        message: "Name is required",
      });

    const _finalInputAdvisor = {
      object,
      createdBy,
      projectID: projectId,
      resourceID: resourceId,
    };
    this.props.updateInputAdvisorDataDB(pageID, _finalInputAdvisor);
  }

  handleInputChange(type, value) {
    const {
      name,
      virtualPopulationSize,
      control,
      hazardRatio,
      byTime,
      dropOutControl,
      dropOutTreatment,
    } = POPULATION.FIELDS;
    const { cardIndex } = this.state;
    const populationObj = [...this.state.populationObj];

    switch (type) {
      case name:
        const isValidName = value.length <= 75;
        isValidName && (populationObj[cardIndex][type] = value);
        this.setState({ populationObj });
        break;

      case virtualPopulationSize:
        const pattern = /^[0-9]+$/i;
        const isValidVirtualPopulationSize = pattern.test(value) && value >= 1;
        (isValidVirtualPopulationSize || value === "") &&
          (populationObj[cardIndex][type] = value);
        this.setState({ populationObj });
        break;

      case control:
      case hazardRatio:
        populationObj[cardIndex].endpointModel[0][type] = value;
        this.setState({ populationObj });
        break;

      case byTime:
        populationObj[cardIndex].dropoutRateModel[type] = value;
        this.setState({ populationObj });
        break;

      case dropOutControl:
        populationObj[cardIndex].dropoutRateModel.control = value;
        this.setState({ populationObj });
        break;

      case dropOutTreatment:
        populationObj[cardIndex].dropoutRateModel.treatment = value;
        this.setState({ populationObj });
        break;

      default:
        break;
    }
  }

  handleError(field, message, isScenario, isEndPointObj, isDropOutObj) {
    const { cardIndex } = this.state;
    const populationObj = [...this.state.populationObj];
    let errorIndex;

    isScenario &&
      (errorIndex = populationObj[cardIndex].error.findIndex(
        (item) => item.field === field
      ));

    isEndPointObj &&
      (errorIndex = populationObj[cardIndex].endpointModel[0].error.findIndex(
        (item) => item.field === field
      ));

    isDropOutObj &&
      (errorIndex = populationObj[cardIndex].dropoutRateModel.error.findIndex(
        (item) => item.field === field
      ));

    if (errorIndex === -1 && message) {
      isScenario && populationObj[cardIndex].error.push({ field, message });
      isEndPointObj &&
        populationObj[cardIndex].endpointModel[0].error.push({
          field,
          message,
        });
      isDropOutObj &&
        populationObj[cardIndex].dropoutRateModel.error.push({
          field,
          message,
        });
      this.setState({ populationObj });
    } else if (errorIndex >= 0 && !message) {
      isScenario && populationObj[cardIndex].error.splice(errorIndex, 1);
      isEndPointObj &&
        populationObj[cardIndex].endpointModel[0].error.splice(errorIndex, 1);
      isDropOutObj &&
        populationObj[cardIndex].dropoutRateModel.error.splice(errorIndex, 1);
      this.setState({ populationObj });
    } else if (errorIndex >= 0 && message) {
      isScenario &&
        populationObj[cardIndex].error.splice(errorIndex, 1, {
          field,
          message,
        });
      isEndPointObj &&
        populationObj[cardIndex].endpointModel[0].error.splice(errorIndex, 1, {
          field,
          message,
        });
      isDropOutObj &&
        populationObj[cardIndex].dropoutRateModel.error.splice(errorIndex, 1, {
          field,
          message,
        });
      this.setState({ populationObj });
    }
  }

  render() {
    const { classes } = this.props;
    const { tabs, populationObj } = this.state;

    return (
      <Grid className={classes.root} id="objective">
        <Grid container className={classes.inputAdvisorHeader}>
          <Grid item md={12} sm={12}>
            <FontAwesomeIcon
              id="objectiveIcon"
              className={classes.inputAdvisorIcon}
              icon={faUserFriends}
            />
            <Typography component="span" variant="h6">
              Population
            </Typography>
          </Grid>
        </Grid>
        <Scenario
          handleInputChange={this.handleInputChange}
          handleError={this.handleError}
          populationObj={populationObj}
          error={populationObj && populationObj[0]}
          tabs={tabs}
        />
      </Grid>
    );
  }
}

const mapDispatchToProps = (dispatch) => {
  return {
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
    inputAdvisorData: state.inputAdvisorReducer.inputAdvisorData,
    currentProject: state.projectReducer.currentProject,
    signedInUser: state.loginReducer.signedInUser,
    endPointName:
      state.inputAdvisorReducer.inputAdvisorData.objective &&
      state.inputAdvisorReducer.inputAdvisorData.objective.endpoint[0].Name,
  };
};

Population = connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(withStyles(populationStyle)(Population)));

Population.defaultProps = {
  populationObj: [{}],
};
export { Population };
