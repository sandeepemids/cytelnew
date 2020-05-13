import { makeStyles } from "@material-ui/core/styles";
const inputTextStyle = makeStyles((theme) => ({
  dot: {
    width: "8px",
    height: "8px",
    marginBottom: "1px",
    marginRight: "7px",
    display: "inline-block",
    background: theme.palette.error.primary,
    borderRadius: "50%",
  },
}));

export default inputTextStyle;
