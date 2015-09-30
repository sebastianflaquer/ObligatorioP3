 CREATE PROCEDURE Eliminar_EventoxTitulo
	@tituloEvento varchar(30)
	As
	BEGIN
		SET NOCOUNT ON


		DELETE FROM Evento
		WHERE evento.Titulo=@tituloEvento 
		
	END
	GO