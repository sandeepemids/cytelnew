import buildUrls from "./utils/buildUrls";

const envUrl = process.env.REACT_APP_PROJECT_MANAGER_API_URL;

const environmentUrls = {
  PROJECT_URL: buildUrls(envUrl, "v1.0", "projects"),
  PROJECTSTATUSLIST_URL: buildUrls(envUrl, "v1.0", "statuses"),
  PROJECTSTATUSUPDATE_URL: buildUrls(envUrl, "v1.0", "projectstatus"),
  PROJECT_INDICATIONS_URL: buildUrls(envUrl, "v1.0", "indications"),
  PROJECT_TIMEUNITS_URL: buildUrls(envUrl, "v1.0", "timeunits"),
  PROJECT_CURRENCIES_URL: buildUrls(envUrl, "v1.0", "currencies"),
  PROJECT_PROGRAM_URL: buildUrls(envUrl, "v1.0", "programs"),
  CREATE_PROJECT_URL: buildUrls(envUrl, "v1.0", "projects"),
  CREATE_PROGRAM_URL: buildUrls(envUrl, "v1.0", "programs"),
  INPUTADVISOR_URL: buildUrls(envUrl, "v1.0", "inputadvisor"),
  ENDPOINTS_URL: buildUrls(envUrl, "v1.0", "endpoints"),
};

const config = environmentUrls;

export default {
  ...config,
};
