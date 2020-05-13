-- FUNCTION: project.get_program_list(integer, integer, boolean)

-- DROP FUNCTION project.get_program_list(integer, integer, boolean);

CREATE OR REPLACE FUNCTION project.get_program_list(
	program_id integer,
	resource_id integer,
	list_all_programs boolean)
    RETURNS TABLE(programid integer, programname character varying, createdby character varying, resourceid integer) 
    LANGUAGE 'sql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
    SELECT
        PR. "ID",
        PR. "Name",
		PR."CreatedBy",
		PR."ResourceID"
    FROM
         project. "Program" PR
    WHERE PR."ID"=program_id OR 
	(PR."ResourceID" = resource_id AND list_all_programs=true)
	
$BODY$;