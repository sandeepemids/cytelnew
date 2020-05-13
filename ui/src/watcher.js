import { takeLatest } from "redux-saga/effects";

import {
  getProjects,
  getProjectListStatus,
  postProjectStatus,
  createProjectSaga,
  createProgramSaga,
  getEndpoints,
  currentProjectUpdate,
  mapProjectTimeUnit,
} from "./sagas/projectSagas";

import { SetSignedInUser } from "./sagas/loginSagas";
import { getProjectConfiguration } from "./sagas/projectConfigurationSaga";
import {
  SetInputAdvisorTemplate,
  UpdateInputAdvisorTemplateWithObjectiveData,
  inputAdvisorUpdate,
  UpdateInputAdvisorTemplateWithOperationalCostData,
  UpdateInputAdvisorTemplateWithMarketAccessData,
} from "./sagas/inputAdvisorSagas";

export default function* actionWatcher() {
  yield takeLatest("PROJECTS_LIST", getProjects);
  yield takeLatest("PROJECT_STATUS_LIST", getProjectListStatus);
  yield takeLatest("PROJECT_STATUS_UPDATE", postProjectStatus);
  yield takeLatest("USER_SIGNEDIN", SetSignedInUser);
  yield takeLatest("PROJECT_CONFIGURATION", getProjectConfiguration);
  yield takeLatest("CREATE_PROJECT", createProjectSaga);
  yield takeLatest("CREATE_PROGRAM", createProgramSaga);
  yield takeLatest("INPUT_ADVISOR", SetInputAdvisorTemplate);
  yield takeLatest(
    "INPUT_ADVISOR_WITH_OBJ_DATA",
    UpdateInputAdvisorTemplateWithObjectiveData
  );
  yield takeLatest("ENDPOINT_LIST_UPDATE", getEndpoints);
  yield takeLatest("CURRENT_PROJECT_OBJ_UPDATE", currentProjectUpdate);
  yield takeLatest("INPUT_ADVISOR_DATA_UPDATE", inputAdvisorUpdate);
  yield takeLatest("PROJECT_TIMEUNIT", mapProjectTimeUnit);
  yield takeLatest(
    "INPUT_ADVISOR_WITH_OPERATIONALCOST_DATA",
    UpdateInputAdvisorTemplateWithOperationalCostData
  );
  yield takeLatest(
    "INPUT_ADVISOR_WITH_MARKETACCESS_DATA",
    UpdateInputAdvisorTemplateWithMarketAccessData
  );
}
