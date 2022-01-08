if exists (select * from sysobjects where id = object_id('dbo.InsertContainers') and sysstat & 0xf = 4)
	drop procedure dbo.InsertContainers
GO

---- create an SP to insert data from Mart Table belonging to a TransactionID took as parameter.
---- avoid duplicates in code field value!!