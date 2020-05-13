CREATE TABLE "Result"."PopulationDIM"
(
    "Key" character varying(50) NOT NULL,
    "EndpointName" character varying(50),
    "EndpointType" character varying(50),
    "PopulationName" character varying(50),
    "VirtualPopulationSize" integer,
    "PopulationModel" character varying(50),
    "InputMethod" character varying(50),
    "NumberOfPieces" smallint,
    "PopulationControl" real,
    "PopulationTreatment" real[],
    "PopulationHazardRatio" real[],
    "Treatment" character varying(30)[],
    "DropoutModel" character varying(50),
    "DropoutInputMethod" character varying(50),
    "DropoutNumberOfPieces" smallint,
    "DropoutByTime" smallint,
    "DropoutControl" real[],
    "DropoutTreatment" real[],
    PRIMARY KEY ("Key")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;