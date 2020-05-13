import { makeStyles } from "@material-ui/core/styles";
const loginStyle = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(20),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    padding: "30px",
    width: "60%",
  },
  logo: {
    margin: theme.spacing(1, 1, 4, 1),
    width: "100px",
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  container: {
    display: "flex",
    flexDirection: "row",
    justifyContent: "center",
  },
  errorlabel:{
    paddingLeft:'16px',
    color: '#9C0004'
  },
}));

export default loginStyle;
