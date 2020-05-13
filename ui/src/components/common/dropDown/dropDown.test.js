import React from "react";
import { shallow, mount } from "enzyme";
import { DropDown } from "./DropDown";
import { findById } from "./../../../test/testUtils";

const defaultProps = {
  label: "Default Label",
  id: "no-id",
  data: [],
};

const setup = (
  props = {
    label: "projectStatus",
    id: "projectStatus",
  }
) => {
  const setupProps = { ...props };
  return shallow(<DropDown {...setupProps} />);
};

describe("Dropdown component", () => {
  const mockProps = {
    handleChange: jest.fn(),
  };
  let mockFunc, wrapper;
  beforeEach(() => {
    mockFunc = jest.fn();
    const props = {
      label: "projectStatus",
      id: "projectStatus",
      handleUpdate: mockFunc,
    };
    wrapper = shallow(<DropDown {...props} />);
  });

  afterEach(() => {
    mockProps.handleChange.mockReset();
  });

  it("should render projectStatus dropdown", () => {
    const projectStatusElement = findById(wrapper, "projectStatus");
    expect(projectStatusElement.exists()).toBeTruthy();
  });
  it("should render projectStatus dropdown with value 0", () => {
    const projectStatusElement = findById(wrapper, "projectStatus");
    expect(projectStatusElement.prop("value")).toBe(0);
  });
  it("should render projectStatus dropdown with label is projectStatus", () => {
    const projectStatusElement = findById(wrapper, "projectStatus");
    expect(projectStatusElement.prop("labelId")).toBe("projectStatus");
  });

  it("Triggering on change event", () => {
    const button = findById(wrapper, "projectStatus");
    button.simulate("change");
    const callback = mockFunc.mock.calls.length;
    expect(callback).toBe(1);
  });
});
