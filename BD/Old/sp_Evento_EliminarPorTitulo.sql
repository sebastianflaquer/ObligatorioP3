CREATE PROCEDURE Evento_EliminarPorTitulo
	@tituloEvento varchar(30)
	As
	BEGIN
		SET NOCOUNT ON

		delete 
		From Evento
		Where Evento.Titulo = @tituloEvento
			END
			GO
			 

Exec Evento_EliminarPorTitulo 'Rock&Roll'