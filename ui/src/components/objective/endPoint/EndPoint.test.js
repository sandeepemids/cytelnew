import React from "react";
import { mountWithIntl } from "../../../test/i18nHelper";
import { EndPoint } from "./EndPoint";
import { findById, findBySelector } from "../../../test/testUtils";

const setup = (props = {}) => {
  const setupProps = { ...props };
  return mountWithIntl(<EndPoint {...setupProps} />);
};

describe("EndPoint component", () => {
  const wrapper = setup({});

  it("Should render EndPoint Component", () => {
    const ObjectiveComponent = findById(wrapper, "objectEndpoint");
    expect(ObjectiveComponent.exists()).toBeTruthy();
  });

  it("Should render header", () => {
    const EllipsIconH = findById(wrapper, "objectiveHeader");
    expect(EllipsIconH.exists()).toBeTruthy();
  });

  it("Should render 'traget' input element", () => {
    const TargetElement = findById(wrapper, "endPointName");
    expect(TargetElement.exists()).toBeTruthy();
  });

  it("Should render 'treatment' input element", () => {
    const TreatmentElement = findById(wrapper, "endPoint");
    expect(TreatmentElement.exists()).toBeTruthy();
  });

  it("Should render 'control' input element", () => {
    const ControlElement = findById(wrapper, "type");
    expect(ControlElement.exists()).toBeTruthy();
  });
});

describe("EndPoint component with Intl", () => {
  const wrapper = setup({});

  it("should render EndPoint header as 'Endpoint'", () => {
    const component = findById(wrapper, "objectiveHeader");
    const childComponent = findBySelector(component, 'FormattedMessage[id="endpoint.endpoint"]');
    const text = childComponent.text();

    expect(text).toEqual("Endpoint");
  });

  it("should render 'Name' label as 'Name'", () => {
    const component = findById(wrapper, "endPointName");
    const childComponent = findBySelector(component, 'label[id="endPointName-label"]');
    const text = childComponent.text();

    expect(text).toEqual("Name");
  });

  it("should render 'Name' placeholder as 'Name'", () => {
    const component = findById(wrapper, "endPointName");
    const childComponent = findBySelector(component, 'fieldset');
    const text = childComponent.text();

    expect(text).toEqual("Name");
  });

  it("should render 'Type' label as Type", () => {
    const component = findById(wrapper, "type");
    const childComponent = findBySelector(component, 'label[id="type-label"]');
    const text = childComponent.text();

    expect(text).toEqual("Type");
  });

  it("should render 'Type' placeholder as 'Type'", () => {
    const component = findById(wrapper, "type");
    const childComponent = findBySelector(component, 'fieldset');
    const text = childComponent.text();
    
    expect(text).toEqual("Type");
  });
});
