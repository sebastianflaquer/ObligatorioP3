CREATE PROCEDURE Empresa_EliminarPorNombre
	@nombreEmpresa varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		delete 
		From Empresa
		Where Empresa.nombreEmpresa = @nombreEmpresa
			END
			GO