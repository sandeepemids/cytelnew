import React from "react";
import { shallow } from "enzyme";
import Routes from "./Routes";
import { Login } from "./components/login";
import { LandingPage } from "./containers/landingPage";

describe("Routes component", () => {
  const wrapper = shallow(<Routes />);
  const pathMap = wrapper.find("Route").reduce((pathMap, route) => {
    const routeProps = route.props();
    if (routeProps.component) {
      pathMap[routeProps.path] = routeProps.component;
    } else if (routeProps.render) {
      pathMap[routeProps.path] = routeProps.render({}).type;
    }
    return pathMap;
  }, {});

  it("Should renders login component", () => {
    expect(pathMap["/login"]).toBe(Login);
  });

  it("Should renders landingpage component", () => {
    expect(pathMap["/landingpage"]).toBe(LandingPage);
  });

  it("Should redirect undefined routes to login page", () => {
    expect(pathMap["undefined"]).toBe(Login);
  });
});
