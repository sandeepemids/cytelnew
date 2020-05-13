import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/pro-regular-svg-icons";
import AddIconStyle from "./addIconStyle";

function AddIcon() {
  const classes = AddIconStyle();
  return (
   <FontAwesomeIcon id="plusIcon" icon={faPlus} className={classes.plusIcon} /> 
  );
}

export { AddIcon };
