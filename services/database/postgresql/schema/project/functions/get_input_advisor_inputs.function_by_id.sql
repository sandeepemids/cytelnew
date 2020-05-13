-- FUNCTION: project.get_input_advisor_inputs_by_id(integer)

-- DROP FUNCTION project.get_input_advisor_inputs_by_id(integer);

CREATE OR REPLACE FUNCTION project.get_input_advisor_inputs_by_id(
	input_advisor_id integer)
    RETURNS TABLE(projectid integer, resourceid integer, object jsonb, createdby character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY(SELECT "ProjectID","ResourceID","Object","CreatedBy" 
	  FROM project."InputAdvisor" WHERE "ID" = input_advisor_id);
END
$BODY$;
