-- Table: simulation."ProjectSimulation"

-- DROP TABLE simulation."ProjectSimulation";

CREATE TABLE simulation."ProjectSimulation"
(
    "ID" serial NOT NULL,
    "ProjectID" integer NOT NULL,
    "Index" smallint NOT NULL,
    "ModelCount" integer,
    "ResourceID" integer NOT NULL,
    "CreatedBy" character varying(50) NOT NULL,
    "CreatedTimestamp" timestamp with time zone NOT NULL,
    CONSTRAINT "ProjectSimulation_pkey" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_ProjectSimulation_ProjectID" FOREIGN KEY ("ProjectID")
        REFERENCES project."Project" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE simulation."ProjectSimulation"
    IS 'Simulation Service ';

COMMENT ON COLUMN simulation."ProjectSimulation"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN simulation."ProjectSimulation"."ProjectID"
    IS 'FK to Project.ID';

COMMENT ON CONSTRAINT "FK_ProjectSimulation_ProjectID" ON simulation."ProjectSimulation"
    IS 'FK to Project.ID';