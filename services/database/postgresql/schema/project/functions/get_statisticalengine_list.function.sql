-- FUNCTION: project.get_statisticalengine_list()

-- DROP FUNCTION project.get_statisticalengine_list();

CREATE OR REPLACE FUNCTION project.get_statisticalengine_list(
	)
    RETURNS TABLE(name character varying, version character varying, releasedate timestamp without time zone) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY(SELECT "Name", "Version", "ReleaseDate" FROM project."StatisticalEngine" ORDER BY "ReleaseDate" DESC );
END
$BODY$;