import { makeStyles } from "@material-ui/core/styles";

const projectListStyle = makeStyles({
  root: {
    height: `calc(90vh - 130px)`,
    minHeight: "400px",
    position: "relative",
  },
  rowCellLink: {
    fontSize: "14px",
    cursor: "pointer",
  },
  handPointer: {
    cursor: "pointer",
  },
  sortIconStyle: {
    paddingLeft: "4px",
  },
});

export default projectListStyle;
