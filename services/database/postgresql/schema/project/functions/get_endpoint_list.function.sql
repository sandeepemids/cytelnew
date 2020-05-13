-- FUNCTION: project.get_endpoint_list()

-- DROP FUNCTION project.get_endpoint_list();

CREATE OR REPLACE FUNCTION project.get_endpoint_list(
	)
    RETURNS TABLE(id smallint, name character varying, type character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY(SELECT "ID", "Name", "Type" FROM project."Endpoint");
END
$BODY$;
