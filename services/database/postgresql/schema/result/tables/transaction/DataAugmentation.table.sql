CREATE TABLE "Result"."DataAugmentation"
(
    "ID" serial NOT NULL,
    "SimModelID" uuid NOT NULL,
    "OperationalCostKey" character varying(50),
    "StudyCost" money,
    "MarketAccessKey" character varying(50),
    "eNPV" character varying(50),
    PRIMARY KEY ("ID"),
    CONSTRAINT "FK_DataAugmentation_OperationalCostKey" FOREIGN KEY ("OperationalCostKey")
        REFERENCES "Result"."OperationalCostDIM" ("Key") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_DataAugmentation_MarketAccessKey" FOREIGN KEY ("MarketAccessKey")
        REFERENCES "Result"."MarketAccessDIM" ("Key") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_DataAugmentation_SimModelID" FOREIGN KEY ("SimModelID")
        REFERENCES "Result"."SimModelResult" ("SimModelID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

COMMENT ON CONSTRAINT "FK_DataAugmentation_OperationalCostKey" ON "Result"."DataAugmentation"
    IS 'PK to OperationalCostDIM.Key';
COMMENT ON CONSTRAINT "FK_DataAugmentation_MarketAccessKey" ON "Result"."DataAugmentation"
    IS 'PK to MarketAccessDIM.Key';
COMMENT ON CONSTRAINT "FK_DataAugmentation_SimModelID" ON "Result"."DataAugmentation"
    IS 'FK to SimModelResult.SimModelID';