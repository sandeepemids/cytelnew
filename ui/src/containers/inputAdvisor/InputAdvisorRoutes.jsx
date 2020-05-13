import React from "react";
import { Switch, Route } from "react-router-dom";
import Objective from "../../components/objective/Objective";
import { Enrollment } from "../../components/enrollment";
import { Population } from "../../components/population";
import { Setup } from "../../components/setup";
import { Designs } from "../../components/designs";
import { OperationalCosts } from "../../components/operationalCosts";
import { MarketAccess } from "../../components/marketAccess";
import { SimulationModels } from "../../components/simulationModels";

export default function InputAdvisorRoutes() {
  return (
    <Switch>
      <Route
        exact
        path={`/landingpage/input-advisor/`}
        render={() => <Objective />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/objective`}
        render={() => <Objective />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/population-scenarios`}
        render={() => <Population />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/enrollment-scenarios`}
        render={() => <Enrollment />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/designs`}
        render={() => <Designs />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/operational-costs`}
        render={() => <OperationalCosts />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/market-access`}
        render={() => <MarketAccess />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/setup`}
        render={() => <Setup />}
      />
      <Route
        exact
        path={`/landingpage/input-advisor/simulation-models`}
        render={() => <SimulationModels />}
      />
    </Switch>
  );
}
