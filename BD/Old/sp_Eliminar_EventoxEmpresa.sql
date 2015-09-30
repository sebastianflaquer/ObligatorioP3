 CREATE PROCEDURE Eliminar_EventoxEmpresa
	@idEmpresa varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		DELETE FROM Evento
		WHERE evento.idEmpresa=@idEmpresa
		
	END
	GO