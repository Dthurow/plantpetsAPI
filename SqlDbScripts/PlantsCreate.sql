-- Create a new table called 'Employees' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Plants', 'U') IS NOT NULL
DROP TABLE dbo.Plants
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Plants
(
   PlantId        INT    NOT NULL IDENTITY PRIMARY KEY, -- primary key column
   Name      [NVARCHAR](50)  NOT NULL,
   WaterScheduleInHours   INT  NOT NULL
);
GO

-- Insert rows into table 'Persons'
INSERT INTO Plants
( -- columns to insert data into
 [Name], [WaterScheduleInHours]
)
VALUES
( -- first row: values for the columns in the list above
 N'Peppermint', 48
),
( -- second row: values for the columns in the list above
 N'Philodendron', 168
),
( -- second row: values for the columns in the list above
 N'Sprouts', 12
)
GO