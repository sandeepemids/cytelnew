-- Table: project."DropoutModel"

-- DROP TABLE project."DropoutModel";

CREATE TABLE project."DropoutModel"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30),
    CONSTRAINT "DropoutModel_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."DropoutModel"
    IS 'Project Management';