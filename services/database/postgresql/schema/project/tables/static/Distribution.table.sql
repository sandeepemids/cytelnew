-- Table: project."Distribution"

-- DROP TABLE project."Distribution";

CREATE TABLE project."Distribution"
(
    "ID" smallserial NOT NULL,
    "Value" character varying(30),
    CONSTRAINT "Distribution_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Distribution"
    IS 'Project Management';