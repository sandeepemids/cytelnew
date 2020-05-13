import { makeStyles } from "@material-ui/core/styles";

const createProjectStyle = makeStyles((theme) => ({
  dialogTitle: {
    padding: "32px 32px 0 32px",
  },
  confirmationTitle: {
    padding: "32px",
  },
  dialogContent: {
    padding: "0px 32px",
    minHeight: "400px",
  },
  actionButton: {
    padding: " 10px 32px 32px",
    justifyContent: "flex-start",
  },
  closeButton: {
    position: "absolute",
    right: theme.spacing(1),
    top: theme.spacing(1),
    color: theme.palette.text.primary,
  },
  subHeading: {
    padding: "20px 0px",
  },
}));

export default createProjectStyle;
