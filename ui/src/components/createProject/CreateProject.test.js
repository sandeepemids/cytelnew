import React from "react";
import { CreateProject } from "./CreateProject";
import { Provider } from "react-redux";
import configureMockStore from "redux-mock-store";
import { BrowserRouter as Router } from "react-router-dom";
import { findById, findBySelector } from "../../test/testUtils";
import { mountWithIntl } from "../../test/i18nHelper";

const mockStore = configureMockStore();
const historyMock = { push: jest.fn() };

jest.mock("axios");
const store = mockStore({
  projectReducer: {},
  loginReducer: {
    signedInUser: {},
  },
});

const setup = (props = {}) => {
  const setupProps = { ...props };
  return mountWithIntl(
    <Provider store={store}>
      <Router history={historyMock}>
        <CreateProject {...setupProps} />
      </Router>
    </Provider>
  );
};

describe("Create project dailog", () => {
  const wrapper = setup({ isModelOpen: false });
  it("should not be open", () => {
    const dailogHeader = findById(wrapper, "createProjectHeader");
    expect(dailogHeader.exists()).toBeFalsy();
  });
});

describe("Create project dailog", () => {
  const wrapper = setup({ isModelOpen: true });
  it("should be open", () => {
    const dailogHeader = findById(wrapper, "createProjectHeader");
    expect(dailogHeader.exists()).toBeTruthy();
  });
  it("should render 'program name' textbox", () => {
    const projectName = findById(wrapper, "projectName");
    expect(projectName.exists()).toBeTruthy();
  });
  it("should render 'protocol id' textbox", () => {
    const protocolID = findById(wrapper, "protocolID");
    expect(protocolID.exists()).toBeTruthy();
  });
  it("should render 'program' as you type suggestion with free text field", () => {
    const program = findById(wrapper, "program");
    expect(program.exists()).toBeTruthy();
  });
  it("should render 'indication' as you type field", () => {
    const indication = findById(wrapper, "indication");
    expect(indication.exists()).toBeTruthy();
  });
  it("should render 'phase' dropdown", () => {
    const phase = findById(wrapper, "phase");
    expect(phase.exists()).toBeTruthy();
  });
  it("should render 'time unit' dropdown", () => {
    const timeUnit = findById(wrapper, "timeUnit");
    expect(timeUnit.exists()).toBeTruthy();
  });
  it("should render 'currency' dropdown", () => {
    const currency = findById(wrapper, "currency");
    expect(currency.exists()).toBeTruthy();
  });
  it("should render 'save' button", () => {
    const createProgramButton = findById(wrapper, "createProgramButton");
    expect(createProgramButton.exists()).toBeTruthy();
  });
  it("should render 'cancel' button", () => {
    const cancelSave = findById(wrapper, "cancelSave");
    expect(cancelSave.exists()).toBeTruthy();
  });
});

describe("Create project dialog with Intl", () => {
  const wrapper = setup({ isModelOpen: true });
  
  it("should render header with label 'New Project'", () => {
    const component = findById(wrapper, "createProjectHeader");
    const childComponent = findBySelector(component, "FormattedMessage[id='createProject.newProject']");
    const text = childComponent.text();

    expect(text).toEqual("New Project");
  });

  it("should render 'STUDY DETAIL' label as 'STUDY DETAIL'", () => {
    const component = findBySelector(wrapper, "FormattedMessage[id='createProject.studyDetail']");
    const text = component.text();

    expect(text).toEqual("STUDY DETAIL");
  });

  it("should render 'Project Name' label as 'Project Name'", () => {
    const component = findById(wrapper, "projectName");
    const childComponent = findBySelector(component, "label[id='projectName-label']");
    const text = childComponent.text();

    expect(text).toEqual("Project Name");
  });

  it("should render 'Project Name' placeholder as 'Project Name'", () => {
    const component = findById(wrapper, "projectName");
    const childComponent = findBySelector(component, "fieldset");
    const text = childComponent.text();

    expect(text).toEqual("Project Name");
  });

  it("should render 'Protocol ID' label as 'Protocol ID'", () => {
    const component = findById(wrapper, "protocolID");
    const childComponent = findBySelector(component, "label[id='protocolID-label']");
    const text = childComponent.text();

    expect(text).toEqual("Protocol ID");
  });

  it("should render 'Protocol ID' placeholder as 'Protocol ID'", () => {
    const component = findById(wrapper, "protocolID");
    const childComponent = findBySelector(component, "fieldset");
    const text = childComponent.text();

    expect(text).toEqual("Protocol ID");
  });

  it("should render 'Indication' label as 'Indication'", () => {
    const component = findById(wrapper, "indication");
    const childComponent = findBySelector(component, "label[id='Indication-label']");
    const text = childComponent.text();

    expect(text).toEqual("Indication");
  });

  it("should render 'Indication' placeholder as 'Indication'", () => {
    const component = findById(wrapper, "indication");
    const childComponent = findBySelector(component, "fieldset");
    const text = childComponent.text();

    expect(text).toEqual("Indication");
  });

  it("should render 'PROJECT SETUP' label as 'PROJECT SETUP'", () => {
    const component = findBySelector(wrapper, "FormattedMessage[id='createProject.projectSetup']");
    const text = component.text();

    expect(text).toEqual("PROJECT SETUP");
  });
  
  it("should render 'Save' button text as 'SAVE'", () => {
    const component = findById(wrapper, "createProgramButton");
    const childComponent = findBySelector(component, "FormattedMessage[id='createProject.save']");
    const text = childComponent.text();

    expect(text).toEqual("SAVE");
  });

  it("should render 'Cancel' button text as 'Cancel'", () => {
    const component = findById(wrapper, "cancelSave");
    const childComponent = findBySelector(component, "FormattedMessage[id='createProject.cancel']");
    const text = childComponent.text();

    expect(text).toEqual("CANCEL");
  });
});
