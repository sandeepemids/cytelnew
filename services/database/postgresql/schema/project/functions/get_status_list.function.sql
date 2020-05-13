-- FUNCTION: project.get_status_list()

-- DROP FUNCTION project.get_status_list();

CREATE OR REPLACE FUNCTION project.get_status_list(
	)
    RETURNS SETOF project."Status" 
    LANGUAGE 'sql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
SELECT * FROM project."Status"
$BODY$;