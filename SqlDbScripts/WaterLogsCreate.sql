-- Create a new table called 'Employees' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.WaterLogs', 'U') IS NOT NULL
DROP TABLE dbo.WaterLogs
GO
-- Create the table in the specified schema
CREATE TABLE dbo.WaterLogs
(
   WaterLogsId        INT    NOT NULL IDENTITY (1,1)  PRIMARY KEY, -- primary key column
   PersonId int FOREIGN KEY REFERENCES Persons(PersonId),
   PersonPlantId int FOREIGN KEY REFERENCES PersonPlants(PersonPlantId),
   WaterTime DATETIME NOT NULL
);
GO

