-- FUNCTION: project.is_project_id_exists_for_resource_id(integer, integer)

-- DROP FUNCTION project.is_project_id_exists_for_resource_id(integer, integer);

CREATE OR REPLACE FUNCTION project.is_project_id_exists_for_resource_id(
	project_id integer,
	resource_id integer)
    RETURNS boolean
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE is_project_id_exists_for_resource_id boolean = false;
BEGIN
IF EXISTS (SELECT 1 FROM project."Project" WHERE "ID" = project_id AND "ResourceID" = resource_id) THEN
  is_project_id_exists_for_resource_id = true;
END IF;

Return is_project_id_exists_for_resource_id;

END
$BODY$;