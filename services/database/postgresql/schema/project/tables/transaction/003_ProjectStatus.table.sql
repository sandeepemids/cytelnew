-- Table: project."ProjectStatus"

-- DROP TABLE project."ProjectStatus";

CREATE TABLE project."ProjectStatus"
(
    "ID" serial NOT NULL,
    "ProjectID" integer NOT NULL,
    "StatusID" smallint NOT NULL,
    "CurrentIndicator" boolean,
    "ResourceID" integer NOT NULL,
    "CreatedBy" character varying(50) NOT NULL,
    "CreatedTimestamp" timestamp with time zone NOT NULL,
    CONSTRAINT "ProjectStatus_pkey" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_ProjectStatus_ProjectID" FOREIGN KEY ("ProjectID")
        REFERENCES project."Project" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_ProjectStatus_StatusID" FOREIGN KEY ("StatusID")
        REFERENCES project."Status" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."ProjectStatus"
    IS 'Project Management';

COMMENT ON COLUMN project."ProjectStatus"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."ProjectStatus"."ProjectID"
    IS 'FK to Project.ID';

COMMENT ON COLUMN project."ProjectStatus"."StatusID"
    IS 'FK to Status.ID';

COMMENT ON CONSTRAINT "FK_ProjectStatus_ProjectID" ON project."ProjectStatus"
    IS 'FK to Project.ID';
COMMENT ON CONSTRAINT "FK_ProjectStatus_StatusID" ON project."ProjectStatus"
    IS 'FK to Status.ID';