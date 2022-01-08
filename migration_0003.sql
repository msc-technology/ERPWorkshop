if exists (select * from sysobjects where id = object_id('dbo.InsertContainers') and sysstat & 0xf = 4)
	drop procedure dbo.InsertContainers
GO

CREATE PROCEDURE dbo.InsertContainers(	@TransacionId UNIQUEIDENTIFIER )
AS
BEGIN 
INSERT INTO dbo.Container(ContainerTypeId,ContainerCode,HireDate)

SELECT T.ContainerTypeId,M.ContainerCode,M.HireDate FROM dbo.ContainerMart M
	INNER JOIN dbo.ContainerType T ON T.ContainerTypeCode=M.ContainerType
	LEFT JOIN dbo.Container C ON C.ContainerCode=M.ContainerCode
	WHERE C.Container IS NULL
	AND M.TransactionID=@TransacionId
END