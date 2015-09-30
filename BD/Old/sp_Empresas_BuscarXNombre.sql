CREATE PROCEDURE Empresas_BuscarXNombre
	@nombreEmpresa varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select * 
		From Empresa E
		where E.nombreEmpresa = @nombreEmpresa
			END
			GO

		exec Empresas_BuscarXNombre Tata