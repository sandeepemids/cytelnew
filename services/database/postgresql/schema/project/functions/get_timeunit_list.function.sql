-- FUNCTION: project.get_timeunit_list()

-- DROP FUNCTION project.get_timeunit_list();

CREATE OR REPLACE FUNCTION project.get_timeunit_list(
	)
    RETURNS SETOF project."ProjectTimeUnit" 
    LANGUAGE 'sql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
SELECT * FROM project."ProjectTimeUnit"
$BODY$;
