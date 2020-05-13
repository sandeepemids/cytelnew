import { LOCALES } from "../locales";

import en_breadCrumbBar from "./breadCrumbBar/eng.json";
import en_createProject from "./createProject/eng.json";
import en_endpoint from "./endpoint/eng.json";
import en_landingPage from "./landingPage/eng.json";
import en_leftPanel from "./leftPanel/eng.json";
import en_objective from "./objective/eng.json";
import en_projectList from "./projectList/eng.json";

import fr_breadCrumbBar from "./breadCrumbBar/frn.json";
import fr_createProject from "./createProject/frn.json";
import fr_endpoint from "./endpoint/frn.json";
import fr_landingPage from "./landingPage/frn.json";
import fr_leftPanel from "./leftPanel/frn.json";
import fr_objective from "./objective/frn.json";
import fr_projectList from "./projectList/frn.json";

const messages = {
    [LOCALES.english]: {
                ...en_breadCrumbBar,
                ...en_landingPage,
                ...en_createProject,
                ...en_leftPanel,
                ...en_objective,
                ...en_endpoint,
                ...en_projectList
            },
    [LOCALES.french]: {
                ...fr_breadCrumbBar,
                ...fr_landingPage,
                ...fr_createProject,
                ...fr_leftPanel,
                ...fr_objective,
                ...fr_endpoint,
                ...fr_projectList
            }
};

export default messages;
