-- PROCEDURE: simulation.insert_simulation_data(uuid, integer, json, character, integer)

-- DROP PROCEDURE simulation.insert_simulation_data(uuid, integer, json, character, integer);

CREATE OR REPLACE PROCEDURE simulation.insert_simulation_data(
	simulationmodelid uuid,
	projectsimulationid integer,
	objectjson json,
	simulationstate character,
	resourceid integer)
LANGUAGE 'plpgsql'

AS $BODY$
DECLARE 
BEGIN
	 INSERT INTO simulation."SimulationModel"(
	 "ID", "ProjectSimulationID", "Object", "SimulationState", "ResourceID")
	 VALUES (simulationmodelid, projectsimulationid, objectjson, simulationstate, resourceid);
END
$BODY$;
