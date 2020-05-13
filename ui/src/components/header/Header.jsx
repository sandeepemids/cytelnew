import React from "react";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import Container from "@material-ui/core/Container";
import Avatar from "@material-ui/core/Avatar";
import CytelLogo from "../../../src/assets/images/logo-Cytel-color.svg";
import { VerticleBar } from "../common/verticleBar";
import headerStyle from "./headerStyle";
import { useHistory } from "react-router-dom";

const Header = () => {
  const classes = headerStyle();
  let history = useHistory();
  
  const handleOnClick = () => {
    history.push("/landingpage/projects");
  };

  return (
    <AppBar position="static">
      <Container>
        <Toolbar className={classes.root} variant="dense">
          <img
            id="cytelLogo"
            className={classes.logo}
            src={CytelLogo}
            alt="Logo"
            onClick={() => handleOnClick()}
          />
          <VerticleBar />
          <Typography id="productName" variant="body2" color="secondary" onClick={() => handleOnClick()}>
            Solaris
          </Typography>
          <Avatar id="avatar" className={classes.avatar}></Avatar>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export { Header };
