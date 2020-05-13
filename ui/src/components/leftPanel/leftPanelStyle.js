import { makeStyles } from "@material-ui/core/styles";

const leftPanelStyle = makeStyles((theme) => ({
  root: {
    marginTop: "16px",
  },
  active: {
    color: theme.palette.primary.main,
    borderLeft: `2px solid ${theme.palette.primary.main}`,
    background: theme.palette.primary.light,
  },
  activeIcon: {
    color: theme.palette.primary.main,
  },
  errorIcon: {
    marginLeft: "auto",
    color: "red",
  },
}));

export default leftPanelStyle;
