import React from "react";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardContent from "@material-ui/core/CardContent";
import IconButton from "@material-ui/core/IconButton";
import Grid from "@material-ui/core/Grid";
import endPointStyle from "./endPointStyle";
import { InputText } from "../../common/inputText";
import { InputSelect } from "../../common/inputSelect";
import { faEllipsisH } from "@fortawesome/pro-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { FormattedMessage, useIntl} from "react-intl";

function EndPoint(props) {
  const { formatMessage } = useIntl();
  const classes = endPointStyle();
  const handleChange = () => {};

  return (
    <Card className={classes.root} id="objectEndpoint">
      <CardHeader
        id="objectiveHeader"
        title={<FormattedMessage id="endpoint.endpoint"></FormattedMessage>}
      />
      <CardContent className={classes.cardContent}>
        <Grid container spacing={2}>
          <Grid item md={4}>
            <InputText
              isDisabled={props.isDisabled}
              id="endPointName"
              label={formatMessage({id:"endpoint.name"})}
              value={props.setEndpointControlNameValue}
              name={props.setEndpointControlName}
              handleChange={(event) => props.handleChange(event)}
              handleBlur={(event) => props.handleBlur(event)}
              error={props.isNameValid}
              helperText={props.nameHelperText}
              tabIndex={props.nameTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputSelect
              name={props.setEndpointControlEndpointName}
              options={props.setEndpointControlValues}
              isDisabled={props.isDisabled}
              textToDisplay={props.textToDisplay}
              handleChange={(event) => props.handleInputSelectChange(event)}
              id="endPoint"
              value={props.dropdownSelectedValue}
              handleBlur={(event) => props.handleBlur(event)}
              error={props.isEndpointValid}
              helperText={props.endpointHelperText}
              valueToReturn={props.valueToReturn}
              tabIndex={props.endpointTabIndex}
            />
          </Grid>
          <Grid item md={4}>
            <InputText
              id="type"
              label={formatMessage({id:"endpoint.type"})}
              value={props.setEndpointControlTypeValue}
              name={props.setEndpointControlTypeName}
              handleChange={(event) => props.handleChange(event)}
              handleBlur={(event) => props.handleBlur(event)}
              error={props.isTypeValid}
              helperText={props.typeHelperText}
              isDisabled={true}
              tabIndex={props.typeTabIndex}
            ></InputText>
          </Grid>
        </Grid>
      </CardContent>
    </Card>
  );
}

export { EndPoint };
