CREATE TABLE "Result"."SimModelResult"
(
    "SimModelID" uuid NOT NULL,
    "ProjectSimulationID" integer NOT NULL,
    "StudyDuration" character varying(50),
    "FollowupTime" character varying(50),
    "AccrualDuration" character varying(50),
    "Dropout" character varying(50),
    "Events" real[],
    "Power" character varying(50),
    "SampleSize" character varying(50),
    "SimSeed" integer,
    "EnrollmentKey" character varying(50),
    "PopulationKey" character varying(50),
    "DesignKey" character varying(50),
    "OutputBoundaries" character varying(50)[],
    "Object" jsonb,
    PRIMARY KEY ("SimModelID"),
    CONSTRAINT "FK_SimModelResult_DesignKey" FOREIGN KEY ("DesignKey")
        REFERENCES "Result"."DesignDetailsDIM" ("Key") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_SimModelResult_EnrollmentKey" FOREIGN KEY ("EnrollmentKey")
        REFERENCES "Result"."EnrollmentDIM" ("Key") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_SimModelResult_PopulationKey" FOREIGN KEY ("PopulationKey")
        REFERENCES "Result"."PopulationDIM" ("Key") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_SimModelResult_ProjectSimulationID" FOREIGN KEY ("ProjectSimulationID")
        REFERENCES simulation."ProjectSimulation" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON CONSTRAINT "FK_SimModelResult_DesignKey" ON "Result"."SimModelResult"
    IS 'FK to DesignDetailsDIM.Key';
COMMENT ON CONSTRAINT "FK_SimModelResult_EnrollmentKey" ON "Result"."SimModelResult"
    IS 'FK to EnrollmentDIM.Key';
COMMENT ON CONSTRAINT "FK_SimModelResult_PopulationKey" ON "Result"."SimModelResult"
    IS 'FK to PopulationDIM.Key';
COMMENT ON CONSTRAINT "FK_SimModelResult_ProjectSimulationID" ON "Result"."SimModelResult"
    IS 'FK to ProjectSimulation.ID';