-- FUNCTION: project.get_currency_list()

-- DROP FUNCTION project.get_currency_list();

CREATE OR REPLACE FUNCTION project.get_currency_list(
	)
    RETURNS SETOF project."Currency" 
    LANGUAGE 'sql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
SELECT * FROM project."Currency"
$BODY$;