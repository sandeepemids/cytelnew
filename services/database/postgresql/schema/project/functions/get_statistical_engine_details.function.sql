-- FUNCTION: project.get_statistical_engine_details(integer)

-- DROP FUNCTION project.get_statistical_engine_details(integer);

CREATE OR REPLACE FUNCTION project.get_statistical_engine_details(
	statisticalengineid integer)
    RETURNS TABLE(engineid integer, name character varying, location character varying, version character varying, schemafilename text) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY(SELECT statisticalengineid, "Name", "Location", "Version", 'FixSampleJsonSchema.json'
				 FROM project."StatisticalEngine" WHERE "ID" = statisticalengineid);
END
$BODY$;

