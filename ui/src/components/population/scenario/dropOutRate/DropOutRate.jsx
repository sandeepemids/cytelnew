import React from "react";
import { useSelector } from "react-redux";
import Grid from "@material-ui/core/Grid";
import { InputText } from "../../../common/inputText";
import scenarioStyle from "../scenarioStyle";
import POPULATION from "../../constants";

function DropOutRate(props) {
  const classes = scenarioStyle();
  const timeUnit = useSelector(
    (state) => state.projectReducer.currentProject.timeUnit
  );

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    const pattern = /^[0-9:.,]+$/;
    const isValidValue = pattern.test(value) || !value;
    isValidValue && props.handleInputChange(id, value);
  };
  const byTimeError = props.error.find((item) => item.field === "byTime");
  const controlError = props.error.find(
    (item) => item.field === "dropOutControl"
  );
  const treatmentError = props.error.find(
    (item) => item.field === "dropOutTreatment"
  );

  const handleInputError = (e) => {
    const { dropOutControl } = POPULATION.FIELDS;
    const { id, value } = e.target;
    let msg = "";
    const newValue = value.split(",");
    const field = id === dropOutControl ? "Control" : "Treatment";

    if (value) {
      newValue.map((item) => {
        const isRange = item.indexOf(":") >= 0;
        if (isRange) {
          const range = item.split(":");
          const isValidRange = range.length === 3 && range[0] < range[1];
          !isValidRange && (msg = `Please provide valid input`);

          const isValidNumber = range.some(
            (item) => Number(item) < 0 || Number(item) >= 1
          );
          isValidNumber && (msg = `${field} should be >= 0 and < 1`);
        } else {
          const isValidNumber = Number(item) >= 0 && Number(item) < 1;
          !isValidNumber && (msg = `${field} should be >= 0 and < 1`);
          !item && (msg = `Please provide valid input`);
        }
      });
    }
    props.handleInputError(id, value, msg);
  };

  const handleBlur = (e) => {
    const { id, value } = e.target;
    props.handleInputError(id, value);
  };

  const {
    model = {},
    inputMethod = {},
    control,
    byTime,
    treatment,
    numberOfPieces,
  } = props.dropoutRateModel;

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
            handleChange={handleInputChange}
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
            id="byTime"
            error={byTimeError && true}
            helperText={byTimeError && byTimeError.message}
            value={byTime}
            label={`By Time (${timeUnit ? timeUnit : "Time Unit"})`}
            handleChange={handleInputChange}
            handleBlur={handleBlur}
            tabIndex={7}
          />
        </Grid>
        <Grid item sm={4}>
          <InputText
            id="dropOutControl"
            error={controlError && true}
            helperText={controlError && controlError.message}
            value={control}
            label="Control"
            handleChange={handleInputChange}
            handleBlur={handleInputError}
            multiInput
            tabIndex={8}
          />
        </Grid>
        <Grid item sm={4}>
          <InputText
            id="dropOutTreatment"
            error={treatmentError && true}
            helperText={treatmentError && treatmentError.message}
            value={treatment}
            label="Treatment"
            handleChange={handleInputChange}
            handleBlur={handleInputError}
            multiInput
            tabIndex={9}
          />
        </Grid>
      </Grid>
    </React.Fragment>
  );
}
DropOutRate.defaultProps = {
  dropoutRateModel: {
    model: {},
    inputMethod: {},
  },
};
export { DropOutRate };
