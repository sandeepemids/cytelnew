import { makeStyles } from "@material-ui/core/styles";
const headerStyle = makeStyles(theme => ({
  root: {
    height: "64px"
  },
  avatar: {
    position: "absolute",
    right: "0px",
    border: "1px solid",
    height: "32px",
    width: "32px",
    color: theme.palette.primary.main,
    background: theme.palette.primary.light
  },
  logo: {
    marginRight: "24px"
  }
}));

export default headerStyle;
