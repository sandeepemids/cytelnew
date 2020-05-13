import { call, put } from "redux-saga/effects";

import {
  getInputAdvisorTempateUpdate,
  inputAdvisorDataUpdateDB,
} from "./../actions/inputAdvisorActions";

export function* SetInputAdvisorTemplate(data) {
  const inputAdvisorTempateUpdate = yield call(
    getInputAdvisorTempateUpdate,
    data
  );
  yield put({
    type: "INPUT_ADVISOR_UPDATE",
    inputAdvisorData: inputAdvisorTempateUpdate,
  });
}

export function* UpdateInputAdvisorTemplateWithObjectiveData(data) {
  yield put({
    type: "INPUT_ADVISOR_UPDATE_OBJECTIVE_DATA",
    objectiveData: data,
  });
}

export function* inputAdvisorUpdate(data) {
  const projectID = data.payload.InputAdvisorData.projectID;
  const resourceID = data.payload.InputAdvisorData.resourceID;
  const inputAdvisorData = yield call(inputAdvisorDataUpdateDB, data);
  if (inputAdvisorData.status === 201) {
    const inputAdvisorTempateUpdate = yield call(getInputAdvisorTempateUpdate, {
      payload: { resourceID, projectID },
    });
    yield put({
      type: "INPUT_ADVISOR_UPDATE",
      inputAdvisorData: inputAdvisorTempateUpdate,
    });
  }
}

export function* UpdateInputAdvisorTemplateWithOperationalCostData(data) {
  yield put({
    type: "INPUT_ADVISOR_UPDATE_OPERATIONALCOST_DATA",
    operationalCost: data,
  });
}

export function* UpdateInputAdvisorTemplateWithMarketAccessData(data) {
  yield put({
    type: "INPUT_ADVISOR_UPDATE_MARKETACCESS_DATA",
    marketAccess: data,
  });
}
