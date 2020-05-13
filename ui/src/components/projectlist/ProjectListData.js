function createData(id, name, program, created, lastModified, status) {
  return { id, name, program, created, lastModified, status };
}

const rows = [
  createData(
    "1",
    "E502-5122-001 - Multiple Myeloma",
    "Orange",
    "20-MAR-2019",
    "20-APR-2019",
    "In Progress"
  ),
  createData(
    "2",
    "E502-5122-002 - T-Cell Lymphoma",
    "Orange",
    "12-JAN-2019",
    "20-FEB-2019",
    "In Progress"
  ),
  createData(
    "3",
    "E526-4930-001 - Cervical Cancer",
    "Black",
    "02-JUN-2019",
    "20-JUL-2019",
    "In Progress"
  ),
  createData(
    "4",
    "E532-5090-001 - Hematological Malignancies",
    "Green",
    "11-APR-2019",
    "20-MAY-2019",
    "In Progress"
  )
];

export default rows;
