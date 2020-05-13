-- FUNCTION: project.is_project_id_exists(integer)

-- DROP FUNCTION project.is_project_id_exists(integer);

CREATE OR REPLACE FUNCTION project.is_project_id_exists(
	project_id integer)
    RETURNS boolean
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE is_project_id_exists boolean = false;
BEGIN
IF EXISTS (SELECT 1 FROM project."Project" WHERE "ID" = project_id) THEN
  is_project_id_exists = true;
END IF;

Return is_project_id_exists;

END

$BODY$;
