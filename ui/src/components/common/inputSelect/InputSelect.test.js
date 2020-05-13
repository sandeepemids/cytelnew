import React from "react";
import { InputSelect } from "./InputSelect";
import { findById } from "../../../test/testUtils";
import { createMount } from "@material-ui/core/test-utils";

const defaultProps = {
  handleChange: jest.fn(),
  value: "select",
  valueToReturn: "value",
  textToDisplay: "value",
  name: "select",
  options: [],
};

describe("Input Select component", () => {
  let mount;
  let wrapper;

  beforeEach(() => {
    mount = createMount();
  });

  it("Should render select component", () => {
    const props = {
      name: "inputSelect",
      options: [{ id: 1, name: "Value 1" }],
    };
    const setupProps = { ...defaultProps, ...props };
    wrapper = mount(<InputSelect {...setupProps} />);
    const selectElement = findById(wrapper, "inputSelect");
    expect(selectElement.exists()).toBeTruthy();
  });
});
