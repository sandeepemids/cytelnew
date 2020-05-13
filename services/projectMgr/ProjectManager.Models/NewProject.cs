using ProjectManager.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public class NewProject
    {
        [Required(ErrorMessage = ValidationErrors.PROJECT_NAME_REQUIRED_VAL_MSG)]
        [StringLength(75, ErrorMessage = ValidationErrors.PROJECT_NAME_LENGTH_VAL_MSG)]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = ValidationErrors.PROTOCOL_ID_REQUIRED_VAL_MSG)]
        [RegularExpression(@"^[a-zA-Z0-9]*$",
                            ErrorMessage = ValidationErrors.PROTOCOL_ID_CHAR_VAL_MSG)]
        [StringLength(75, ErrorMessage = ValidationErrors.PROTOCOL_ID_LENGTH_VAL_MSG)]
        public string ProtocolID { get; set; }

        [Required(ErrorMessage = ValidationErrors.PROGRAM_ID_REQUIRED_VAL_MSG)]
        public int ProgramID { get; set; }

        [Required(ErrorMessage = ValidationErrors.INDICATION_ID_REQUIRED_VAL_MSG)]
        public Int16 IndicationID { get; set; }

        [Required(ErrorMessage = ValidationErrors.PHASE_ID_REQUIRED_VAL_MSG)]
        public Int16 Phase { get; set; }

        [Required(ErrorMessage = ValidationErrors.CURRENCY_ID_REQUIRED_VAL_MSG)]
        public Int16 CurrencyID { get; set; }

        [Required(ErrorMessage = ValidationErrors.TIME_UNIT_ID_REQUIRED_VAL_MSG)]
        public Int16 TimeUnitID { get; set; }

        [Required(ErrorMessage = ValidationErrors.RESOURCE_ID_REQUIRED_VAL_MSG)]
        public int ResourceID { get; set; }

        [Required(ErrorMessage = ValidationErrors.CREATED_BY_REQUIRED_VAL_MSG)]
        public string CreatedBy { get; set; }
    }
}
