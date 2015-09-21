CREATE PROCEDURE Empresa_BuscarPorNombre
	@nombreEmpresa varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select * 
		From Empresa
		Where Empresa.nombreEmpresa = @nombreEmpresa
			END
			GO