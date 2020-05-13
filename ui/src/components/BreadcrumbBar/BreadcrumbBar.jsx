import React, { useEffect, useState } from "react";
import Breadcrumbs from "@material-ui/core/Breadcrumbs";
import Typography from "@material-ui/core/Typography";
import BreadcrumbBarStyle from "./breadcrumbBarStyle";
import { useHistory } from "react-router-dom";
import { useLocation } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAngleRight } from "@fortawesome/pro-regular-svg-icons";
import Link from "@material-ui/core/Link";
import BREADCRUMB from "./constants";
import { FormattedMessage } from "react-intl"

function BreadcrumbBar() {
  const classes = BreadcrumbBarStyle();

  let history = useHistory();
  const location = useLocation();
  const locationPathName = location.pathname;
  const [projectName, setProjectName] = useState();
  var localStorageProjectName = localStorage.getItem("ProjectName");
  useEffect(() => {
    const { state } = history.location;
    if (state) {
      const { projectName } = history.location.state;
      setProjectName(projectName);
      localStorage.setItem("ProjectName", projectName);
    }
  }, [history.location]);

  const handleOnClick = () => {
    history.push(BREADCRUMB.LANDINGPAGEPATH);
  };

  const isLandingPage = locationPathName === BREADCRUMB.LANDINGPAGEPATH ? true : false;
  const isInputAdvisorPage = locationPathName.includes(BREADCRUMB.INPUTADVISORPATH);
  const colorStyle = isLandingPage ? BREADCRUMB.COLORPRIMARY : BREADCRUMB.COLORINHERIT;

  return (
    <Breadcrumbs
      className={classes.root}
      id="breadcrumbs"
      separator={<FontAwesomeIcon icon={faAngleRight} />}
      aria-label="breadcrumb">
      {isLandingPage && <Typography variant="h6" id="projectsHeader" className={classes.bar} color={colorStyle}><FormattedMessage id="breadCrumbBar.projects"></FormattedMessage></Typography>}
      {isInputAdvisorPage && <Link variant="h6" id="projectsHeader" className={classes.bar} color={colorStyle} onClick={() => handleOnClick()}><FormattedMessage id="breadCrumbBar.projects"></FormattedMessage></Link>}
      {isInputAdvisorPage && <Typography className={classes.barCaptionText} color={BREADCRUMB.COLORPRIMARY} >  {localStorageProjectName} </Typography>}
    </Breadcrumbs>
  );
}
Breadcrumbs.defaultProps = {
  history: ["Projects"],
};

export { BreadcrumbBar };
