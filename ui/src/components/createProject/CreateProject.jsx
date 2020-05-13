import React, { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import Button from "@material-ui/core/Button";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import IconButton from "@material-ui/core/IconButton";
import CloseIcon from "@material-ui/icons/Close";
import Typography from "@material-ui/core/Typography";
import Grid from "@material-ui/core/Grid";
import createProjectStyle from "./createProjectStyle";
import { InputText } from "../common/inputText";
import { InputSelect } from "../common/inputSelect";
import { InputAutoComplete } from "../common/InputAutoComplete";
import CREATEPROJECT from "./constants";
import { CreateProgram } from "./createProgram";
import { useHistory } from "react-router-dom";
import { FormattedMessage, useIntl } from "react-intl"

function CreateProject(props) {
  const { isModelOpen, handleCreateProjectModel } = props;
  const classes = createProjectStyle();
  const dispatch = useDispatch();
  const { formatMessage } = useIntl();

  const errorData =
    useSelector((state) => state.projectReducer.errorData) || {};
  const isNewProject = useSelector(
    (state) => state.projectReducer.isNewProject
  );
  let history = useHistory();
  const userName = localStorage.getItem("name");
  const resourceID = localStorage.getItem("resourceId");
  if (userName === "") {
    history.push("/login");
  }
  const indications = useSelector((state) => state.projectReducer.indications);
  const timeunits = useSelector((state) => state.projectReducer.timeunits);
  const currencies = useSelector((state) => state.projectReducer.currencies);
  const programs = useSelector((state) => state.projectReducer.programs);
  const newProgram = useSelector((state) => state.projectReducer.newProgram);
  const [projectDetail, setProjectDetail] = useState({
    ...CREATEPROJECT.DEFAULTVALUE,
  });
  const [isConfirm, setIsConfirm] = useState(false);
  const [isValidForm, setIsValidForm] = useState(false);

  useEffect(() => {
    if (newProgram) {
      setProjectDetail({ ...projectDetail, programID: newProgram.id });
      dispatch({
        type: "NEW_PROGRAM_UPDATE",
        newProgram: null,
      });
    }
  }, [dispatch, newProgram, projectDetail]);

  if (isNewProject) {
    setTimeout(() => {
      dispatch({
        type: "IS_NEW_PROJECT_UPDATE",
        isNewProject: false,
      });
      setProjectDetail(CREATEPROJECT.DEFAULTVALUE);
      setIsValidForm(false);
      handleCreateProjectModel();
    }, 1000);
  }

  useEffect(() => {
    dispatch({
      type: "PROJECT_CONFIGURATION",
      resourceID,
    });
  }, [dispatch]);

  useEffect(() => {
    (() => {
      setIsValidForm(false);
      for (let item in projectDetail) {
        let data = projectDetail[item];
        if (typeof projectDetail[item] === "string") {
          data = data.replace(/ /g, "");
        }
        if (data === "") {
          return false;
        }
      }
      setIsValidForm(true);
    })();
  }, [projectDetail]);

  const handleProjectDetail = (e) => {
    const {
      projectName,
      protocolID,
      phase,
      timeUnit,
      currency,
    } = CREATEPROJECT.FIELDS;
    const { name, value } = e.target;
    switch (name) {
      case projectName:
        name.length <= 75 &&
          setProjectDetail({ ...projectDetail, projectName: value });
        errorData.errorField === projectName &&
          dispatch({ type: "PROJECT_ERROR_UPDATE", errorData: {} });
        break;

      case protocolID:
        const pattern = /^[a-zA-Z0-9]+$/i;
        const isValidProtocolID = pattern.test(value) && value.length <= 75;
        (isValidProtocolID || value === "") &&
          setProjectDetail({ ...projectDetail, protocolID: value });
        errorData.errorField === protocolID &&
          dispatch({ type: "PROJECT_ERROR_UPDATE", errorData: {} });
        break;

      case phase:
        setProjectDetail({ ...projectDetail, phase: value });
        break;

      case timeUnit:
        setProjectDetail({ ...projectDetail, timeUnitID: value });
        break;

      case currency:
        setProjectDetail({ ...projectDetail, currencyID: value });
        break;

      default:
        break;
    }
  };

  const handleIndication = (value) => {
    setProjectDetail({ ...projectDetail, indicationID: value });
  };

  const handleProgram = (value) => {
    if (typeof value === "number") {
      setProjectDetail({ ...projectDetail, programID: value });
    } else if (value !== "") {
      dispatch({
        type: "CREATE_PROGRAM",
        program: {
          programName: value,
          resourceID: resourceID,
          createdBy: userName,
        },
      });
    } else {
      setProjectDetail({ ...projectDetail, programID: value });
    }
  };

  const handleCreateProject = () => {
    dispatch({
      type: "CREATE_PROJECT",
      projectDetail: { ...projectDetail, resourceID, createdBy: userName },
    });
  };

  const handleCancel = () => setIsConfirm(true);

  const handleConfirmation = () => {
    setProjectDetail(CREATEPROJECT.DEFAULTVALUE);
    setIsConfirm(false);
    dispatch({ type: "PROJECT_ERROR_UPDATE", errorData: {} });
    handleCreateProjectModel();
  };

  return (
    <React.Fragment>
      <Dialog
        id="createProjectDialog"
        aria-labelledby="create-project"
        open={isModelOpen}
      >
        <DialogTitle onClose={handleCancel} className={classes.dialogTitle}>
          <Typography id="createProjectHeader" component="span" variant="h6">
            <FormattedMessage id="createProject.newProject"></FormattedMessage>
          </Typography>
          <IconButton
            aria-label="close"
            className={classes.closeButton}
            onClick={handleCancel}
          >
            <CloseIcon />
          </IconButton>
        </DialogTitle>
        <DialogContent className={classes.dialogContent}>
          <Typography
            component="h2"
            variant="overline"
            className={classes.subHeading}
          >
            <FormattedMessage id="createProject.studyDetail"></FormattedMessage>
          </Typography>
          <Grid container spacing={3}>
            <Grid item md={6} sm={6} xs={12}>
              <InputText
                error={
                  errorData.errorField === CREATEPROJECT.FIELDS.projectName
                }
                helperText={errorData.errorField === CREATEPROJECT.FIELDS.projectName ? errorData.errorMsg : ''}
                label={formatMessage({id:"createProject.projectName"})}
                id="projectName"
                name="Project Name"
                value={projectDetail.projectName}
                handleChange={handleProjectDetail}
              />
            </Grid>
            <Grid item md={6} sm={6} xs={12}></Grid>
            <Grid item md={6} sm={6} xs={12}>
              <InputText
                error={errorData.errorField === CREATEPROJECT.FIELDS.protocolID}
                helperText={errorData.errorField === CREATEPROJECT.FIELDS.protocolID ? errorData.errorMsg : ''}
                value={projectDetail.protocolID}
                label={formatMessage({id:"createProject.protocolID"})}
                id="protocolID"
                name="Protocol ID"
                handleChange={handleProjectDetail}
              />
            </Grid>
            <Grid item md={6} sm={6} xs={12}>
              <CreateProgram
                options={programs}
                textToDisplay="name"
                valueToReturn="id"
                name={formatMessage({id:"createProject.program"})}
                id="program"
                handleChange={handleProgram}
              />
            </Grid>
            <Grid item md={6} sm={6} xs={12}>
              <InputAutoComplete
                textToDisplay="value"
                name={formatMessage({id:"createProject.indication"})}
                id="indication"
                handleChange={handleIndication}
                options={indications}
                valueToReturn="id"
              />
            </Grid>
            <Grid item md={6} sm={6} xs={12}>
              <InputSelect
                value={projectDetail.phase}
                label="Phase"
                options={CREATEPROJECT.PHASES}
                name="Phase"
                id="phase"
                textToDisplay="value"
                valueToReturn="id"
                handleChange={handleProjectDetail}
              />
            </Grid>
          </Grid>
          <Typography
            component="h2"
            variant="overline"
            className={classes.subHeading}
          >
            <FormattedMessage id="createProject.projectSetup"></FormattedMessage>
          </Typography>
          <Grid container spacing={3}>
            <Grid item md={6} sm={6} xs={12}>
              <InputSelect
                value={projectDetail.timeUnitID}
                label="Time Unit"
                name="Time Unit"
                id="timeUnit"
                options={timeunits}
                textToDisplay="value"
                valueToReturn="id"
                handleChange={handleProjectDetail}
              />
            </Grid>
            <Grid item md={6} sm={6} xs={12}>
              <InputSelect
                value={projectDetail.currencyID}
                label="Currency"
                name="Currency"
                id="currency"
                options={currencies}
                textToDisplay="value"
                valueToReturn="id"
                handleChange={handleProjectDetail}
              />
            </Grid>
          </Grid>
        </DialogContent>
        <DialogActions
          id="createProjectFooter"
          className={classes.actionButton}
        >
          <Button
            variant="contained"
            onClick={handleCreateProject}
            color="primary"
            id="createProgramButton"
            disabled={!isValidForm}
          >
            <FormattedMessage id="createProject.save"></FormattedMessage>
          </Button>
          <Button
            variant="outlined"
            onClick={handleCancel}
            color="primary"
            id="cancelSave"
          >
            <FormattedMessage id="createProject.cancel"></FormattedMessage>
          </Button>
        </DialogActions>
      </Dialog>

      <Dialog
        id="confirmationDialog"
        aria-labelledby="confirmation-dialog"
        open={isConfirm}
      >
        <DialogTitle className={classes.confirmationTitle}>
          <Typography component="span" variant="body1">
            <FormattedMessage id="createProject.cancelMessage"></FormattedMessage>
          </Typography>
        </DialogTitle>
        <DialogActions className={classes.actionButton}>
          <Button
            variant="contained"
            onClick={handleConfirmation}
            color="primary"
          >
            <FormattedMessage id="createProject.yes"></FormattedMessage>
          </Button>
          <Button
            variant="outlined"
            onClick={() => setIsConfirm(false)}
            color="primary"
            autoFocus
          >
            <FormattedMessage id="createProject.no"></FormattedMessage>
          </Button>
        </DialogActions>
      </Dialog>
    </React.Fragment>
  );
}
CreateProject.defaultProps = {
  isModelOpen: false,
  handleCreateProjectModel: () => {},
};
export { CreateProject };
