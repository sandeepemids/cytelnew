CREATE TABLE "Result"."MarketAccessDIM"
(
    "Key" character varying(50) NOT NULL,
    "Name" character varying(50),
    "Endpoint" character varying(50),
    "AnnualRevenueInPeakYear" money,
    "TimeToPeakAnnualRevenue" smallint,
    "ProportionOfResidualSales" smallint,
    "AnticipatedTreatmentEffect" real,
    "TimeToPatentExpiry" smallint,
    "DiscountRate" real,
    PRIMARY KEY ("Key")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;