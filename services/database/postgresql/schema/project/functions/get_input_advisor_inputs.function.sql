-- FUNCTION: project.get_input_advisor_inputs(integer, integer)

-- DROP FUNCTION project.get_input_advisor_inputs(integer, integer);

CREATE OR REPLACE FUNCTION project.get_input_advisor_inputs(
	project_id integer,
	resource_id integer)
    RETURNS jsonb
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

	DECLARE input_advisor_inputs_json jsonb = '{}';

BEGIN

	IF EXISTS (SELECT 1 FROM project."InputAdvisor" WHERE "ProjectID" = project_id AND "ResourceID" = resource_id) THEN
	
	  SELECT "Object" INTO input_advisor_inputs_json
	  FROM project."InputAdvisor" 
	  WHERE "ProjectID" = project_id AND "ResourceID" = resource_id  
	  ORDER BY "CreatedTimestamp" DESC LIMIT 1;
	
	ELSE
	
	  SELECT "Template" INTO input_advisor_inputs_json 
	  FROM project."InputAdvisorSchema" 
	  ORDER BY "ReleaseDate" DESC LIMIT 1;

	END IF;
	
	RETURN input_advisor_inputs_json;
END
$BODY$;