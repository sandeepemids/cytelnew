-- PROCEDURE: project.update_project_status(integer, integer, integer, character varying)

-- DROP PROCEDURE project.update_project_status(integer, integer, integer, character varying);

CREATE OR REPLACE PROCEDURE project.update_project_status(
	project_id integer,
	status_id integer,
	resource_id integer,
	created_by character varying)
LANGUAGE 'plpgsql'

AS $BODY$
BEGIN
   -- Updating current indicator
    UPDATE project."ProjectStatus"
    SET "CurrentIndicator" =false
    WHERE "ProjectID" = project_id AND "ResourceID"=resource_id;
;
 
    CALL project.create_project_status(project_id,status_id,resource_id,created_by);

    COMMIT;
END;
$BODY$;