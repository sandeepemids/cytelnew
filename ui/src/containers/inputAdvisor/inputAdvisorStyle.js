import { makeStyles } from "@material-ui/core/styles";
const inputAdvisorStyle = makeStyles((theme) => ({
  root: {
    padding: "0px!important",
    minHeight: `calc(90vh - 130px)`,
  },
  leftpanel: {
    borderRight: `1px solid ${theme.palette.secondary.light}`,
    minHeight: `calc(90vh - 130px)`,
  },
}));
export default inputAdvisorStyle;
