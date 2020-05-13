import React from "react";
import { shallow } from "enzyme";
import { InputText } from "./InputText";
import { findById } from "../../../test/testUtils";

const defaultProps = {
  error: false,
  autoComplete: "off",
  helperText: "",
  value: "",
  label: "Default Label",
  type: "test"
};

const setup = (props = {}) => {
  const setupProps = { ...defaultProps, ...props };
  return shallow(<InputText {...setupProps} />);
};

describe("InputText component", () => {
  const wrapper = setup({ id: "email" });

  it("should render with given id", () => {
    const component = findById(wrapper, "email");
    expect(component.exists()).toBeTruthy();
  });
});
