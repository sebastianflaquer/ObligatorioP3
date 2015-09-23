 CREATE PROCEDURE Eliminar_EventoxEmpresa
	@nombreEmpresa varchar(50)
	As
	BEGIN
		SET NOCOUNT ON


		DELETE FROM Evento
		WHERE evento.nombreEmpresa=@nombreEmpresa
		
	END
	GO