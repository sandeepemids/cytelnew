import { call, put } from "redux-saga/effects";
import {
  getProjectList,
  getProjectStatusList,
  postProjectStatusUpdate,
  createProject,
  createProgram,
  getEndpointsList,
} from "../actions/projectActions";
import { getPrograms } from "../actions/projectConfigurationAction";

export function* getProjects(resourceId) {
  const projects = yield call(getProjectList, resourceId.payload);
  yield put({ type: "PROJECTS_UPDATE", projects: projects });
}

export function* getProjectListStatus() {
  const projectStatusList = yield call(getProjectStatusList);
  yield put({
    type: "PROJECT_STATUS_LIST_UPDATE",
    projectStatusList: projectStatusList,
  });
}

export function* postProjectStatus(data) {
  const projectStatusUpdate = yield call(postProjectStatusUpdate, data);
  if (projectStatusUpdate.status === 200) {
    yield call(getProjects, { payload: data.action.resourceId });
  }
}

export function* createProjectSaga(payload) {
  try {
    const resourceID = payload.projectDetail.resourceID;
    const project = yield call(createProject, payload.projectDetail);
    if (project.status === 201) {
      yield call(getProjects, { payload: resourceID });
      yield put({ type: "IS_NEW_PROJECT_UPDATE", isNewProject: true });
    }
  } catch (error) {
    if (error.response.status === 409) {
      const errorMsg = error.response.data.exceptionMessage;
      const errorField =
        errorMsg === "Name already exist" ? "Project Name" : "Protocol ID";
      yield put({
        type: "PROJECT_ERROR_UPDATE",
        errorData: {
          errorField,
          errorMsg,
        },
      });
    }
  }
}

export function* createProgramSaga(payload) {
  try {
    const program = yield call(createProgram, payload.program);
    if (program.status === 201) {
      yield put({ type: "NEW_PROGRAM_UPDATE", newProgram: program.data });
      const programs = yield call(getPrograms, payload.program.resourceID);
      yield put({ type: "PROGRAMS_UPDATE", programs: programs });
    }
  } catch (error) {}
}
export function* getEndpoints() {
  const endpoints = yield call(getEndpointsList);
  yield put({ type: "ENDPOINTS_UPDATE", endpoints: endpoints });
}

export function* currentProjectUpdate(data) {
  yield put({ type: "CURRENT_PROJECT", currentProject: data.payload });
}

export function* mapProjectTimeUnit(data) {
  yield put({
    type: "PROJECT_TIMEUNIT_UPDATE",
    projectTimeUnit: data.action.projectTimeUnit,
    projectId: data.action.projectId,
    createdBy: data.action.createdBy,
    isEditMode: data.action.isEditMode,
  });
}
