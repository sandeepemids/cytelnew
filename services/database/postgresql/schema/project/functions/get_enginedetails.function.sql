-- FUNCTION: project.get_enginedetails(character varying, character varying)

-- DROP FUNCTION project.get_enginedetails(character varying, character varying);

CREATE OR REPLACE FUNCTION project.get_enginedetails(
	name character varying,
	version character varying)
    RETURNS TABLE(schema json, template json, uischema json, defaultformdata json) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY(
			SELECT "Schema", "Template","UiSchema","DefaultFormData" FROM project."StatisticalEngine"
			WHERE "Name" = name 
				AND "Version" = version 
				ORDER BY "ReleaseDate" DESC);
END
$BODY$;