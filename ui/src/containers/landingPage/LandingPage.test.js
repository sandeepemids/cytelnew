import React from "react";
import { shallow } from "enzyme";
import { LandingPage } from "./LandingPage";
import { findById, findBySelector } from "../../test/testUtils";
import { ProjectList } from "../../components/projectlist";
import { InputAdvisor } from "../inputAdvisor";
import { mountWithIntl } from "../../test/i18nHelper";
import { BrowserRouter as Router } from "react-router-dom";
import configureMockStore from "redux-mock-store";
import { Provider } from "react-redux";

const mockStore = configureMockStore();

const store = mockStore({
  projectReducer: {},
  loginReducer: {
    signedInUser: {},
  },
});

jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useLocation: () => ({
    pathname: "/landingpage/projects"
  })
}));

const setup = () => {
  const historyMock = jest.fn();
  return shallow(<LandingPage history={historyMock} />);
};

const setupWithIntl = () => {
  const historyMock = jest.fn();
  return mountWithIntl(
    <Provider store={store}>
      <Router history={historyMock}>
      <LandingPage history={historyMock} />
    </Router>
    </Provider>
)};

describe("LandingPage component", () => {
  const wrapper = setup({});
  it("should render with header component", () => {
    const HeaderElement = findById(wrapper, "header");
    expect(HeaderElement.exists()).toBeTruthy();
  });
  it("should render with breadcrumbBar component", () => {
    const BreadcrumbBarElement = findById(wrapper, "breadcrumbBar");
    expect(BreadcrumbBarElement.exists()).toBeTruthy();
  });
  it("should have 2 routes", () => {
    const Routes = wrapper.find("Route");
    expect(Routes.length).toBe(2);
  });
  it("Should renders correct component", () => {
    const pathMap = wrapper.find("Route").reduce((pathMap, route) => {
      const routeProps = route.props();
      if (routeProps.component) {
        pathMap[routeProps.path] = routeProps.component;
      } else if (routeProps.render) {
        pathMap[routeProps.path] = routeProps.render({}).type;
      }
      return pathMap;
    }, {});
    expect(pathMap["/landingpage/projects"]).toBe(ProjectList);
    expect(pathMap["/landingpage/input-advisor"]).toBe(InputAdvisor);
  });
  it("should render new project button", () => {
    const ProjectLabel = findById(wrapper, "newProjectButton");
    expect(ProjectLabel.exists()).toBeTruthy();
  });
});

describe("LandingPage component with Intl", () => {
  const wrapper = setupWithIntl({});
  
  it("should render new project button with text", () => {
    const component = findById(wrapper, "newProjectButton");
    const childComponent = findBySelector(component, 'FormattedMessage[id="landingPage.newProject"]');
    const text = childComponent.text();

    expect(text).toEqual("New Project");
  });
});
