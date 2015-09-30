create database EventosUYAlt;

use EventosUYAlt;

--CREATE TABLE ROLES
Create table Roles(
	IdRol int primary key,
	NombreRol varchar(30),
	DetalleRol Varchar (300)
)

insert into Roles (NombreRol,DetalleRol) values
	('Admin','Usuarios administradores de EventosUY'),
	('Empresa','Empresas o Promotores que pueden publicar eventos')

Select *
from Roles


--CREATE TABLE USUARIO
Create table Usuario(
	idCodigo int IDENTITY(1,1) primary key,
	IdRol int, 
	Nombre varchar(30), 
	Apellido varchar(30), 
	NombreEmpresa varchar(30),
	NroFuncionario int, 
	Email varchar(50) unique, 
	MailsPrivados varchar(300), 
	Pass varchar(50), 
	Telefono varchar(30), 
	Cargo varchar(50), 
	Url varchar(50),
	constraint fk_IdRol Foreign key (IdRol) references Roles,
)

insert into Usuario(NombreRol,Nombre, Apellido, NroFuncionario, Email, MailsPrivados, Pass, Telefono, Cargo, Url) values
	('Empresa','Tata',null, null,'Hola@tata.com','adi@tata.com;adi2@tata.com','123456//','099111111', null,'www.tata.com'),
	('Empresa','Multi',null, null,'Hola@multi.com','adi@multi.com;adi2@multi.com','123456//','099111111', null,'www.multi.com'),
	('Empresa','Disco',null, null,'Hola@disco.com','adi@disco.com;adi2@tata.com','123456//','099111111', null,'www.disco.com'),
	('Empresa','Devoto',null, null,'Hola@devoto.com','adi@devoto.com;adi2@tata.com','123456//','099111111', null,'www.Devoto.com'),
	('Empresa','Kinko',null, null,'Hola@kinko.com','adi@kinko.com;adi2@tata.com','123456//','099111111', null,'www.Kinko.com'),
	('Admin','Pedro','Lopez', 123,'p.l@euy',null,'admin123','099111111', 'Empleado1',null),
	('Admin','Martin','Perez', 456,'m.p@euy',null,'admin123','099321654', 'Empleado2',null)

select *
from usuario

--CREATE TABLE EVENTO
create table Evento(
	Titulo varchar(30) primary key,
	Descripcion varchar(300),
	NombreArtista varchar(300),
	fecha date,
	hora time,
	nombreLugar varchar(50),
	direccionLugar varchar(50),
	imagen varbinary(MAX),
	precio varchar(300),
	estado char(1),
	idCodigo int ,
	constraint fk_idEmpresa Foreign key (idCodigo) references Usuario,
	constraint ck_estado check (estado in('C', 'D', 'A'))
)

insert into Evento (Titulo,Descripcion,NombreArtista,fecha,hora,nombreLugar,direccionLugar,imagen,precio,estado,idCodigo)values	
	('Samba','Evento de Samba','Pedro','15/12/2015','21:00:00','Lugar2','Calle 2',00000,'520','A','4'),
	('Rock','Evento de Rock','Juan','12/05/2010','12:00:00','Lugar1','Calle 1',00000,'250','A','5'),
	('Pop','Evento de Pop','Martin','15/12/2012','21:00:00','Lugar2','Calle 2',00000,'520','A','6'),
	('RockAndRoll','Evento de Rock&Roll','Andres','15/12/2013','21:00:00','Lugar2','Calle 2',00000,'520','A','7'),
	('Tango','Evento de Tango','Matias','15/12/2011','21:00:00','Lugar2','Calle 2',00000,'520','D','8')