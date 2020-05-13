-- PROCEDURE: project.create_program(character varying, character varying, integer, integer)

-- DROP PROCEDURE project.create_program(character varying, character varying, integer, integer);

CREATE OR REPLACE PROCEDURE project.create_program(
	program_name character varying,
	created_by character varying,
	resource_id integer,
	INOUT program_id integer)
LANGUAGE 'plpgsql'

AS $BODY$
BEGIN
    -- creating new project status
    INSERT INTO project."Program" (
		"Name",
		"CreatedBy",
		"CreatedTimestamp",
		"ResourceID"
	)
	VALUES (
		program_name,
		created_by,
		NOW(),
		resource_id
	) RETURNING "ID" INTO program_id;
	
	 COMMIT;
END;
$BODY$;