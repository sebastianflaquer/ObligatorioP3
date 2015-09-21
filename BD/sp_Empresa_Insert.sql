CREATE PROCEDURE Empresa_Insert
	@nombreEmpresa varchar(50),
	@telEmpresa varchar(30),
	@mailPrimario varchar(50),
	@mailAdicional varchar(300),
	@Url varchar(50),
	@Password varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		INSERT INTO Empresa
			(
			 nombreEmpresa	,
			 telEmpresa		,
			 mailPrimario	,
			 mailAdicional	,
			 Url			,
			 Password		
			 )
		VALUES
			(
			 @nombreEmpresa ,
			 @telEmpresa	,
			 @mailPrimario	,
			 @mailAdicional	,
			 @Url			,
			 @Password		
			)
			END
			GO