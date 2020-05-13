-- Table: project."Endpoint"

-- DROP TABLE project."Endpoint";

CREATE TABLE project."Endpoint"
(
    "ID" smallserial NOT NULL,
    "Name" character varying(50),
    "Type" character varying(30),
    CONSTRAINT "Endpoint_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Endpoint"
    IS 'Project Management';