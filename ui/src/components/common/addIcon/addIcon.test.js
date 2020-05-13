import React from "react";
import { shallow } from "enzyme";
import { AddIcon } from "./AddIcon";
import { findById } from "../../../test/testUtils";

const setup = (props = {}) => {
    const setupProps = { ...props };
    return shallow(<AddIcon {...setupProps} />);
  };
  describe("add icon Component", () => {
    const wrapper = setup({});
    it("it should render with add icon", () => {
        const NewProjectIcon = findById(wrapper, "plusIcon");
        expect(NewProjectIcon.exists()).toBeTruthy();
      });
  });