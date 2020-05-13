-- PROCEDURE: project.create_project_status(integer, integer, integer, character varying)

-- DROP PROCEDURE project.create_project_status(integer, integer, integer, character varying);

CREATE OR REPLACE PROCEDURE project.create_project_status(
	project_id integer,
	status_id integer,
	resource_id integer,
	created_by character varying)
LANGUAGE 'plpgsql'

AS $BODY$
BEGIN
    -- creating new project status
    INSERT INTO project."ProjectStatus" (
		"ProjectID",
		"StatusID",
		"CurrentIndicator",
		"ResourceID",
		"CreatedBy",
		"CreatedTimestamp"
	)
	VALUES (
		project_id,
		status_id,
		true,
		resource_id,
		created_by,
		NOW()
	);
	
	 COMMIT;
END;
$BODY$;