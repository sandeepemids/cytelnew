-- Table: project."Status"

-- DROP TABLE project."Status";

CREATE TABLE project."Status"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(20) NOT NULL,
    CONSTRAINT "Status_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Status"
    IS 'Project Management ';

COMMENT ON COLUMN project."Status"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."Status"."Value"
    IS 'Status Type ';