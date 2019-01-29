-- Create a new database
-- Connect to the 'master' database to run this snippet
USE master
GO
IF EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'PlantPets'
)
DROP DATABASE [PlantPets]
GO
CREATE DATABASE [PlantPets]
--ordering:
--PlantsCreate
--PersonsCreate
--PersonPlantsCreate
--alertsCreate
--waterLogsCreate

GO