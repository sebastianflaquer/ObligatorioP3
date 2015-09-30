CREATE PROCEDURE Usuarios_Insert	
	@mailPrimario varchar(50),
	@Password varchar(50)
	As BEGIN
	SET NOCOUNT ON

	Insert into Usuarios ( MailUsuario,	PassUsuario	) VALUES
		(@mailPrimario, @Password)
		SELECT SCOPE_IDENTITY()

	END 
	GO

