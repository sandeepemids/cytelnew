const CREATEPROJECT = {
  DEFAULTVALUE: {
    projectName: "",
    protocolID: "",
    programID: "",
    indicationID: "",
    phase: 3,
    timeUnitID: "",
    currencyID: 1,
    createdBy: "User1",
  },
  PHASES: [
    { id: 1, value: 1, disabled: true },
    { id: 2, value: 2, disabled: true },
    { id: 3, value: 3, disabled: false },
    { id: 4, value: 4, disabled: true },
  ],
  FIELDS: {
    projectName: "Project Name",
    protocolID: "Protocol ID",
    phase: "Phase",
    timeUnit: "Time Unit",
    currency: "Currency",
  },
};
export default CREATEPROJECT;
