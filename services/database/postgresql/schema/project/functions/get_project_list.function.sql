-- FUNCTION: project.get_project_list(integer, integer, boolean)

-- DROP FUNCTION project.get_project_list(integer, integer, boolean);

CREATE OR REPLACE FUNCTION project.get_project_list(
	project_id integer,
	resource_id integer,
	list_all_projects boolean)
    RETURNS TABLE(projectid integer, projectname character varying, protocolid character varying, programid integer, phase smallint, createdtimestamp timestamp with time zone, modifiedtimestamp timestamp with time zone, statusid smallint, projectstatus character varying, programname character varying, indicationid smallint, indicationname character varying, timeunitid smallint, timeunit character varying, currencyid smallint, currencyname character varying, createdby character varying, resourceid integer) 
    LANGUAGE 'sql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
    SELECT
        PR. "ID" AS "ProjectID",
        PR. "Name" AS "ProjectName",
        PR. "ProtocolID",
        PR. "ProgramID",
        PR. "Phase",
        PR. "CreatedTimestamp",
        PR. "ModifiedTimestamp",
        PS. "StatusID",
        SS. "Value" AS "ProjectStatus",
        PM. "Name" AS "ProgramName",
        PR. "IndicationID",
        IC. "Value" AS "IndicationName",
        PR. "TimeUnitID",
        PT. "Value" AS "TimeUnit",
        PR. "CurrencyID",
        CR. "Value" AS "CurrencyName",
		PR."CreatedBy",
		PR."ResourceID"
    FROM
        project. "Project" PR
        INNER JOIN project. "Program" PM ON PM. "ID" = PR. "ProgramID"
        INNER JOIN project. "Indication" IC ON IC. "ID" = PR. "IndicationID"
        INNER JOIN project. "ProjectTimeUnit" PT ON PT. "ID" = PR. "TimeUnitID"
        INNER JOIN project. "Currency" CR ON CR. "ID" = PR. "CurrencyID"
        INNER JOIN project. "ProjectStatus" PS ON PS. "ProjectID" = PR. "ID"
        AND PS. "CurrentIndicator" = TRUE
        INNER JOIN project. "Status" SS ON SS. "ID" = PS. "StatusID"
		WHERE (PR."ID"=project_id) OR (PR."ResourceID" = resource_id AND list_all_projects = true)
	ORDER By PR. "CreatedTimestamp" desc
$BODY$;