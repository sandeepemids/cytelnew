-- Table: project."PopulationInputMethod"

-- DROP TABLE project."PopulationInputMethod";

CREATE TABLE project."PopulationInputMethod"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30),
    CONSTRAINT "PopulationInputMethod_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."PopulationInputMethod"
    IS 'Project Management';