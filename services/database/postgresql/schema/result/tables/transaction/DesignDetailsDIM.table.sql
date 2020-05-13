CREATE TABLE "Result"."DesignDetailsDIM"
(
    "Key" character varying(50) NOT NULL,
    "Name" character varying(50),
    "PrimaryEndpoint" character varying(50),
    "NumberOfArms" smallint,
    "RegulatoryRiskAssessment" character varying(50),
    "StatisticalDesign" character varying(50),
    "Hypothesis" character varying(50),
    "NumberOfEvents" smallint,
    "SampleSize" smallint,
    "AllocationRatio" real[],
    "SubjectsAreFollowedType" character varying(50),
    "SubjectsAreFollowedPeriod" smallint,
    "Type1Error" real,
    "TestStatistics" character varying(50),
    "TestType" character varying(50),
    "TailType" character varying(50),
    "NonInferiorityMargin" real,
    "CriticalPoint" character varying(50),
    "NumberOfInterimAnalysis" smallint,
    "InterimAnalysesSpacing" real[],
    "BoundaryFamily" character varying(50),
    "SpendingFunction" character varying(50),
    "Parameters" character varying(10),
    "BoundaryScale" character varying(10),
    "MaxNumEventsIfAdapt" integer,
    "MaxSampleSizeIfAdapt" integer,
    "UpperLimitStudyDuration" integer,
    "TargetCPforReEstimatingNumEvents" real,
    "PromisingZoneMinConditionalPower" real,
    "PromisingZoneMaxConditionalPower" real,
    "FixedAccrualRateUsedAfterAdapt" real,
    PRIMARY KEY ("Key")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;