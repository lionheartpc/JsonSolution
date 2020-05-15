CREATE TABLE [client].[ProcessingData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [jsonConetnts] VARCHAR(MAX) NULL, 
    [status] VARCHAR(500) NULL, 
    [insertDate] DATETIME2(0) NULL, 
    [statusUpdateTime] DATETIME2(0) NULL

)
