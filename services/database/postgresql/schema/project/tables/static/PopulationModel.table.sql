-- Table: project."PopulationModel"

-- DROP TABLE project."PopulationModel";

CREATE TABLE project."PopulationModel"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30),
    CONSTRAINT "PopulationModel_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."PopulationModel"
    IS 'Project Management';