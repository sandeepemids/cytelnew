import React from "react";
import scenarioStyle from "./scenarioStyle";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardContent from "@material-ui/core/CardContent";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Box from "@material-ui/core/Box";
import Grid from "@material-ui/core/Grid";
import { InputText } from "../../common/inputText";
import { EndPoint } from "./endPoint";
import { DropOutRate } from "./dropOutRate";
import POPULATION from "../constants";

const TabPanel = (props) => {
  const { children, value, index } = props;
  return (
    <div role="tabpanel" hidden={value !== index}>
      {value === index && <Box>{children}</Box>}
    </div>
  );
};

function Scenario(props) {
  const [value, setValue] = React.useState(0);
  const { tabs, populationObj } = props;
  const classes = scenarioStyle();

  const handleTabChange = (event, newValue) => {
    setValue(newValue);
  };

  const virtualPopulationSize =
    props.populationObj && props.populationObj[0].virtualPopulationSize;
  const name = props.populationObj && props.populationObj[0].name;

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    props.handleInputChange(id, value);
  };
  const error = (props.populationObj && props.populationObj[0].error) || [];
  const nameError = error.find((item) => item.field === "name");
  const virtualPopulationError = error.find(
    (item) => item.field === "virtualPopulationSize"
  );

  const handleInputError = (field, value, msg) => {
    let message = msg || "";
    !value && (message = POPULATION.ERR_MSGS[field]);
    const isScenario = field === "name" || field === "virtualPopulationSize";
    const isEndPointModel = field === "control" || field === "hazardRatio";
    const isDropOutModel =
      field === "byTime" ||
      field === "dropOutControl" ||
      field === "dropOutTreatment";
    props.handleError(
      field,
      message,
      isScenario,
      isEndPointModel,
      isDropOutModel
    );
  };

  const handleBlur = (e) => {
    const { id, value } = e.target;
    handleInputError(id, value);
  };

  return (
    <Card className={classes.root}>
      <CardHeader className={classes.cardHeader} title={name || "Scenario"} />
      <Grid container spacing={2} className={classes.cardHeaderElement}>
        <Grid item md={4}>
          <InputText
            error={nameError && true}
            value={name}
            id="name"
            label="Name"
            helperText={nameError && nameError.message}
            handleChange={handleInputChange}
            handleBlur={handleBlur}
            tabIndex={1}
          />
        </Grid>
        <Grid item md={4}>
          <InputText
            error={virtualPopulationError && true}
            helperText={
              virtualPopulationError && virtualPopulationError.message
            }
            value={virtualPopulationSize}
            id="virtualPopulationSize"
            label="Virtual Population Size"
            handleChange={handleInputChange}
            handleBlur={handleBlur}
            tabIndex={2}
          />
        </Grid>
      </Grid>
      <CardContent className={classes.cardContent}>
        <Tabs
          value={value}
          onChange={handleTabChange}
          className={classes.cardtab}
        >
          {tabs.map((label, index) => (
            <Tab tabIndex={index + 3} key={label} label={label} />
          ))}
        </Tabs>
        <TabPanel value={value} index={0}>
          <EndPoint
            endpointModel={populationObj && populationObj[0].endpointModel[0]}
            handleInputChange={props.handleInputChange}
            handleInputError={handleInputError}
            error={populationObj && populationObj[0].endpointModel[0].error}
          />
        </TabPanel>
        <TabPanel value={value} index={1}>
          <DropOutRate
            dropoutRateModel={
              populationObj && populationObj[0].dropoutRateModel
            }
            handleInputChange={props.handleInputChange}
            handleInputError={handleInputError}
            error={populationObj[0].dropoutRateModel.error}
          />
        </TabPanel>
      </CardContent>
    </Card>
  );
}

Scenario.defaultProps = {
  tabs: ["Endpoint", "Dropout Rate"],
};

export { Scenario };
