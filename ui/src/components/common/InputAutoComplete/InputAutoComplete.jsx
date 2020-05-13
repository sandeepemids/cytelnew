import React from "react";
import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete";

function InputAutoComplete(props) {
  const { options, name, textToDisplay, defaultValue, valueToReturn } = props;
  const handleChange = (e, newValue) => {
    if (newValue) {
      props.handleChange(newValue[valueToReturn]);
    } else {
      props.handleChange("");
    }
  };
  return (
    <Autocomplete
      id={name}
      defaultValue={defaultValue}
      options={options}
      onChange={handleChange}
      getOptionLabel={(option) => option[textToDisplay]}
      renderInput={(params) => (
        <TextField {...params} label={name} variant="outlined" />
      )}
    />
  );
}
InputAutoComplete.defaultProps = {
  options: [],
  name: "auto-complete",
  textToDisplay: "value",
};

export { InputAutoComplete };
