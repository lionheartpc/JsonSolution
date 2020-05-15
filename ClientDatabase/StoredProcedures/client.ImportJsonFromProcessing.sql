
CREATE PROCEDURE client.ImportJsonFromProcessing

AS
BEGIN

	DECLARE @jsonString varchar(max),
	@jsonID INT,
	@statusMessage varchar(500);

	SELECT TOP 1 @jsonString=[jsonConetnts],@jsonID = [Id]FROM [client].[ProcessingData] WHERE [status] IS NULL;

	BEGIN TRY 

		WITH CTE_JSONDATA ([Name],[Address],[PostCode]) AS (
			SELECT 
				JSON_Value([value],'$.Name')		AS [Name] ,
				JSON_Value([value],'$.Address')		AS [Address] ,
				JSON_Value([value],'$.PostCode')	AS [PostCode]  
			FROM OPENJSON(@jsonString)
		)
		INSERT INTO client.Address([name],[address],[postalCode])
		SELECT 
			[Name],
			[Address],
			[PostCode] 
		FROM CTE_JSONDATA cte 
		WHERE NOT EXISTS (SELECT * FROM [client].[Address] ad WHERE ad.[name] = cte.[Name]);
		
		SET @statusMessage = 'Records inserted:' + CAST(@@ROWCOUNT AS varchar)

	END TRY
	BEGIN CATCH

		set @statusMessage = CAST(LEFT(ERROR_MESSAGE(),500) AS VARCHAR(500));

	END CATCH;

	UPDATE  pcd
	SET status = @statusMessage,
	statusUpdateTime = CAST(GETDATE() AS DATETIME2(0))
	FROM client.ProcessingData pcd WHERE pcd.Id = @jsonID;

END


