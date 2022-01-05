CREATE DATABASE Container
GO
USE Container
CREATE TABLE dbo.ContainerType
(
ContainerTypeId INT PRIMARY KEY IDENTITY,
ContainerTypeCode VARCHAR(120)
)

INSERT INTO dbo.ContainerType (ContainerTypeCode) VALUES
('20 DRY VAN'),
('40 DRY VAN'),
('20 HIGH CUBE'),
('40 HIGH CUBE')

CREATE TABLE dbo.Container
(
Container INT PRIMARY KEY IDENTITY,
ContainerTypeId INT REFERENCES dbo.ContainerType(ContainerTypeId),
HireDate DATETIME
)

