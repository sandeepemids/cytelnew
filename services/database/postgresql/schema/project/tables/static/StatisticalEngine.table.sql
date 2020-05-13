-- Table: project."StatisticalEngine"

-- DROP TABLE project."StatisticalEngine";

CREATE TABLE project."StatisticalEngine"
(
    "ID" smallserial NOT NULL,
    "Name" character varying(30) NOT NULL,
    "Schema" json,
    "Template" json,
    "UiSchema" json,
    "DefaultFormData" json,
    "Help" jsonb,
    "Location" character varying(30),
    "Version" character varying(30) NOT NULL,
    "ReleaseDate" timestamp without time zone,
    CONSTRAINT "StatisticalEngine_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."StatisticalEngine"
    IS 'Project Management';