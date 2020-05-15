CREATE FUNCTION client.fn_formatStringforURL
(
	@string varchar(50)
)
RETURNS varchar(80)
AS
BEGIN

	DECLARE @result varchar(80)

	SELECT @result = replace(replace(replace(replace(replace(replace(replace(replace(replace(lower(@string),'ą','a'),'č','c'),'ę','e'),'ė','e'),'į','i'),'š','s'),'ų','u'),'ū','u'),'ž','z');

	RETURN @result

END
GO

