import React from "react";
import { CreateProgram } from "./CreateProgram";
import { findById } from "../../../test/testUtils";
import { createMount } from "@material-ui/core/test-utils";

const defaultProps = {
  options: [],
  name: "auto-complete-with-free-text",
  textToDisplay: "value",
  handleChange: jest.fn(),
  id: "create-program",
  name: "createProgram",
  textToDisplay: "value",
  valueToReturn: "id",
};

describe("Create program component", () => {
  let mount;
  let wrapper;

  beforeEach(() => {
    mount = createMount();
  });

  it("Should render create program component", () => {
    const props = {
      id: "createProgram",
      name: "create-program",
      options: [{ id: 1, name: "Value 1" }],
    };
    const setupProps = { ...defaultProps, ...props };
    wrapper = mount(<CreateProgram {...setupProps} />);
    const selectElement = findById(wrapper, "createProgram");
    expect(selectElement.exists()).toBeTruthy();
  });
});
