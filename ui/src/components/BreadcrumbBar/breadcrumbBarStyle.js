import { makeStyles } from "@material-ui/core/styles";

const BreadcrumbBarStyle = makeStyles(() => ({
  root: {
    height: "64px",
    lineHeight: "64px",
    width: "850px"
  },
  bar: {
    height: "64px",
    background: "transparent",
    display: "contents",
  },
  barCaptionText: {
    fontFamily: "Roboto",
    fontStyle: "normal",
    fontWeight: "normal",
    fontSize: "20px",
    lineHeight: "24px",
    letterSpacing: "0.15px",
  }

}));

export default BreadcrumbBarStyle;
