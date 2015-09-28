CREATE PROCEDURE Empresa_EliminarPorId
	@idEmpresa int
	As
	BEGIN
		SET NOCOUNT ON

		EXECUTE Eliminar_EventoxEmpresa @idEmpresa;

		DELETE FROM Empresa
		WHERE Empresa.idEmpresa=@idEmpresa
		
	END
	GO


	exec Empresa_EliminarPorId 2