import axios from "axios";
import config from "../config";

export const getInputAdvisorTempateUpdate = async (data) => {
  const { resourceID, projectID } = data.payload;
  const response = await axios({
    method: "get",
    url: config.INPUTADVISOR_URL + `/${resourceID}/${projectID}`,
  });
  return response.data;
};

export const inputAdvisorDataUpdateDB = async (data) => {
  const inputAdvisorInput = data.payload.InputAdvisorData;
  const pageID = data.payload.pageID;

  let response = "";
  await axios
    .post(config.INPUTADVISOR_URL + `/'${pageID}'`, inputAdvisorInput, {
      headers: { "Content-Type": "application/json" },
    })
    .then((_response) => {
      response = _response;
    });
  return response;
};
