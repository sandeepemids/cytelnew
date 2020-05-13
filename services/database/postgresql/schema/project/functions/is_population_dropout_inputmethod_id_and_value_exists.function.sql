CREATE OR REPLACE FUNCTION project.is_population_dropout_inputmethod_id_and_value_exists(
	static_id integer,
	static_value character varying)
    RETURNS boolean
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE is_valid_population_dropout_inputmethod_id_and_value boolean = false;
BEGIN
IF EXISTS (SELECT 1 FROM project."DropoutInputMethod" WHERE "ID" = static_id AND lower("Value") = lower(static_value)) THEN
  is_valid_population_dropout_inputmethod_id_and_value = true;
END IF;

Return is_valid_population_dropout_inputmethod_id_and_value;

END
$BODY$;