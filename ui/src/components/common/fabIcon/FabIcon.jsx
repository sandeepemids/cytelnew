import React from "react";
import Fab from "@material-ui/core/Fab";
import AddIcon from "@material-ui/icons/Add";
import fabIconStyle from "./fabIconStyle";

function FabIcon(props) {
  const classes = fabIconStyle();
  const { handleCreateProjectModel } = props;
  return (
    <Fab
      onClick={handleCreateProjectModel}
      id="fab-icon"
      className={classes.root}
    >
      <AddIcon id="plus-button" />
    </Fab>
  );
}

export { FabIcon };
