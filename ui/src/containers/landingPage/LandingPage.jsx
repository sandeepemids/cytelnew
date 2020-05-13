import React, { useState } from "react";
import { Header } from "../../components/header";
import { ProjectList } from "../../components/projectlist";
import { InputAdvisor } from "../inputAdvisor";
import { BreadcrumbBar } from "../../components/BreadcrumbBar";
import Container from "@material-ui/core/Container";
import { Switch, Route } from "react-router-dom";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import LandingPageStyle from "./LandingPageStyle";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/pro-regular-svg-icons";
import { CreateProject } from "../../components/createProject";
import { useLocation } from "react-router-dom";
import { FormattedMessage } from "react-intl"

function LandingPage() {
  const classes = LandingPageStyle();
  const [isOpen, setIsOpen] = useState(false);
  const location = useLocation();
  const locationPathName = location.pathname;

  const handleCreateProjectModel = () => {
    setIsOpen(!isOpen);
  };

  return (
    <React.Fragment>
      <Header id="header"></Header>
      <Container fixed>
        <Grid container>
          <Grid item sm={8} md={10} xs={8}>
            <BreadcrumbBar id="breadcrumbBar" />
          </Grid>
          {locationPathName === "/landingpage/projects" ?
            <Grid className={classes.projectLabel} item sm={4} md={2} xs={4}>
              <Button
                className={classes.newProjectIcon}
                color="primary"
                onClick={handleCreateProjectModel}
                id="newProjectButton"
                startIcon={
                  <FontAwesomeIcon className={classes.icon} icon={faPlus} />
                }
              >
                <FormattedMessage id="landingPage.newProject"></FormattedMessage>
            </Button>
            </Grid> : null}
        </Grid>
        <CreateProject
          isModelOpen={isOpen}
          handleCreateProjectModel={handleCreateProjectModel}
        />
        <Switch>
          <Route
            exact
            path={`/landingpage/projects`}
            render={() => <ProjectList />}
          />
          <Route
            path={`/landingpage/input-advisor`}
            render={() => <InputAdvisor />}
          />
        </Switch>
      </Container>
    </React.Fragment>
  );
}

export { LandingPage };
