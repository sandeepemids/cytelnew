-- Table: project."InputAdvisor"

-- DROP TABLE project."InputAdvisor";

CREATE TABLE project."InputAdvisor"
(
    "ID" serial NOT NULL,
    "ProjectID" integer NOT NULL,
    "Object" jsonb,
    "ResourceID" integer NOT NULL,
    "CreatedBy" character varying(50) NOT NULL,
    "CreatedTimestamp" timestamp with time zone NOT NULL,
    CONSTRAINT "InputAdvisor_pkey" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_InputAdvisor_ProjectID" FOREIGN KEY ("ProjectID")
        REFERENCES project."Project" ("ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."InputAdvisor"
    IS 'Project Management';

COMMENT ON CONSTRAINT "FK_InputAdvisor_ProjectID" ON project."InputAdvisor"
    IS 'FK to Project.ID';