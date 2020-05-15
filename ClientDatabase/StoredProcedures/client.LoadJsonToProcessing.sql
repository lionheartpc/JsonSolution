CREATE PROCEDURE [client].[LoadJsonToProcessing]
@JsonContents varchar(max)
AS
BEGIN
	INSERT INTO client.ProcessingData(jsonConetnts,insertDate)
	SELECT @JsonContents, CAST( GETDATE() as datetime2(0))
	EXECUTE [client].[ImportJsonFromProcessing];
END
