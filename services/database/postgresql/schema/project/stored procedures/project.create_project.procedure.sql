-- PROCEDURE: project.create_project(character varying, character varying, integer, integer, integer, integer, integer, integer, character varying, integer)

-- DROP PROCEDURE project.create_project(character varying, character varying, integer, integer, integer, integer, integer, integer, character varying, integer);

CREATE OR REPLACE PROCEDURE project.create_project(
	project_name character varying,
	protocol_id character varying,
	program_id integer,
	indication_id integer,
	phase_id integer,
	time_unit_id integer,
	currency_id integer,
	resource_id integer,
	created_by character varying,
	INOUT project_id integer)
LANGUAGE 'plpgsql'

AS $BODY$
BEGIN
    -- creating new project status
    INSERT INTO project."Project" (
		"Name",
		"ProtocolID",
		"ProgramID",
		"IndicationID",
		"Phase",
		"TimeUnitID",
		"CurrencyID",
		"ResourceID",
		"CreatedBy",
		"CreatedTimestamp",
		"ModifiedTimestamp"
	)
	VALUES (
		project_name,
		protocol_id,
		program_id,
		indication_id,
		phase_id,
		time_unit_id,
		currency_id,
		resource_id,
		created_by,
		NOW(),
		NOW()
	) RETURNING "ID" INTO project_id;
	
	 CALL project.create_project_status(project_id,1,resource_id,created_by);
	 COMMIT;
END;
$BODY$;