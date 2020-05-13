-- FUNCTION: project.get_indication_list()

-- DROP FUNCTION project.get_indication_list();

CREATE OR REPLACE FUNCTION project.get_indication_list(
	)
    RETURNS SETOF project."Indication" 
    LANGUAGE 'sql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
SELECT * FROM project."Indication"
$BODY$;