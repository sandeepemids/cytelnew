import React from "react";
import { shallow } from "enzyme";
import { Header } from "./Header";
import { findById } from "../../test/testUtils";

jest.mock("react-router-dom", () => ({
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
  return shallow(<Header history={historyMock} />);
};

describe("Header component", () => {
  const wrapper = setup({});

  it("should render with given id", () => {
    const CytelLogoElement = findById(wrapper, "cytelLogo");
    expect(CytelLogoElement.exists()).toBeTruthy();
  });

  it("should render with given id", () => {
    const ProductNameElement = findById(wrapper, "productName");
    expect(ProductNameElement.text()).toEqual("Solaris");
    expect(ProductNameElement.exists()).toBeTruthy();
  });

  it("should render with given id", () => {
    const AvatarElement = findById(wrapper, "avatar");
    expect(AvatarElement.exists()).toBeTruthy();
  });
});
