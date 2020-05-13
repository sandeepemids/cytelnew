-- Table: project."Geography"

-- DROP TABLE project."Geography";

CREATE TABLE project."Geography"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30),
    CONSTRAINT "Geography_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Geography"
    IS 'Project Management';