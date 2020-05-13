import React from "react";
import Typography from "@material-ui/core/Typography";
import verticleBarStyle from "./verticleBarStyle";

function VerticleBar() {
  const classes = verticleBarStyle();
  return (
    <Typography component={"span"} className={classes.pipe}>
      |
    </Typography>
  );
}

export { VerticleBar };
