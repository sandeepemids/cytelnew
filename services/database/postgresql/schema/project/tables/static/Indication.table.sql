-- Table: project."Indication"

-- DROP TABLE project."Indication";

CREATE TABLE project."Indication"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(150) NOT NULL,
    CONSTRAINT "Indication_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Indication"
    IS 'Project Management';

COMMENT ON COLUMN project."Indication"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."Indication"."Value"
    IS 'Indication Value';