-- PROCEDURE: project.create_input_advisor_inputs(integer, integer, character varying, text, integer)

-- DROP PROCEDURE project.create_input_advisor_inputs(integer, integer, character varying, text, integer);

CREATE OR REPLACE PROCEDURE project.create_input_advisor_inputs(
	project_id integer,
	resource_id integer,
	created_by character varying,
	input_advisor_object text,
	INOUT input_advisor_id integer)
LANGUAGE 'plpgsql'

AS $BODY$
DECLARE converted_json_object jsonb = '{}';
BEGIN

	select input_advisor_object::jsonb into converted_json_object;
		
    -- creating new Input Advisor
    INSERT INTO project."InputAdvisor" (
		"ProjectID",
		"Object",
		"ResourceID",
		"CreatedBy",
		"CreatedTimestamp"
	)
	VALUES (
		project_id,
		converted_json_object,
		resource_id,
		created_by,
		NOW()
	) RETURNING "ID" INTO input_advisor_id;

    COMMIT;
END;
$BODY$;
