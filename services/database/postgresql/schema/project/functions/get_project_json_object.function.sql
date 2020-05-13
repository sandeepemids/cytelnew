-- FUNCTION: project.get_project_json_object(integer, integer)

-- DROP FUNCTION project.get_project_json_object(integer, integer);

CREATE OR REPLACE FUNCTION project.get_project_json_object(
	project_id integer,
	resource_id integer)
    RETURNS TABLE(object jsonb, name character varying, numberofsim integer, simseed integer) 
    LANGUAGE 'plpgsql'


    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY(SELECT IA."Object", PR."Name", 1000 AS "NumberOfSim", 1000 AS "SimSeed" 
	FROM project."InputAdvisor" IA
	INNER JOIN project."Project" PR
	ON IA."ProjectID" = PR."ID"
	WHERE "ProjectID" = project_id AND IA."ResourceID" = resource_id
	ORDER BY IA."CreatedTimestamp" DESC LIMIT 1);
END
$BODY$;

