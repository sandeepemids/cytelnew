import React from "react";
import Objective from "./Objective";
import { findById, findBySelector } from "../../test/testUtils";
import { Router } from "react-router-dom";
import configureMockStore from "redux-mock-store";
import { mountWithIntl } from '../../test/i18nHelper';
import { Provider } from "react-redux";

const mockStore = configureMockStore();

const store = mockStore({
  projectReducer: {
    currentProject: {}
  },
  loginReducer: {
    signedInUser: {},
  },
  inputAdvisorReducer:{
    inputAdvisorData: {}
  }
});

const setup = (props = {}) => {
  const setupProps = { ...props };
  const historyMock = { push: jest.fn(), location: {}, listen: jest.fn() };

  return mountWithIntl(
    <Provider store={store}>
      <Router history={historyMock}>
        <Objective {...setupProps} />
      </Router>
    </Provider>
  );
};

describe("Objective component", () => {
  const wrapper = setup({
    currentProject: {}
  });

  it("Should render Input Advisor - Objective Component", () => {
    const ObjectiveComponent = findById(wrapper, "objective");
    expect(ObjectiveComponent.exists()).toBeTruthy();
  });

  it("Should render Objective icon", () => {
    const ObjectiveIcon = findById(wrapper, "objectiveIcon");
    expect(ObjectiveIcon.exists()).toBeTruthy();
  });

  it("Should render 'target' input element", () => {
    const TargetElement = findById(wrapper, "target");
    expect(TargetElement.exists()).toBeTruthy();
  });

  it("Should render 'treatment' input element", () => {
    const TreatmentElement = findById(wrapper, "treatment");
    expect(TreatmentElement.exists()).toBeTruthy();
  });

  it("Should render 'control' input element", () => {
    const ControlElement = findById(wrapper, "control");
    expect(ControlElement.exists()).toBeTruthy();
  });
});

describe("Objective component with Intl", () => {
  const wrapper = setup({
      currentProject: {}
    });

  it("should render 'Objective Page' with header as 'Objective", () => {
    const component = findById(wrapper, "objective");
    const childComponent = findBySelector(component, 'FormattedMessage[id="objective.objective"]');
    const text = childComponent.text();

    expect(text).toEqual("Objective");;
  });

  it("should render 'Target Population' label as 'Target Population", () => {
    const component = findById(wrapper, "target");
    const childComponent = findBySelector(component, 'label[id="target-label"]');
    const text = childComponent.text();

    expect(text).toEqual("Target Population");
  });

  it("should render 'Target Population' placeholder as 'Target Population", () => {
    const component = findById(wrapper, "target");
    const childComponent = findBySelector(component, 'fieldset');
    const text = childComponent.text();

    expect(text).toEqual("Target Population");
  });

  it("should render 'Treatment Arm' label as 'Treatment Arm", () => {
    const component = findById(wrapper, "treatment");
    const childComponent = findBySelector(component, 'label[id="treatment-label"]');
    const text = childComponent.text();

    expect(text).toEqual("Treatment Arm");;
  });

  it("should render 'Treatment Arm' placeholder as 'Treatment Arm", () => {
    const component = findById(wrapper, "treatment");
    const childComponent = findBySelector(component, 'fieldset');
    const text = childComponent.text();

    expect(text).toEqual("Treatment Arm");;
  });

  it("should render 'Control Arm' label as 'Control Arm", () => {
    const component = findById(wrapper, "control");
    const childComponent = findBySelector(component, 'label[id="control-label"]');
    const text = childComponent.text();

    expect(text).toEqual("Control Arm");;
  });

  it("should render 'Control Arm' placeholder as 'Control Arm", () => {
    const component = findById(wrapper, "control");
    const childComponent = findBySelector(component,'fieldset');
    const text = childComponent.text();

    expect(text).toEqual("Control Arm");;
  });
});
