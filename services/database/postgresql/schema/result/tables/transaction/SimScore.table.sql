CREATE TABLE "Result"."SimScore"
(
    "Key" character varying(50) NOT NULL,
    "ProjectSimulationID" integer NOT NULL,
    "MinPower" real,
    "MinSampleSize" real,
    "MinStudyDuration" real,
    "MaxStudyBudget" real,
    "MinProbabilityOfTechSuccess" real,
    "MinProbabilityOfRegSuccess" real,
    "MinProbabilityOfSuccess" real,
    "MaxTimeToFirstApproval" real,
    "MinNetPersentValue" real,
    PRIMARY KEY ("Key"),
    CONSTRAINT "FK_SimScore_ProjectSimulationID" FOREIGN KEY ("ProjectSimulationID")
        REFERENCES simulation."ProjectSimulation" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON CONSTRAINT "FK_SimScore_ProjectSimulationID" ON "Result"."SimScore"
    IS 'FK to ProjectSimulation.ID';