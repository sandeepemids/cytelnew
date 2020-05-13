-- PROCEDURE: simulation.update_project_simulation_model_count(integer, integer)

-- DROP PROCEDURE simulation.update_project_simulation_model_count(integer, integer);

CREATE OR REPLACE PROCEDURE simulation.update_project_simulation_model_count(
	projectsimulationid integer,
	modelcount integer)
LANGUAGE 'plpgsql'

AS $BODY$
DECLARE 
BEGIN 
	 UPDATE simulation."ProjectSimulation" SET "ModelCount" = modelcount
	 WHERE "ID" = projectsimulationid;

END
$BODY$;
