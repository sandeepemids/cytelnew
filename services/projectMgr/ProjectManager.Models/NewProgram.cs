using ProjectManager.Constants;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public class NewProgram
    {
        [Required(ErrorMessage = ValidationErrors.PROGRAM_NAME_REQUIRED_VAL_MSG)]
        [StringLength(75, ErrorMessage = ValidationErrors.PROGRAM_NAME_LENGTH_VAL_MSG)]
        public string ProgramName { get; set; }

        [Required(ErrorMessage = ValidationErrors.RESOURCE_ID_REQUIRED_VAL_MSG)]
        public int ResourceID { get; set; }

        [Required(ErrorMessage = ValidationErrors.CREATED_BY_REQUIRED_VAL_MSG)]
        public string CreatedBy { get; set; }

    }
}
