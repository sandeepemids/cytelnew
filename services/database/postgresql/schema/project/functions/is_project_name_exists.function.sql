-- FUNCTION: project.is_project_name_exists(character varying)

-- DROP FUNCTION project.is_project_name_exists(character varying);

CREATE OR REPLACE FUNCTION project.is_project_name_exists(
	project_name character varying)
    RETURNS boolean
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE is_project_name_exists boolean = false;
BEGIN
IF EXISTS (SELECT 1 FROM project."Project" WHERE lower("Name") = lower(project_name)) THEN
  is_project_name_exists = true;
END IF;

Return is_project_name_exists;

END

$BODY$;