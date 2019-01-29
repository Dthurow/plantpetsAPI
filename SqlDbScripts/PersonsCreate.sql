-- Create a new table called 'Employees' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Persons', 'U') IS NOT NULL
DROP TABLE dbo.Persons
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Persons
(
   PersonId        INT    NOT NULL IDENTITY   PRIMARY KEY, -- primary key column
   FirstName      [NVARCHAR](50)  NOT NULL,
   LastName      [NVARCHAR](50)  NOT NULL
);
GO

-- Insert rows into table 'Persons'
INSERT INTO Persons
( -- columns to insert data into
[FirstName], [LastName]
)
VALUES
( -- first row: values for the columns in the list above
N'Danielle', N'Thurow'
),
( -- second row: values for the columns in the list above
 N'Jack', N'Thompson'
),
( -- third row: values for the columns in the list above
N'Denise', N'Channing'
)
GO