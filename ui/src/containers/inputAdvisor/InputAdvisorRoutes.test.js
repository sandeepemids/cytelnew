import React from "react";
import { shallow } from "enzyme";
import InputAdvisorRoutes from "./InputAdvisorRoutes";
import { Objective } from "../../components/objective";
import { Population } from "../../components/population";
import { Enrollment } from "../../components/enrollment";
import { Setup } from "../../components/setup";
import { OperationalCosts } from "../../components/operationalCosts";
import { MarketAccess } from "../../components/marketAccess";
import { Designs } from "../../components/designs";
import { mountWithIntl } from "../../test/i18nHelper"
import { Router } from "react-router-dom";

const historyMock = { push: jest.fn(), location: {}, listen: jest.fn() };

describe("InputAdvisor Routes component", () => {
  const wrapper = shallow(<InputAdvisorRoutes />);
  const pathMap = wrapper.find("Route").reduce((pathMap, route) => {
    const routeProps = route.props();
    if (routeProps.component) {
      pathMap[routeProps.path] = routeProps.component;
    } else if (routeProps.render) {
      pathMap[routeProps.path] = routeProps.render({}).type;
    }
    return pathMap;
  }, {});

  it("Should renders correct routes", () => {
    expect(pathMap["/landingpage/input-advisor/population-scenarios"]).toBe(
      Population
    );
    expect(pathMap["/landingpage/input-advisor/enrollment-scenarios"]).toBe(
      Enrollment
    );
    expect(pathMap["/landingpage/input-advisor/operational-costs"]).toBe(
      OperationalCosts
    );
    expect(pathMap["/landingpage/input-advisor/setup"]).toBe(Setup);
    expect(pathMap["/landingpage/input-advisor/market-access"]).toBe(
      MarketAccess
    );
    expect(pathMap["/landingpage/input-advisor/designs"]).toBe(Designs);
  });
});

describe("InputAdvisor Routes component", () => {
  const wrapper = mountWithIntl(<Router history={historyMock}><InputAdvisorRoutes /></Router>);
  const pathMap = wrapper.find("Route").reduce((pathMap, route) => {
    const routeProps = route.props();
    
    if (routeProps.component) {
      pathMap[routeProps.path] = routeProps.component;
    } else if (routeProps.render) {
      pathMap[routeProps.path] = routeProps.render({}).type;
    }
    return pathMap;
  }, {});

  it("Should renders correct route for Objective", () => {
    expect(pathMap["/landingpage/input-advisor/objective"]).toBe(Objective);
  });
});
