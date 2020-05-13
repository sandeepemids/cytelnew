import React from "react";
import { mount, shallow } from "enzyme";
import { Login } from "./Login";
import { BrowserRouter as Router } from "react-router-dom";

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

const mockDispatch = jest.fn();
jest.mock("react-redux", () => ({
  useSelector: jest.fn(() => {
    return 10;
  }),
  useDispatch: () => mockDispatch,
}));

const setup = () => {
  const historyMock = jest.fn();
  return shallow(<Login history={historyMock} />);
};

describe("Login component", () => {
  const wrapper = setup();
  it("should render email textbox", () => {
    const EmailElement = wrapper.find('InputText[id="email"]');
    expect(EmailElement.exists()).toBeTruthy();
  });
  it("should render password textbox", () => {
    const PasswordElement = wrapper.find('InputText[id="password"]');
    expect(PasswordElement.exists()).toBeTruthy();
  });
  it("should render button to login", () => {
    const btnLoginElement = wrapper.find('[id="btnLogin"]');
    expect(btnLoginElement.exists()).toBeTruthy();
  });
  it("should redirect to landing page onclick of login", () => {
    const history = ["/landingpage/projects"];
    const btnLoginElement = wrapper.find('[id="btnLogin"]');
    btnLoginElement.simulate("click");

    expect(btnLoginElement.exists()).toBeTruthy();
  });
  it("should render error Typography", () => {
    const ValidationElement = wrapper.find('[id="signInValidationMsg"]');
    expect(ValidationElement.length).toBe(1);
  });
});
