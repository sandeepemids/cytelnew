const operationalCostsStyle = (theme) => ({
  root: {
    margin: "32px",
    position: "relative",
  },
  inputAdvisorIcon: {
    color: theme.palette.secondary.main,
    marginRight: "16px",
  },
  inputAdvisorHeader: {
    paddingBottom: theme.spacing(2),
  },
  inputControl: {
    padding: theme.spacing(2, 0),
  },
  addMore: {
    textTransform: "initial",
    fontWeight: "500",
    fontSize: "14px",
    lineHeight: "16px",
    position: "absolute",
    right: "0px",
    top: "0px",
    letterSpacing: "1.25px",
  },
});

export default operationalCostsStyle;
