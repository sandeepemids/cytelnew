import axios from "axios";
import config from "../config";

export const getIndications = async () => {
  const response = await axios({
    method: "get",
    url: config.PROJECT_INDICATIONS_URL,
  });
  if (response.status === 200) {
    return response.data;
  }
};

export const getTimeunits = async () => {
  const response = await axios({
    method: "get",
    url: config.PROJECT_TIMEUNITS_URL,
  });
  if (response.status === 200) {
    return response.data;
  }
};

export const getCurrencies = async () => {
  const response = await axios({
    method: "get",
    url: config.PROJECT_CURRENCIES_URL,
  });
  if (response.status === 200) {
    return response.data;
  }
};

export const getPrograms = async (resourceID) => {
  const response = await axios({
    method: "get",
    url: `${config.PROJECT_PROGRAM_URL}/${resourceID}`,
  });
  if (response.status === 200) {
    return response.data;
  }
};
