import React, { useEffect } from "react";
import MenuList from "@material-ui/core/MenuList";
import MenuItem from "@material-ui/core/MenuItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import leftPanelStyle from "./leftPanelStyle";
import { useHistory } from "react-router-dom";
import { useState } from "react";
import LEFTPANEL from "./constants";
import { useSelector, useDispatch } from "react-redux";
import { FormattedMessage } from "react-intl"

function LeftPanel(props) {
  const _inputAdvisorData = useSelector(
    (state) => state.inputAdvisorReducer.inputAdvisorData
  );
  const [objectiveErrorObjFlag, setObjectiveErrorObjFlag] = useState({
    tanName: "Objective",
    errorStatus: false,
  });
  const [
    operationalCostErrorObjFlag,
    setOperationalCostErrorObjFlag,
  ] = useState({
    tanName: "Operational Costs",
    errorStatus: false,
  });
  const [populationErrorObjFlag, setPopulationErrorObjFlag] = useState({
    tabName: "Population Scenarios",
    errorStatus: false,
  });
  const [marketAccessErrorObjFlag, setMarketAccessErrorObjFlag] = useState({
    tanName: "Market Access",
    errorStatus: false,
  });

  const history = useHistory();
  const dispatch = useDispatch();
  const { menuList } = props;
  const [activeTab, setActiveTab] = useState(LEFTPANEL.DEFAULTMENUITEM);
  const classes = leftPanelStyle();
  const handleMenuItemClick = (item) => {
    displayErrorIcon(item);
    history.push(`${item.url}`);
    setActiveTab(item.name);
  };

  useEffect(() => {
    checkErrorObjective();
  }, [_inputAdvisorData && _inputAdvisorData.objective, _inputAdvisorData]);

  useEffect(() => {
    checkErrorOperationalCosts();
  }, [
    _inputAdvisorData && _inputAdvisorData.operationalCost,
    _inputAdvisorData,
  ]);

  useEffect(() => {
    checkErrorPopulationScenario();
  }, [_inputAdvisorData && _inputAdvisorData.population, _inputAdvisorData]);

  useEffect(() => {
    checkErrorMarketAccess();
  }, [_inputAdvisorData && _inputAdvisorData.marketAccess, _inputAdvisorData]);

  const checkErrorObjective = () => {
    let _displayErrors =
      (_inputAdvisorData.objective &&
        _inputAdvisorData.objective.error.length > 1) ||
      (_inputAdvisorData.objective &&
        _inputAdvisorData.objective.endpoint[0].error.length > 1);

    setObjectiveErrorObjFlag({
      tabName: "Objective",
      errorStatus: _displayErrors,
    });
  };

  const checkErrorOperationalCosts = () => {
    let _displayErrors =
      _inputAdvisorData.operationalCost &&
      _inputAdvisorData.operationalCost[0].error.length > 1;

    setOperationalCostErrorObjFlag({
      tabName: "Operational Costs",
      errorStatus: _displayErrors,
    });
  };

  const checkErrorPopulationScenario = () => {
    const isError =
      _inputAdvisorData.population[0].error.length > 1 ||
      _inputAdvisorData.population[0].endpointModel[0].error.length > 1 ||
      _inputAdvisorData.population[0].dropoutRateModel.error.length > 1;

    setPopulationErrorObjFlag({
      tabName: "Population Scenarios",
      errorStatus: isError,
    });
  };

  const checkErrorMarketAccess = () => {
    let _displayErrors =
      _inputAdvisorData.marketAccess &&
      _inputAdvisorData.marketAccess[0].error.length > 1;

    setMarketAccessErrorObjFlag({
      tabName: "Market Access",
      errorStatus: _displayErrors,
    });
  };

  useEffect(() => {
    checkErrorObjective();
  }, [_inputAdvisorData && _inputAdvisorData.objective, _inputAdvisorData]);

  const errorMessageIcon = (item) => {
    return (
      <ListItemIcon className={classes.errorIcon}>
        <FontAwesomeIcon
          title="You must fill in all of the fields. Please check."
          className={`${classes.errorIcon}`}
          icon={item.errorIcon}
        />
      </ListItemIcon>
    );
  };

  const displayErrorIcon = (item) => {
    if (
      objectiveErrorObjFlag.errorStatus &&
      objectiveErrorObjFlag.tabName === item.name
    ) {
      return errorMessageIcon(item);
    } else if (
      operationalCostErrorObjFlag.errorStatus &&
      operationalCostErrorObjFlag.tabName === item.name
    ) {
      return errorMessageIcon(item);
    } else if (
      populationErrorObjFlag.errorStatus &&
      populationErrorObjFlag.tabName === item.name
    ) {
      return errorMessageIcon(item);
    } else if (
      marketAccessErrorObjFlag.errorStatus &&
      marketAccessErrorObjFlag.tabName === item.name
    ) {
      return errorMessageIcon(item);
    }
  };

  return (
    <MenuList className={classes.root}>
      {menuList.map((item) => (
        <MenuItem
          key={item.name}
          className={activeTab === item.name ? `${classes.active}` : ""}
          onClick={() => handleMenuItemClick(item)}
        >
          <ListItemIcon>
            <FontAwesomeIcon
              className={activeTab === item.name ? `${classes.activeIcon}` : ""}
              icon={item.icon}
            />
          </ListItemIcon>
          <FormattedMessage id={item.id}></FormattedMessage>
          {displayErrorIcon(item)}
        </MenuItem>
      ))}
    </MenuList>
  );
}
LeftPanel.defaultProps = {
  menuList: [],
  activeTab: "Objective",
};
export { LeftPanel };
