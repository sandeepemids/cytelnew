import React from "react";
import Grid from "@material-ui/core/Grid";
import { InputText } from "../../../common/inputText";
import scenarioStyle from "../scenarioStyle";
import { useSelector } from "react-redux";

function EndPoint(props) {
  const classes = scenarioStyle();
  const {
    model,
    inputMethod,
    control,
    hazardRatio,
    numberOfPieces,
  } = props.endpointModel;
  const controlError = props.error.find((item) => item.field === "control");
  const hazardRatioError = props.error.find(
    (item) => item.field === "hazardRatio"
  );
  const timeUnit = useSelector(
    (state) => state.projectReducer.currentProject.timeUnit
  );

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    const pattern = /^[0-9:.,]+$/;
    const isValidValue = pattern.test(value) || !value;
    isValidValue && props.handleInputChange(id, value);
  };

  const handleInputError = (e) => {
    const { id, value } = e.target;
    const newValue = value.split(",");
    let msg = "";
    newValue.map((item) => {
      const isRange = item.indexOf(":") >= 0;
      if (isRange) {
        const range = item.split(":");
        const isValidRange =
          range.length === 3 && range[0] < range[1] && range[2];
        !isValidRange && (msg = "Please provide valid input");
      } else {
        const isValidNumber = Number(item) > 0;
        !isValidNumber && (msg = "Please provide valid input");
      }
    });
    props.handleInputError(id, value, msg);
  };

  const isMultipleValue =
    (control && control.indexOf(",") > -1) ||
    (control && control.indexOf(":") > -1) ||
    (hazardRatio && hazardRatio.indexOf(",") > -1) ||
    (hazardRatio && hazardRatio.indexOf(":") > -1);

  const treatment = isMultipleValue ? "Computed" : control / hazardRatio || "";
  return (
    <React.Fragment>
      <Grid container spacing={2} className={classes.rowSpacing}>
        <Grid item sm={4}>
          <InputText value={model.value} id="model" label="Model" isDisabled />
        </Grid>
        <Grid item sm={4}>
          <InputText
            value={inputMethod.value}
            id="inputMethod"
            label="Input Method"
            isDisabled
          />
        </Grid>
        <Grid item sm={4}>
          <InputText
            value={numberOfPieces}
            id="numberOfPieces"
            label="Number of Pieces"
            isDisabled
          />
        </Grid>
      </Grid>
      <Grid container spacing={2} className={classes.rowSpacing}>
        <Grid item sm={4}>
          <InputText
            id="control"
            error={controlError && true}
            helperText={controlError && controlError.message}
            value={control}
            label={`Control (${timeUnit ? timeUnit : "Time Unit"})`}
            handleChange={handleInputChange}
            handleBlur={handleInputError}
            multiInput
            tabIndex={5}
          />
        </Grid>
        <Grid item sm={4}>
          <InputText
            value={treatment}
            id="treatment"
            label={`Treatment (${timeUnit ? timeUnit : "Time Unit"})`}
            isDisabled
            multiInput
          />
        </Grid>
        <Grid item sm={4}>
          <InputText
            id="hazardRatio"
            error={hazardRatioError && true}
            helperText={hazardRatioError && hazardRatioError.message}
            value={hazardRatio}
            label="Hazard Ratio"
            handleChange={handleInputChange}
            handleBlur={handleInputError}
            multiInput
            tabIndex={6}
          />
        </Grid>
      </Grid>
    </React.Fragment>
  );
}
EndPoint.defaultProps = {
  endpointModel: {
    model: {},
    inputMethod: {},
    control: "",
    hazardRatio: "",
  },
  handleInputError: () => {},
  handleInputChange: () => {},
};
export { EndPoint };
