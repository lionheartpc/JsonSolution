CREATE PROCEDURE client.updatePostcalCodeFromAPI
@Address varchar(80),
@ApiKey varchar(80),
@ApiURL varchar(80),
@RecordId int
AS
BEGIN
--used for code ref https://github.com/areed1192/sigma_coding_youtube/blob/master/t%20sql/Making%20API%20Requests.sql

	DECLARE @token int,
	 @ret int,
	 @url varchar(max);

	DECLARE @resultJson			varchar(max),
			@resultStatus		varchar(50),
			@postalCodeResult	varchar(10);

	DECLARE @json AS TABLE(Json_Table varchar(MAX));

	SET @url = @ApiURL+@Address+'&key='+@ApiKey

	EXEC @ret = sp_OACreate 'MSXML2.XMLHTTP', @token OUT;
	IF @ret <> 0 RAISERROR('Unable to open HTTP connection.', 10, 1);


	EXEC @ret = sp_OAMethod @token, 'open', NULL, 'GET', @url, 'false';
	EXEC @ret = sp_OAMethod @token, 'send'

	INSERT into @json (Json_Table) EXEC sp_OAGetProperty @token, 'responseText'

	SELECT TOP 1 @resultJson = [value] from OPENJSON( (SELECT TOP 1 Json_Table FROM @json)) WHERE [key] = 'data'
	SELECT TOP 1 @resultStatus = [value] from OPENJSON( (SELECT TOP 1 Json_Table FROM @json)) WHERE [key] = 'status'

	SELECT TOP 1 @postalCodeResult =ISNULL(IIF(@resultStatus LIKE '%success%',(SELECT TOP 1 JSON_Value([value],'$.post_code') FROM OPENJSON(@resultJson)),''),'');

	INSERT INTO client.ApiUpdateLog([call],[result],[callDate])
	SELECT @url, @resultJson,CAST(GETDATE() AS DATETIME2(0));

	UPDATE ad 
	SET ad.postalCode = @postalCodeResult
	FROM client.Address ad
	WHERE ad.Id = @RecordId and @postalCodeResult <> ''

END;