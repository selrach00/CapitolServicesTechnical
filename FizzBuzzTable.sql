-- These are the commands I used with SQL Server Express for proof of concept (LocalDB)
CREATE DATABASE FizzBuzzDB;
GO

USE FizzBuzzDB;
GO

CREATE TABLE FizzBuzzResults (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Result VARCHAR(10) NOT NULL
);
GO

-- I'm not super familiar with TVP's, but after research leveraging one seems to be a good way to pass rows of data
-- into a stored procedure in a single call. My original implementation was calling the stored procedure
-- iteratively, which is obviously not acceptable :)
CREATE TYPE FizzBuzzResultType AS TABLE
(
    Result VARCHAR(10) NOT NULL
);
GO

-- Requirement to create Stored Procedure to store results generated from the FizzBuzz function, housed in
-- FizzBuzzRepository.cs and then called in FizzBuzzService.cs
CREATE PROCEDURE InsertFizzBuzzResults
    @Results FizzBuzzResultType READONLY
AS
BEGIN
    INSERT INTO FizzBuzzResults (Result)
    SELECT Result FROM @Results;
END;
GO
