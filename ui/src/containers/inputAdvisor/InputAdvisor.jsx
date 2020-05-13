import React from "react";
import Grid from "@material-ui/core/Grid";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import inputAdvisorStyle from "./inputAdvisorStyle";
import InputAdvisorRoutes from "./InputAdvisorRoutes";
import { LeftPanel } from "../../components/leftPanel";
import { faCabinetFiling } from "@fortawesome/pro-regular-svg-icons";
import { faCog } from "@fortawesome/pro-regular-svg-icons";
import { faReceipt } from "@fortawesome/pro-regular-svg-icons";
import { faTasks } from "@fortawesome/pro-regular-svg-icons";
import { faGlobe } from "@fortawesome/pro-regular-svg-icons";
import { faUserFriends } from "@fortawesome/pro-regular-svg-icons";
import { faClipboardCheck } from "@fortawesome/pro-regular-svg-icons";
import { faLayerGroup } from "@fortawesome/pro-regular-svg-icons";
import { faExclamationCircle } from "@fortawesome/pro-regular-svg-icons";

const menuList = [
  {
    id: "leftPanel.objective",
    name: "Objective",
    icon: faClipboardCheck,
    url: "/landingpage/input-advisor/objective",
    errorIcon: faExclamationCircle,
  },
  {
    id: "leftPanel.populationScenarios",
    name: "Population Scenarios",
    icon: faUserFriends,
    url: "/landingpage/input-advisor/population-scenarios",
    errorIcon: faExclamationCircle,
  },
  {
    id: "leftPanel.enrollmentScenarios",
    name: "Enrollment Scenarios",
    icon: faGlobe,
    url: "/landingpage/input-advisor/enrollment-scenarios",
    errorIcon: faExclamationCircle,
  },
  {
    id: "leftPanel.designs",
    name: "Designs",
    icon: faTasks,
    url: "/landingpage/input-advisor/designs",
    errorIcon: faExclamationCircle,
  },
  {
    id: "leftPanel.operationalCosts",
    name: "Operational Costs",
    icon: faReceipt,
    url: "/landingpage/input-advisor/operational-costs",
    errorIcon: faExclamationCircle,
  },
  {
    id: "leftPanel.marketAccess",
    name: "Market Access",
    icon: faCabinetFiling,
    url: "/landingpage/input-advisor/market-access",
    errorIcon: faExclamationCircle,
  },
  {
    id: "leftPanel.setup",
    name: "Setup",
    icon: faCog,
    url: "/landingpage/input-advisor/setup",
    errorIcon: faExclamationCircle,
  },
  {
    id: "leftPanel.simulationModels",
    name: "Simulation Models",
    icon: faLayerGroup,
    url: "/landingpage/input-advisor/simulation-models",
    errorIcon: faExclamationCircle,
  },
];

function InputAdvisor() {
  const classes = inputAdvisorStyle();

  return (
    <Card>
      <CardContent className={classes.root} id="input-advisor">
        <Grid container>
          <Grid className={classes.leftpanel} item xs={12} sm={3} md={3}>
            <LeftPanel id="menu" menuList={menuList} />
          </Grid>
          <Grid className="rightpanel" item xs={12} sm={9} md={9}>
            <InputAdvisorRoutes id="inputadvisor-routes" />
          </Grid>
        </Grid>
      </CardContent>
    </Card>
  );
}

export { InputAdvisor };
