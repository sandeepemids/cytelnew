import { makeStyles } from "@material-ui/core/styles";

const landingPageStyle = makeStyles({
  projectLabel: {
    position: "relative",
  },
  newProjectIcon: {
    position: "absolute",
    right: "0px",
    margin: "15px 0 15px 0 !important",
    paddingRight: "0px!important",
    paddingLeft: "3px!important",
    "&:hover": {
      backgroundColor: "transparent!important",
    },
    textTransform: "none",
    color:"#00529C",
  },
  icon: {
    height: 16,
  },
});

export default landingPageStyle;
