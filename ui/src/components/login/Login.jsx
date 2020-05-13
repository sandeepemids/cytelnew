import React, { useState } from "react";
import Button from "@material-ui/core/Button";
import { InputText } from "../common/inputText";
import Container from "@material-ui/core/Container";
import Paper from "@material-ui/core/Paper";
import logo from "../../assets/images/logo-Cytel-color.svg";
import loginStyle from "./loginStyle";
import Grid from "@material-ui/core/Grid";
import { useDispatch, useSelector } from "react-redux";
import users from "./users";
import Typography from "@material-ui/core/Typography";
import LOGIN from "./constants";
import { useHistory } from "react-router-dom";

const Login = (props) => {
  const classes = loginStyle();
  let history = useHistory();
  const [enteredEmail, setEnteredEmail] = useState('');
  const [enteredPassword, setEnteredPassword] = useState('');
  const [validationMsg, setValidationMsg] = useState('');
  const dispatch = useDispatch();
  localStorage.setItem('resourceId', "");
  localStorage.setItem('name', "");

  const handleLogIn = () => {
    const userObj=users.filter(item=>(item.email===enteredEmail.trim()))[0];
  
    if(userObj !== undefined 
      && enteredEmail.trim()===userObj.email  
      && enteredPassword.trim()===userObj.password)
    {
      localStorage.setItem('resourceId', userObj.resourceId);
      localStorage.setItem('name', userObj.name);
      dispatch({
        type: "USER_SIGNEDIN",
        payload: userObj
      });
      history.push("/landingpage/projects");
    }else{
      setValidationMsg(LOGIN.INCORRECTCREDENTIAL);
    }
  };

  return (
    <Container maxWidth="xs" className={classes.container}>
      <Paper className={classes.paper}>
        <img className={classes.logo} src={logo} alt="Logo" />
        <form className={classes.form}>
          <Grid container spacing={3}>
            <Grid item md={12} sm={12}>
              <InputText
                required
                id="email"
                label="Email"
                autoComplete="email"
                autoFocus
                value={enteredEmail}
                handleChange={(event) => {
                  setEnteredEmail(event.target.value);
                }}
                onKeyPress={(event) => {
                  if (event.key === 'Enter') {
                    handleLogIn()
                  }
                }}
              />
            </Grid>
            <Grid item md={12} sm={12}>
              <InputText
                required
                id="password"
                label="Password"
                type="password"
                autoComplete="current-password"
                value={enteredPassword}
                handleChange={(event) => {
                    setEnteredPassword(event.target.value);
                }}
                onKeyPress={(event) => {
                  if (event.key === 'Enter') {
                    handleLogIn()
                  }
                }}
              />
            </Grid>
          </Grid>
          <Typography id="signInValidationMsg" variant="subtitle1" className={classes.errorlabel}>
            {validationMsg}
          </Typography>
          <Button
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={handleLogIn}
            id="btnLogin"
          >
            Sign In
          </Button>
        </form>
      </Paper>
    </Container>
  );
};

export { Login };
