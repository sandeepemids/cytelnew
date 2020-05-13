import React from "react";
import TextField from "@material-ui/core/TextField";
import Autocomplete, {
  createFilterOptions,
} from "@material-ui/lab/Autocomplete";

const filter = createFilterOptions();

function CreateProgram(props) {
  const {
    id,
    options,
    name,
    textToDisplay,
    defaultValue,
    valueToReturn,
    handleChange,
  } = props;

  const handleProgramChange = (e, newValue) => {
    if (newValue) {
      handleChange(newValue[valueToReturn]);
    } else {
      handleChange("");
    }
  };
  return (
    <Autocomplete
      error={"true"}
      id={id}
      disableListWrap={true}
      defaultValue={defaultValue}
      options={options}
      onChange={handleProgramChange}
      filterOptions={(options, params) => {
        const filtered = filter(options, params);
        const noOptions = filtered.length === 0;

        if (params.inputValue !== "" && noOptions) {
          filtered.push({
            id: params.inputValue,
            name: `Add "${params.inputValue}"`,
          });
        }
        return filtered;
      }}
      getOptionLabel={(option) => {
        if (typeof option.id === "string") {
          return option.id;
        }
        if (option[textToDisplay]) {
          return option[textToDisplay];
        }
        return option[textToDisplay];
      }}
      renderOption={(option) => option[textToDisplay]}
      renderInput={(params) => (
        <TextField {...params} label={name} variant="outlined" />
      )}
    />
  );
}
CreateProgram.defaultProps = {
  options: [],
  name: "auto-complete-with-free-text",
  textToDisplay: "value",
  handleChange: () => {},
};

export { CreateProgram };
