import React from "react";
import { shallow, mount } from "enzyme";
import { findById } from "../../test/testUtils";
import { Router } from "react-router-dom";
import { OperationalCosts } from "./OperationalCosts";

const setup = (props = {}) => {
  const setupProps = { ...props };
  const historyMock = { push: jest.fn(), location: {}, listen: jest.fn() };

  return mount(
    <Router history={historyMock}>
      <OperationalCosts {...setupProps} />
    </Router>
  );
};

describe("Objective component", () => {
  const wrapper = setup({});

  it("Should render Input Advisor - Opearational Costs Component", () => {
    const OperationalCostsComponent = findById(wrapper, "operational-costs");
    expect(OperationalCostsComponent.exists()).toBeTruthy();
  });

  it("Should render Objective icon", () => {
    const OperationalCostsIcon = findById(wrapper, "operationalCostsIcon");
    expect(OperationalCostsIcon.exists()).toBeTruthy();
  });
});
