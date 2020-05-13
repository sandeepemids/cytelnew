-- Table: project."ProjectTimeUnit"

-- DROP TABLE project."ProjectTimeUnit";

CREATE TABLE project."ProjectTimeUnit"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30) NOT NULL,
    CONSTRAINT "ProjectTimeUnit_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."ProjectTimeUnit"
    IS 'Project Management';

COMMENT ON COLUMN project."ProjectTimeUnit"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."ProjectTimeUnit"."Value"
    IS 'TimeUnit Value';