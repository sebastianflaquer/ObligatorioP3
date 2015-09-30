create database EventosUYAlt;

use EventosUYAlt;

--CREATE TABLE ROLES
Create table Roles(
	IdRol int primary key,
	NombreRol varchar(30),
	DetalleRol Varchar (300)
)

insert into Roles (IdRol, NombreRol, DetalleRol) values
	(1, 'Admin','Usuarios administradores de EventosUY'),
	(2, 'Empresa','Empresas o Promotores que pueden publicar eventos')