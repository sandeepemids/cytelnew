import React from "react";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardContent from "@material-ui/core/CardContent";
import Grid from "@material-ui/core/Grid";
import modelStyle from "./modelStyle";
import { InputText } from "../../common/inputText";

function Model(props) {
  const classes = modelStyle();



  return (
    <Card className={classes.root} id="operationalModel">
      <CardHeader id="operationalHeader" title={props.modelDetails.name || "Model"} />
      <CardContent className={classes.cardContent}>
        <Grid container spacing={2}>
          <Grid item md={4}>
            <InputText
              id="nameId"
              label="Name"
              value={props.modelDetails.name}
              handleChange={props.handleOperationalCosts}
              name={props.setName}
              handleBlur={props.handleBlur}
              error={props.isNameValid}
              helperText={props.nameHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.nameTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="costPerPatientId"
              label={"Cost per Patient per " + props.timeUnitValue}
              value={props.modelDetails.costPerPatient}
              handleChange={props.handleOperationalCosts}
              handleBlur={props.handleBlur}
              name={props.setCostPerPatient}
              error={props.isCostPerPatientValid}
              helperText={props.costPerPatientHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.costPerPatientTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="fixedCostId"
              label={"Fixed Cost per " + props.timeUnitValue}
              value={props.modelDetails.fixedCost}
              handleChange={props.handleOperationalCosts}
              handleBlur={props.handleBlur}
              name={props.setFixedCost}
              isDisabled={!props.isEditMode}
              tabIndex={props.fixedCostTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="interimLookCostId"
              label="Cost per Interim Analysis"
              value={props.modelDetails.interimLookCost}
              handleChange={props.handleOperationalCosts}
              handleBlur={props.handleBlur}
              name={props.setInterimLookCost}
              error={props.isInterimLookCostValid}
              helperText={props.interimLookCostHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.interimLookCostTabIndex}
            ></InputText>
          </Grid>
        </Grid>
      </CardContent>
    </Card>
  );
}

export { Model };
