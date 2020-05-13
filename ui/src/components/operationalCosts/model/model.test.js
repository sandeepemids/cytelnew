import React from "react";
import { shallow, mount } from "enzyme";
import { findById } from "../../test/testUtils";
import { Router } from "react-router-dom";
import { Model } from "./Model";

const setup = (props = {}) => {
  const setupProps = { ...props };
  const historyMock = { push: jest.fn(), location: {}, listen: jest.fn() };

  return mount(
    <Router history={historyMock}>
      <Model {...setupProps} />
    </Router>
  );
};

describe("Model component", () => {
  const wrapper = setup({});

  it("Should render 'nameId' input element", () => {
    const TargetElement = findById(wrapper, "nameId");
    expect(TargetElement.exists()).toBeTruthy();
  });

  it("Should render 'costPerPatientId' input element", () => {
    const TreatmentElement = findById(wrapper, "costPerPatientId");
    expect(TreatmentElement.exists()).toBeTruthy();
  });

  it("Should render 'fixedCostId' input element", () => {
    const ControlElement = findById(wrapper, "fixedCostId");
    expect(ControlElement.exists()).toBeTruthy();
  });

  it("Should render 'interimLookCostId' input element", () => {
    const ControlElement = findById(wrapper, "interimLookCostId");
    expect(ControlElement.exists()).toBeTruthy();
  });
});
