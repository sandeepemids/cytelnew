import axios from "axios";
import config from "../config";

export const getProjectList = async (resourceID) => {
  const response = await axios({
    method: "get",
    url: config.PROJECT_URL + "/" + resourceID,
  });
  return response.data;
};

export const getProjectStatusList = async () => {
  const response = await axios({
    method: "get",
    url: config.PROJECTSTATUSLIST_URL,
  });
  return response.data;
};

export const postProjectStatusUpdate = async (data) => {
  let response = "";
  await axios
    .post(config.PROJECTSTATUSUPDATE_URL, {
      projectID: data.action.projectId,
      statusID: data.action.statusId,
      resourceID: data.action.resourceId,
      createdBy: data.action.createdBy,
    })
    .then((_response) => {
      response = _response;
    });
  return response;
};

export const createProject = async (data) => {
  let response = axios({
    method: "post",
    url: config.CREATE_PROJECT_URL,
    data,
  });
  return response;
};

export const createProgram = async (data) => {
  let response = axios({
    method: "post",
    url: config.CREATE_PROGRAM_URL,
    data,
  });
  return response;
};
export const getEndpointsList = async () => {
  const response = await axios({
    method: "get",
    url: config.ENDPOINTS_URL,
  });
  return response.data;
};
