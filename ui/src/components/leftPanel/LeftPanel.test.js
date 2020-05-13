import React from "react";
import { LeftPanel } from "./LeftPanel";
import { Router } from "react-router-dom";
import { mountWithIntl } from "../../test/i18nHelper";
import { createMount } from "@material-ui/core/test-utils";
import LEFTPANEL from "./constants";
import configureMockStore from "redux-mock-store";
import { Provider } from "react-redux";
import { findBySelector } from "../../test/testUtils"

import {
  faCabinetFiling,
  faCog,
  faFileInvoiceDollar,
  faTasksAlt,
  faClipboardList,
  faUserFriends,
  faClipboardCheck,
  faLayerGroup
} from "@fortawesome/pro-regular-svg-icons";

const mockStore = configureMockStore();

const store = mockStore({
  projectReducer: {},
  loginReducer: {
    signedInUser: {},
  },
  inputAdvisorReducer: {
    inputAdvisorData: {}
  }
});

const mockIcons = [
  "clipboard-check",
  "user-friends",
  "clipboard-list",
  "tasks-alt",
  "file-invoice-dollar",
  "cabinet-filing",
  "cog",
  "layer-group"
];

const menuList = [
  { id: "leftPanel.objective", name: "Objective", icon: faClipboardCheck },
  { id: "leftPanel.populationScenarios", name: "Population Scenarios", icon: faUserFriends },
  { id: "leftPanel.enrollmentScenarios", name: "Enrollment Scenarios", icon: faClipboardList},
  { id: "leftPanel.designs", name: "Designs", icon: faTasksAlt },
  { id: "leftPanel.operationalCosts", name: "Operational Costs", icon: faFileInvoiceDollar },
  { id: "leftPanel.marketAccess", name: "Market Access", icon: faCabinetFiling },
  { id: "leftPanel.setup", name: "Setup", icon: faCog },
  { id: "leftPanel.simulationModels", name: "Simulation Models", icon: faLayerGroup },
];

const mockMenuNames = [
  "Objective",
  "Population Scenarios",
  "Enrollment Scenarios",
  "Designs",
  "Operational Costs",
  "Market Access",
  "Setup",
  "Simulation Models",
];

describe("Left Panel component", () => {
  let mount;
  let wrapper;
  const activeTabIconClass = "makeStyles-activeIcon";

  beforeEach(() => {
    mount = createMount();
  });
  afterEach(() => {
    mount.cleanUp();
  });

  it("Should render menu names as passed with Intl", () => {
    const historyMock = { push: jest.fn(), location: {}, listen: jest.fn() };
    wrapper = mountWithIntl(
      <Provider store={store}>
        <Router history={historyMock}>
          <LeftPanel menuList={menuList} />
        </Router>
      </Provider>
    );

    const menuNames = findBySelector(wrapper, "FormattedMessage").reduce((menuNames, item) => {
      menuNames.push(item.text());
      return menuNames;
    }, []);

    expect(menuNames).toEqual(mockMenuNames);
  });
  it("Should render icons as passed", () => {
    const historyMock = { push: jest.fn(), location: {}, listen: jest.fn() };
    wrapper = mountWithIntl(
      <Provider store={store}>
        <Router history={historyMock}>
          <LeftPanel menuList={menuList} />
        </Router>
      </Provider>
    );
    const icons = wrapper.find("FontAwesomeIcon").reduce((icons, item) => {
      const itemMap = item.props();
      icons.push(itemMap.icon.iconName);
      return icons;
    }, []);
    expect(icons).toEqual(mockIcons);
  });
  it("Should show 'Objective' as a active menu", () => {
    const historyMock = { push: jest.fn(), location: {}, listen: jest.fn() };
    wrapper = mountWithIntl(
      <Provider store={store}>
        <Router history={historyMock}>
          <LeftPanel menuList={menuList} activeTab={LEFTPANEL.DEFAULTMENUITEM} />
        </Router>
      </Provider>
    );
    expect(wrapper.find("FontAwesomeIcon").at(0).prop("className")).toContain(activeTabIconClass);
  });
  it("click on 'objective' menu link", () => {
    const historyMock = {
      push: jest.fn(() => {
        return "/landingpage/input-advisor/objective";
      }),
      location: {},
      listen: jest.fn(),
    };
    const mockHandle = jest.fn(() => {
      return "/landingpage/input-advisor/objective";
    });

    <Provider store={store}>
        <Router history={historyMock}>
        <LeftPanel menuList={menuList} activeTab={LEFTPANEL.DEFAULTMENUITEM} />
        </Router>
    </Provider>
    
    const menuItemElement = wrapper.find("li").at(0);
    wrapper.setProps("onClick", mockHandle);
    menuItemElement.simulate("click", { url: "", name: "" });
    expect(mockHandle.mock.results[0]["value"]).toBe(
      "/landingpage/input-advisor/objective"
    );
    expect(mockHandle.mock.calls.length).toBe(1);
  });
});
