CREATE TABLE [client].[ApiUpdateLog]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [call] VARCHAR(MAX) NULL, 
    [result] NVARCHAR(MAX) NULL, 
    [callDate] DATETIME2(0) NULL
)
