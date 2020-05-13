import React from "react";
import { shallow } from "enzyme";
import { InputAdvisor } from "./InputAdvisor";
import { findById } from "../../test/testUtils";

const setup = (props = {}) => {
  const setupProps = { ...props };
  return shallow(<InputAdvisor {...setupProps} />);
};

describe("Input Advisor component", () => {
  const wrapper = setup({});

  it("Should render Input Advisor Component", () => {
    const InputAdvisor = findById(wrapper, "input-advisor");
    expect(InputAdvisor.exists()).toBeTruthy();
  });

  it("Should render input advisor menubar", () => {
    const InputAdvisorMenu = findById(wrapper, "menu");
    expect(InputAdvisorMenu.exists()).toBeTruthy();
  });

  it("Should render input advisor nested routes", () => {
    const InputAdvisorRoutes = findById(wrapper, "inputadvisor-routes");
    expect(InputAdvisorRoutes.exists()).toBeTruthy();
  });
});
