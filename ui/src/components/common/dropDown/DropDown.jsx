import React from "react";
import MenuItem from "@material-ui/core/MenuItem";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";
import dropDownStyle from "./dropDownStyle";
import { useState } from "react";
import Typography from "@material-ui/core/Typography";

function DropDown(props) {
  const classes = dropDownStyle();
  const [selectedProjectStatusId] = useState(props.initialLoadItemId);

  const handleChange = (event) => {
    props.handleUpdate(event);
  };

  const handleMouseLeave = (event) => {
    props.onMouseLeave(event);
  }

  const { label, id } = props;
  return (
    <FormControl className={classes.formControl}>
      <Select
        labelId={label}
        id={id}
        value={selectedProjectStatusId}
        onChange={(event) => handleChange(event)}
        variant="outlined"
        fullWidth={true}
        onMouseLeave={(event) => handleMouseLeave(event)}
      >
        {props.data.map((_item) => {
          return (
            <MenuItem key={_item.id} value={_item.id}>
              <Typography id="producStatus" variant="body2">
                {_item.value}
              </Typography>
            </MenuItem>
          );
        })}
      </Select>
    </FormControl>
  );
}

DropDown.defaultProps = {
  label: "Default Label",
  id: "no-id",
  data: [],
  initialLoadItemId: 0,
  value: "value",
};

export { DropDown };
