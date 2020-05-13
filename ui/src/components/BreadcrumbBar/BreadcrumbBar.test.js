import React from "react";
import { BreadcrumbBar } from "./BreadcrumbBar";
import { findById, findBySelector } from "../../test/testUtils";
import { mountWithIntl } from '../../test/i18nHelper';

jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useLocation: () => ({
    pathname: "/landingpage/projects"
  }),
  useHistory: () => ({
    push: jest.fn(),
    location: {
      state: {
        push: jest.fn().mockReturnValue("/landingpage/projects"),
      },
    },
    listen: jest.fn(),
  }),
}));

const setup = () => {
  const historyMock = jest.fn();
  return mountWithIntl(<BreadcrumbBar history={historyMock} />);
};

describe("BreadcrumbBar component with Intl", () => {
  const wrapper = setup({});

  it("should render 'breadcrumbBar' component", () => {
    const component = findById(wrapper, "breadcrumbs");
    const childComponent = findById(component, "projectsHeader");
    
    expect(component.exists()).toBeTruthy();
    expect(childComponent.exists()).toBeTruthy();
  });

  it("should render 'breadcrumbBar' component with header as 'Projects'", () => {
    const component = findById(wrapper, "breadcrumbs");
    const childComponent = findById(component, "projectsHeader");
    const text = findBySelector(childComponent, "h6[id='projectsHeader']").text();
    
    expect(text).toEqual("Projects");
  });
});
