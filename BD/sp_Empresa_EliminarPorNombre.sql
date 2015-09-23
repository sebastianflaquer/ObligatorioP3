CREATE PROCEDURE Empresa_EliminarPorNombre
	@nombreEmpresa varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		EXECUTE Eliminar_EventoxEmpresa @nombreEmpresa;

		DELETE FROM Empresa
		WHERE Empresa.nombreEmpresa=@nombreEmpresa
		
	END
	GO