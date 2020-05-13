import { makeStyles } from "@material-ui/core/styles";

const InputSelectStyle = makeStyles((theme) => ({
  root: {
    height: "44px",
    width: "100%",
  },
  label: {
    background: theme.palette.background.default,
    padding: "2px",
  },
}));

export default InputSelectStyle;
