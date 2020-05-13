-- Table: project."Currency"

-- DROP TABLE project."Currency";

CREATE TABLE project."Currency"
(
    "ID" serial NOT NULL,
    "Value" character varying(30) NOT NULL,
    CONSTRAINT "Currency_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Currency"
    IS 'Project Management';

COMMENT ON COLUMN project."Currency"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."Currency"."Value"
    IS 'Currency Name';