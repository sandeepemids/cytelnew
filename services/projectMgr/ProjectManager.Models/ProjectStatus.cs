using ProjectManager.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public class ProjectStatus
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ValidationErrors.RANGE_VALIDATION_ERROR_MSG)]
        public int ProjectID { get; set; }

        [Required]
        [Range(1, 3)]
        public Int16 StatusID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ValidationErrors.RANGE_VALIDATION_ERROR_MSG)]
        public int ResourceID { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}
