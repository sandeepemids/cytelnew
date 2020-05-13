-- Table: project."Program"

-- DROP TABLE project."Program";

CREATE TABLE project."Program"
(
    "ID" serial NOT NULL,
    "Name" character varying(75) NOT NULL,
    "ResourceID" integer NOT NULL,
	"CreatedBy" character varying(50) NOT NULL,
    "CreatedTimestamp" timestamp with time zone NOT NULL,
    CONSTRAINT "Program_pkey" PRIMARY KEY ("ID")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON TABLE project."Program"
    IS 'Project Management ';

COMMENT ON COLUMN project."Program"."ID"
    IS 'Primary Key Auto increment';

COMMENT ON COLUMN project."Program"."Name"
    IS 'Name given by user for Program ';

COMMENT ON COLUMN project."Program"."CreatedBy"
    IS 'Logged in user account details from Azure AD ';

COMMENT ON COLUMN project."Program"."CreatedTimestamp"
    IS 'Date Time of Record';