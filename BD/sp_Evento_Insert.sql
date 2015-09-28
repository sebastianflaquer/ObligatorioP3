CREATE PROCEDURE Evento_Insert
	@Titulo varchar(30),
	@Descripcion varchar(300),
	@NombreArtista varchar(300),
	@Fecha date,
	@Hora time(7),
	@NombreLugar varchar(50),
	@DireccionLugar varchar(50),
	@Imagen varbinary(max),
	@Precio varchar(300),
	@Estado char(1),
	@idEmpresa int
	As
	BEGIN
		SET NOCOUNT ON

		INSERT INTO Evento
			(
			 Titulo,
			 Descripcion,
			 NombreArtista,
			 fecha,
			 hora,
			 nombreLugar,
			 direccionLugar,
			 imagen,
			 precio,
			 estado,
			 idEmpresa
			 )
		VALUES
			(
			 @Titulo,
			 @Descripcion,
			 @NombreArtista,
			 @Fecha,
			 @Hora,
			 @NombreLugar,
			 @DireccionLugar,
			 @Imagen,
			 @Precio,
			 @Estado,
			 @idEmpresa
			)
			END
			GO


--Probamos el procedimiento
EXEC Evento_Insert 'holahola','Evento de Samba','Pedro','15/12/2015','21:00:00','Lugar2','Calle 2',00000,'520','D','1'