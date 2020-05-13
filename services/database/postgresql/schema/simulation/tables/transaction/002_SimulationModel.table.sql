-- Table: simulation."SimulationModel"

-- DROP TABLE simulation."SimulationModel";

CREATE TABLE simulation."SimulationModel"
(
    "ID" uuid NOT NULL,
    "ProjectSimulationID" integer NOT NULL,
    "Object" jsonb,
    "SimulationState" "char",
    "ResourceID" integer NOT NULL,
    CONSTRAINT "SimulationModel_pkey" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_SimulationModel_ProjectSimulationID" FOREIGN KEY ("ProjectSimulationID")
        REFERENCES simulation."ProjectSimulation" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE simulation."SimulationModel"
    IS 'Simulation Service';

COMMENT ON CONSTRAINT "FK_SimulationModel_ProjectSimulationID" ON simulation."SimulationModel"
    IS 'FK to ProjectSimulation.ID';