-- FUNCTION: project.is_project_exists_for_resource_id(integer)

-- DROP FUNCTION project.is_project_exists_for_resource_id(integer);

CREATE OR REPLACE FUNCTION project.is_project_exists_for_resource_id(
	resource_id integer)
    RETURNS boolean
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE is_project_exists_for_resource_id boolean = false;
BEGIN
IF EXISTS (SELECT 1 FROM project."Project" WHERE "ResourceID" = resource_id) THEN
  is_project_exists_for_resource_id = true;
END IF;

Return is_project_exists_for_resource_id;

END

$BODY$;
