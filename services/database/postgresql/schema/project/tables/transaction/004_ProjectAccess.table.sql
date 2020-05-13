-- Table: project."ProjectAccess"

-- DROP TABLE project."ProjectAccess";

CREATE TABLE project."ProjectAccess"
(
    "ID" serial NOT NULL,
    "ProjectID" integer NOT NULL,
    "User" character varying(50) NOT NULL,
    "ResourceID" integer NOT NULL,
    "CreatedBy" character varying(50) NOT NULL,
    "CreatedTimestamp" timestamp with time zone NOT NULL,
    CONSTRAINT "ProjectAccess_pkey" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_ProjectAccess_ProjectID" FOREIGN KEY ("ProjectID")
        REFERENCES project."Project" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."ProjectAccess"
    IS 'Project Management';

COMMENT ON COLUMN project."ProjectAccess"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."ProjectAccess"."ProjectID"
    IS 'FK to Project.ID';

COMMENT ON CONSTRAINT "FK_ProjectAccess_ProjectID" ON project."ProjectAccess"
    IS 'FK to Project.ID';