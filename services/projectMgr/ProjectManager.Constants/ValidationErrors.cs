namespace ProjectManager.Constants
{
    public static class ValidationErrors
    {
        public const string RANGE_VALIDATION_ERROR_MSG = "Please enter a value bigger than {1}";
        public const string STATUS_PROJECT_ID_VAL_MSG = "Project ID {0} Does not exist";
        public const string PROJECT_ID_DOES_NOT_EXISTS_RESOURCE_ID_VAL_MSG = "No Project with Project ID {0} exists for Resource ID {1}";
        public const string PROJECT_DOES_NOT_EXISTS_RESOURCE_ID_VAL_MSG = "No Project exists for Resource ID {0}";

        public const string PROJECT_NAME_LENGTH_VAL_MSG = "Project Name must not exceed 75 characters";
        public const string PROJECT_NAME_EXISTS_VAL_MSG = "Name already exist";
        public const string PROJECT_NAME_REQUIRED_VAL_MSG = "Project name is required";
        public const string PROJECT_ID_REQUIRED_VAL_MSG = "Project ID is required";

        public const string PROTOCOL_ID_CHAR_VAL_MSG = "Special characters are not allowed";
        public const string PROTOCOL_ID_LENGTH_VAL_MSG = "Protocol ID must not exceed 75 characters";
        public const string PROTOCOL_ID_EXIST_VAL_MSG = "Protocol ID already exist";
        public const string PROTOCOL_ID_REQUIRED_VAL_MSG = "Protocol ID is required";

        public const string PROGRAM_NAME_LENGTH_VAL_MSG = "Program Name must not exceed 75 characters";
        public const string PROGRAM_ID_REQUIRED_VAL_MSG = "Program ID is required";
        public const string PROGRAM_NAME_REQUIRED_VAL_MSG = "Program Name is required";

        public const string INDICATION_ID_REQUIRED_VAL_MSG = "Indication ID is required";
        public const string PHASE_ID_REQUIRED_VAL_MSG = "Phase ID is required";
        public const string TIME_UNIT_ID_REQUIRED_VAL_MSG = "Time Unit ID is required";
        public const string CURRENCY_ID_REQUIRED_VAL_MSG = "Currency ID is required";
        public const string RESOURCE_ID_REQUIRED_VAL_MSG = "Resource ID is required";
        public const string CREATED_BY_REQUIRED_VAL_MSG = "Created By is required";
        public const string CREATED_BY_LENGTH_VAL_MSG = "Created By must not exceed 50 characters";

        public const string INPUT_ADVISOR_OBJECT_REQUIRED_VAL_MSG = "Input Advisor Object is required";
        public const string VERSION_REQUIRED_VAL_MSG = "Version is required";
        public const string VERSION_LENGTH_VAL_MSG = "Version must not exceed 50 characters";
    }
}