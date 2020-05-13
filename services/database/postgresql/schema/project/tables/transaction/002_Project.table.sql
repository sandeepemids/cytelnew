-- Table: project."Project"

-- DROP TABLE project."Project";

CREATE TABLE project."Project"
(
    "ID" serial NOT NULL,
    "Name" character varying(75),
    "ProtocolID" character varying(75),
    "ProgramID" integer,
    "IndicationID" smallint,
    "Phase" smallint,
    "TimeUnitID" smallint,
    "CurrencyID" smallint,
    "ResourceID" integer NOT NULL,
    "CreatedBy" character varying(50) NOT NULL,
    "CreatedTimestamp" timestamp with time zone NOT NULL,
	"ModifiedTimestamp" timestamp with time zone NOT NULL,
    CONSTRAINT "Project_pkey" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_Project_CurrencyID" FOREIGN KEY ("CurrencyID")
        REFERENCES project."Currency" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_Project_IndicationID" FOREIGN KEY ("IndicationID")
        REFERENCES project."Indication" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_Project_ProgramID" FOREIGN KEY ("ProgramID")
        REFERENCES project."Program" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_Project_TimeUnitID" FOREIGN KEY ("TimeUnitID")
        REFERENCES project."ProjectTimeUnit" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Project"
    IS 'Project Management';

COMMENT ON COLUMN project."Project"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."Project"."ProgramID"
    IS 'FK to Program.ID';

COMMENT ON COLUMN project."Project"."IndicationID"
    IS 'FK to Indication.ID';

COMMENT ON COLUMN project."Project"."TimeUnitID"
    IS 'FK to ProjectTimeUnit.ID';

COMMENT ON COLUMN project."Project"."CurrencyID"
    IS 'Fk to Currency.ID';

COMMENT ON CONSTRAINT "FK_Project_CurrencyID" ON project."Project"
    IS 'FK to Currency.ID';
COMMENT ON CONSTRAINT "FK_Project_IndicationID" ON project."Project"
    IS 'FK to Indication.ID';
COMMENT ON CONSTRAINT "FK_Project_ProgramID" ON project."Project"
    IS 'FK to Program.ID';
COMMENT ON CONSTRAINT "FK_Project_TimeUnitID" ON project."Project"
    IS 'FK to ProjectTimeUnit.ID';