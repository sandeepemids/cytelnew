-- Table: project."EnrollmentInputMethod"

-- DROP TABLE project."EnrollmentInputMethod";

CREATE TABLE project."EnrollmentInputMethod"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30),
    CONSTRAINT "EnrollmentInputMethod_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."EnrollmentInputMethod"
    IS 'Project Management';