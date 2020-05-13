import React from "react";
import { shallow } from "enzyme";
import { FabIcon } from "./FabIcon";
import { findById } from "../../../test/testUtils";

const setup = component => {
  return shallow(component);
};

describe("Fab icon component", () => {
  let wrapper;

  beforeEach(() => {
    wrapper = setup(<FabIcon />);
  });

  it("should render without  error", () => {
    const component = findById(wrapper, "fab-icon");
    expect(component.exists()).toBeTruthy();
  });

  it("should have plus button", () => {
    const plusIcon = findById(wrapper, "plus-button");
    expect(plusIcon.exists()).toBeTruthy();
  });
});
