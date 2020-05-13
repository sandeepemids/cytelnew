-- PROCEDURE: simulation.insert_project_simulation_data(integer, integer, character varying, integer)

-- DROP PROCEDURE simulation.insert_project_simulation_data(integer, integer, character varying, integer);

CREATE OR REPLACE PROCEDURE simulation.insert_project_simulation_data(
	projectid integer,
	resourceid integer,
	createdby character varying,
	INOUT projectsimulationid integer)
LANGUAGE 'plpgsql'

AS $BODY$
DECLARE 
	 projectindex integer := 1;

BEGIN
     IF EXISTS(SELECT 1 FROM simulation."ProjectSimulation" WHERE "ProjectID" = projectid AND "ResourceID" = resourceid)
	 THEN
	  	 SELECT "Index" + 1 FROM simulation."ProjectSimulation" WHERE "ProjectID" = projectid AND "ResourceID" = resourceid
		 ORDER BY "CreatedTimestamp" DESC LIMIT 1
		 INTO projectindex;
     END IF;

	 INSERT INTO simulation."ProjectSimulation"(
	 "ProjectID", "Index", "ResourceID", "CreatedBy", "CreatedTimestamp")
	 VALUES (projectid, projectindex, resourceid, createdby, NOW())
	 RETURNING "ID" INTO projectsimulationid;
	 COMMIT;
END
$BODY$;
