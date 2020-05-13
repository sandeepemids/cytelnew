-- Table: project."DropoutInputMethod"

-- DROP TABLE project."DropoutInputMethod";

CREATE TABLE project."DropoutInputMethod"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30),
    CONSTRAINT "DropoutInputMethod_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."DropoutInputMethod"
    IS 'Project Management';