import React from "react";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import InputSelectStyle from "./InputSelectStyle";
import FormControl from "@material-ui/core/FormControl";
import InputLabel from "@material-ui/core/InputLabel";
import FormHelperText from "@material-ui/core/FormHelperText";

function InputSelect(props) {
  const classes = InputSelectStyle();
  const {
    value,
    options,
    handleChange,
    textToDisplay,
    valueToReturn,
    name,
    isDisabled,
    handleBlur,
    error,
    helperText,
    tabIndex,
  } = props;

  return (
    <FormControl variant="outlined" className={classes.root} error={error}>
      <InputLabel className={classes.label} id={name}>
        {name}
      </InputLabel>
      <Select
        id={name}
        className={classes.root}
        value={value}
        onChange={handleChange}
        inputProps={{
          name: name,
          tabIndex: tabIndex,
        }}
        disabled={isDisabled}
        name={name}
        onBlur={handleBlur}
        error={error}
      >
        <MenuItem className="option" key="select" disabled value="">
          Select
        </MenuItem>
        {options.length > 0 &&
          options.map((option) => {
            return (
              <MenuItem
                className="option"
                key={option.id}
                disabled={option.disabled}
                value={option[valueToReturn]}
              >
                {option[textToDisplay]}
              </MenuItem>
            );
          })}
      </Select>
      <FormHelperText>{helperText || ""}</FormHelperText>
    </FormControl>
  );
}

InputSelect.defaultProps = {
  handleChange: () => {},
  valueToReturn: "value",
  textToDisplay: "value",
  name: "select",
  options: [],
  value: "",
  isDisabled: false,
  helperText: "",
};
export { InputSelect };
