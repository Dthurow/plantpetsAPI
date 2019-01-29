-- Create a new table called 'Employees' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.PersonPlants', 'U') IS NOT NULL
DROP TABLE dbo.PersonPlants
GO
-- Create the table in the specified schema
CREATE TABLE dbo.PersonPlants
(
   PersonPlantId        INT    NOT NULL IDENTITY(1,1)  PRIMARY KEY, -- primary key column
   NickName      [NVARCHAR](50)  NOT NULL,
   PlantId int FOREIGN KEY REFERENCES Plants(PlantId),
   PersonId int FOREIGN KEY REFERENCES Persons(PersonId)
);
GO

-- Insert rows into table 'Persons'
INSERT INTO PersonPlants
( -- columns to insert data into
[NickName], [PlantId], [PersonId]
)
VALUES
( -- first row: values for the columns in the list above
 N'Peppy', 1, 1
),
( -- second row: values for the columns in the list above
 N'Sprout Jr.', 3, 1
),
( -- second row: values for the columns in the list above
 N'A plant', 2, 2
)
GO