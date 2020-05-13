-- Table: project."InputAdvisorSchema"

-- DROP TABLE project."InputAdvisorSchema";

CREATE TABLE project."InputAdvisorSchema"
(
    "Version" character varying(30) NOT NULL,
    "Template" json,
    "ReleaseDate" timestamp without time zone,
    CONSTRAINT "InputAdvisorSchema_pkey" PRIMARY KEY ("Version")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."InputAdvisorSchema"
    IS 'Project Management';