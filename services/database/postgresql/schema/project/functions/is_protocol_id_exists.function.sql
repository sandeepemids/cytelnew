-- FUNCTION: project.is_protocol_id_exists(character varying)

-- DROP FUNCTION project.is_protocol_id_exists(character varying);

CREATE OR REPLACE FUNCTION project.is_protocol_id_exists(
	protocol_id character varying)
    RETURNS boolean
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE is_protocol_id_exists boolean = false;
BEGIN
IF EXISTS (SELECT 1 FROM project."Project" WHERE LOWER("ProtocolID") = LOWER(protocol_id)) THEN
  is_protocol_id_exists = true;
END IF;

Return is_protocol_id_exists;

END

$BODY$;
