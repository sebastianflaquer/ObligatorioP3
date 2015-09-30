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

		Insert into Usuarios
			(
			MailUsuario	,
			PassUsuario
			)
		VALUES
			(
			@mailPrimario	,
			@Password		
			)SELECT SCOPE_IDENTITY()
			END
			GO

