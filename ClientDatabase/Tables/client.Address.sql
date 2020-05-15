CREATE TABLE [client].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[name] varchar(80), 
    [address] VARCHAR(80) NULL, 
    [postalCode] VARCHAR(10) NULL, 
    [addDate] DATETIME2(0) NULL DEFAULT CAST(GETDATE() AS DATETIME2(0))
)
