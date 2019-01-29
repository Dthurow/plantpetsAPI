-- Create a new table called 'Employees' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Alerts', 'U') IS NOT NULL
DROP TABLE dbo.Alerts
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Alerts
(
   AlertId        INT    NOT NULL IDENTITY(1,1)  PRIMARY KEY, -- primary key column
   PersonId int FOREIGN KEY REFERENCES Persons(PersonId),
   PersonPlantId int FOREIGN KEY REFERENCES PersonPlants(PersonPlantId),
   AlertTime DATETIME NOT NULL
);
GO

