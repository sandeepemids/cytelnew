import React from "react";
import { ProjectList } from "./ProjectList";
import { findById } from "../../test/testUtils";
import { mountWithIntl } from '../../test/i18nHelper';
import { Provider } from "react-redux";
import configureMockStore from "redux-mock-store";
import { BrowserRouter as Router } from "react-router-dom";
import axios from "axios";
import ProjectListData from "./ProjectListData";
import { orderBy } from "lodash";
import PROJECTLIST from "./constants";

const mockStore = configureMockStore();
const historyMock = { push: jest.fn() };
jest.mock("axios");
const store = mockStore({
  projectReducer: { projectStatusList: [] },
  loginReducer: { signedInUser: { resourceId: 1 } },
});
const setup = (props = {}) => {
  const setupProps = { ...props };

  return mountWithIntl(
    <Provider store={store}>
      <Router history={historyMock}>
        <ProjectList {...setupProps} />
      </Router>
    </Provider>
  );
};

describe("ProjectList component", () => {
  const wrapper = setup({});
  const response = { data: ProjectListData };

  it("should render projectListTable", () => {
    const ProjectListTableElement = findById(wrapper, "projectListTable");
    expect(ProjectListTableElement.exists()).toBeTruthy();
  });
  it("should render projectHeaderLabel with value as project", () => {
    const ProjectHeaderLabelElement = findById(wrapper, "projectHeaderLabel");
    const headerProjectTextElement = ProjectHeaderLabelElement.find(
      'th[id="projectHeaderLabel"]'
    );
    expect(headerProjectTextElement.exists()).toBeTruthy();
    expect(headerProjectTextElement.text()).toEqual("Project");
  });

  it("should render programHeaderLabel with value as Program", () => {
    const ProgramHeaderLabelElement = findById(wrapper, "programHeaderLabel");
    const headerProgramTextElement = ProgramHeaderLabelElement.find(
      'th[id="programHeaderLabel"]'
    );
    expect(headerProgramTextElement.exists()).toBeTruthy();
    expect(headerProgramTextElement.text()).toEqual("Program");
  });

  it("should render createdHeaderLabel with value as Created", () => {
    const CreatedHeaderLabelElement = findById(wrapper, "createdHeaderLabel");
    const headerCreatedTextElement = CreatedHeaderLabelElement.find(
      'th[id="createdHeaderLabel"]'
    );
    expect(headerCreatedTextElement.exists()).toBeTruthy();
    expect(headerCreatedTextElement.text()).toEqual("Created");
  });

  it("should render modifiedHeaderLabel with value as 'Last Modified'", () => {
    const ModifiedHeaderLabelElement = findById(wrapper, "modifiedHeaderLabel");
    const headerModifiedTextElement = ModifiedHeaderLabelElement.find(
      'th[id="modifiedHeaderLabel"]'
    );
    expect(headerModifiedTextElement.exists()).toBeTruthy();
    expect(headerModifiedTextElement.text()).toEqual("Last Modified");
  });

  it("should render statusHeaderLabel with value as Status", () => {
    const StatusHeaderLabelElement = findById(wrapper, "statusHeaderLabel");
    const headerStatusTextElement = StatusHeaderLabelElement.find(
      'th[id="statusHeaderLabel"]'
    );
    expect(headerStatusTextElement.exists()).toBeTruthy();
    expect(headerStatusTextElement.text()).toEqual("Status");
  });
  it("should render actionHeaderLabel with value as Action", () => {
    const ActionHeaderLabelElement = findById(wrapper, "actionHeaderLabel");
    const headerActionTextElement = ActionHeaderLabelElement.find(
      'th[id="actionHeaderLabel"]'
    );
    expect(headerActionTextElement.exists()).toBeTruthy();
    expect(headerActionTextElement.text()).toEqual("Actions");
  });
  it("should render ProjectList component card", () => {
    const ProjectComponentFind = findById(wrapper, "ProjectCard");
    expect(ProjectComponentFind.exists()).toBeTruthy();
  });
  it("should return the mocked module will return", () => {
    axios.get.mockResolvedValue(response);
    axios.get.mockImplementation(() => Promise.resolve(response));
  });

  it("Should return mocked implementation result promise with the response", () => {
    axios.get.mockResolvedValue(response);
    axios.get.mockImplementation(() => Promise.resolve(response));
    expect(response.data).toEqual(ProjectListData);
  });

  if (
    ("should returns result if non-empty object",
    () => {
      const onResponse = historyMock;
      const onError = historyMock;
      return api("/get")
        .then(onResponse)
        .catch(onError)
        .finally(() => {
          expect(onResponse).toHaveBeenCalled();
          expect(onError).not.toHaveBeenCalled();
          expect(onResponse.mock.calls[0]).toEqual({ id: 1 });
        });
    })
  );
  it("Should return mocked implementation result promise with the response", () => {
    var sortList = orderBy(
      response.data,
      PROJECTLIST.ProgramName,
      PROJECTLIST.SortOrderDesc
    );
    expect(sortList[1].program).toEqual("Orange");
  });
});
