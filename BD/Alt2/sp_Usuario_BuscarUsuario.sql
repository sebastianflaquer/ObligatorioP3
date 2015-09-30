CREATE PROCEDURE Usuario_BuscarUsuario
	@mailUsuario varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select * 
		From Usuarios U
		where U.MailUsuario = @mailUsuario

	END
	GO

exec Empresas_BuscarXNombre Tata