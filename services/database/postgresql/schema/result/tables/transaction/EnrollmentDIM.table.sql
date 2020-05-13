CREATE TABLE "Result"."EnrollmentDIM"
(
    "Key" character varying(50) NOT NULL,
    "Name" character varying(50),
    "Geography" character varying(50),
    "SiteInitiationTime" smallint,
    "InputMethod" character varying(50),
    "AvgPatientsEnrolled" smallint,
    "EnrollmentCap" real,
    "Distribution" character varying(50),
    PRIMARY KEY ("Key")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;