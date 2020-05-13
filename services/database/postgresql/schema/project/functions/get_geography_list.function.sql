-- FUNCTION: project.get_geography_list()

-- DROP FUNCTION project.get_geography_list();

CREATE OR REPLACE FUNCTION project.get_geography_list(
	)
    RETURNS TABLE(id smallint, value character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY(SELECT "ID", "Value" FROM project."Geography");
END
$BODY$;
