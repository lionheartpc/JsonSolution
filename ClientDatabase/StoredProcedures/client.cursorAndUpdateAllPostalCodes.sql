CREATE PROCEDURE client.cursorAndUpdateAllPostalCodes
@ApiKey varchar(80),
@ApiURL varchar(80)
AS
BEGIN

	DECLARE @recordId int,
			@address varchar(80),
			@addressFormatted varchar(80);

 DECLARE addressCursor CURSOR FOR   
    SELECT  ad.id,
			ad.address
    FROM client.Address ad

    OPEN addressCursor    FETCH NEXT FROM addressCursor INTO @recordId,@address  
    WHILE @@FETCH_STATUS = 0  
    BEGIN  
	SET @addressFormatted = client.fn_formatStringforURL(@address)
    EXECUTE client.updatePostcalCodeFromAPI @addressFormatted,@ApiKey,@ApiURL,@recordId

           FETCH NEXT FROM addressCursor INTO @recordId,@address   
    END  

	CLOSE addressCursor;  
	DEALLOCATE addressCursor;  
END;

