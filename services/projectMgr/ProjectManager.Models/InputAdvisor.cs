using Newtonsoft.Json.Linq;
using ProjectManager.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public class InputAdvisor
    {
        [Required(ErrorMessage = ValidationErrors.PROJECT_ID_REQUIRED_VAL_MSG)]
        [Range(1, int.MaxValue, ErrorMessage = ValidationErrors.RANGE_VALIDATION_ERROR_MSG)]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = ValidationErrors.INPUT_ADVISOR_OBJECT_REQUIRED_VAL_MSG)]
        public JObject Object { get; set; }

        [Required(ErrorMessage = ValidationErrors.RESOURCE_ID_REQUIRED_VAL_MSG)]
        [Range(1, int.MaxValue, ErrorMessage = ValidationErrors.RANGE_VALIDATION_ERROR_MSG)]
        public int ResourceID { get; set; }

        [Required(ErrorMessage = ValidationErrors.CREATED_BY_REQUIRED_VAL_MSG)]
        [StringLength(50, ErrorMessage = ValidationErrors.CREATED_BY_LENGTH_VAL_MSG)]
        public string CreatedBy { get; set; }
    }
}
