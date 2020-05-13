import React from "react";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardContent from "@material-ui/core/CardContent";
import Grid from "@material-ui/core/Grid";
import marketAccessModelStyle from "./marketAccessModelStyle";
import { InputText } from "../../common/inputText";
import { InputSelect } from "../../common/inputSelect";

function MarketAccessModel(props) {
  const classes = marketAccessModelStyle();

  return (
    <Card className={classes.root} id="marketAccessModel">
      <CardHeader
        id="marketAccessHeader"
        title={props.modelDetails.name || "Model"}
      />
      <CardContent className={classes.cardContent}>
        <Grid container spacing={2}>
          <Grid item md={4}>
            <InputText
              id="nameId"
              label="Name"
              value={props.modelDetails.name}
              handleChange={props.handleChangeEvent}
              name={props.setName}
              handleBlur={props.handleBlur}
              error={props.nameValid}
              helperText={props.nameHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.nameTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputSelect
              name={props.setEndpoint}
              Label="Endpoint"
              options={props.setEndpointControlValues}
              isDisabled={!props.isEditMode}
              textToDisplay={props.textToDisplay}
              handleChange={(event) => props.handleInputSelectChange(event)}
              id="endPoint"
              value={props.dropdownSelectedValue}
              handleBlur={props.handleBlur}
              error={props.endpointValid}
              helperText={props.endpointHelperText}
              valueToReturn={props.valueToReturn}
              tabIndex={props.endpointTabIndex}
            />
          </Grid>
          <Grid item md={4}>
            <InputText
              id="annualRevenueInPeakYearId"
              label="Annual Revenue in Peak Year"
              value={props.modelDetails.annualRevenueInPeakYear}
              handleChange={props.handleChangeEvent}
              handleBlur={props.handleBlur}
              name={props.setAnnualRevenueInPeakYear}
              error={props.annualRevenueInPeakYearValid}
              helperText={props.annualRevenueInPeakYearHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.annualRevenueInPeakYearTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="timeToPeakAnnualRevenueId"
              label="Time to Peak Annual Revenue (Yrs)"
              value={props.modelDetails.timeToPeakAnnualRevenue}
              handleChange={props.handleChangeEvent}
              handleBlur={props.handleBlur}
              name={props.setTimeToPeakAnnualRevenue}
              error={props.timeToPeakAnnualRevenueValid}
              helperText={props.timeToPeakAnnualRevenueHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.timeToPeakAnnualRevenueTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="proportionOfResidualSalesId"
              label="Proportion of Residual Sales (%)"
              value={props.modelDetails.proportionOfResidualSales}
              handleChange={props.handleChangeEvent}
              handleBlur={props.handleBlur}
              name={props.setProportionOfResidualSales}
              error={props.proportionOfResidualSalesValid}
              helperText={props.proportionOfResidualSalesHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.proportionOfResidualSalesTabIndex}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="anticipatedTreatmentEffectId"
              label="Anticipated Treatment Effect (HR)"
              value={props.modelDetails.anticipatedTreatmentEffect}
              handleChange={props.handleChangeEvent}
              handleBlur={props.handleBlur}
              name={props.setAnticipatedTreatmentEffect}
              error={props.anticipatedTreatmentEffectValid}
              helperText={props.anticipatedTreatmentEffectHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.anticipatedTreatmentEffect}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="timeToPatentExpiryId"
              label="Time to Patent Expiry (Yrs)"
              value={props.modelDetails.timeToPatentExpiry}
              handleChange={props.handleChangeEvent}
              handleBlur={props.handleBlur}
              name={props.setTimeToPatentExpiry}
              error={props.timeToPatentExpiryValid}
              helperText={props.timeToPatentExpiryHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.timeToPatentExpiry}
            ></InputText>
          </Grid>
          <Grid item md={4}>
            <InputText
              id="discountRateId"
              label="Discount Rate (%)"
              value={props.modelDetails.discountRate}
              handleChange={props.handleChangeEvent}
              handleBlur={props.handleBlur}
              name={props.setDiscountRate}
              error={props.discountRateValid}
              helperText={props.discountRateHelperText}
              isDisabled={!props.isEditMode}
              tabIndex={props.discountRate}
            ></InputText>
          </Grid>
        </Grid>
      </CardContent>
    </Card>
  );
}

export { MarketAccessModel };
