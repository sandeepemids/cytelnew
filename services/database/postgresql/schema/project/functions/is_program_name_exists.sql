-- FUNCTION: project.is_program_name_exists(character varying, integer)

-- DROP FUNCTION project.is_program_name_exists(character varying, integer);

CREATE OR REPLACE FUNCTION project.is_program_name_exists(
	program_name character varying,
	resource_id integer)
    RETURNS boolean
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE is_program_name_exists boolean = false;
BEGIN
IF EXISTS (SELECT 1 FROM project."Program" WHERE lower("Name") = lower(program_name) AND "ResourceID"=resource_id) THEN
  is_program_name_exists = true;
END IF;

Return is_program_name_exists;

END

$BODY$;