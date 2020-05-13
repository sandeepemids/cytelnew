import React from "react";
import TextField from "@material-ui/core/TextField";
import inputTextStyle from "./InputTextStyle";

function InputText(props) {
  const {
    error,
    type,
    autoComplete,
    autoFocus,
    helperText,
    value,
    label,
    required,
    id,
    handleChange,
    isDisabled,
    onKeyPress,
    name,
    handleBlur,
    tabIndex,
    multiInput,
  } = props;
  const classes = inputTextStyle();
  return (
    <TextField
      required={required}
      error={error}
      id={id}
      label={
        <span>
          {multiInput && <span className={classes.dot}></span>}
          <span>{label}</span>
        </span>
      }
      placeholder={label}
      name={name}
      value={value}
      type={type}
      autoFocus={autoFocus}
      variant="outlined"
      fullWidth
      helperText={helperText || ""}
      autoComplete={autoComplete}
      onChange={handleChange}
      disabled={isDisabled}
      onKeyPress={onKeyPress}
      onBlur={handleBlur}
      inputProps={{
        tabIndex: tabIndex,
      }}
    />
  );
}

InputText.defaultProps = {
  error: false,
  autoComplete: "off",
  helperText: "",
  value: "",
  label: "Default Label",
  type: "test",
  id: "no-id",
  handleChange: () => {},
  isDisabled: false,
};

export { InputText };
