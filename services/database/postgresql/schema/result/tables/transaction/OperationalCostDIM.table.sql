CREATE TABLE "Result"."OperationalCostDIM"
(
    "Key" character varying(50) NOT NULL,
    "Name" character varying(50),
    "CostPerPatient" money,
    "FixedCost" money,
    "CostPerInterimLook" money,
    PRIMARY KEY ("Key")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;