create database EventosUY;

use EventosUY;

/* Empresa */
create table Empresa(
	idEmpresa int IDENTITY(1,1) primary key,
	nombreEmpresa varchar(50),
	telEmpresa varchar(30),
	mailPrimario varchar(50) unique,
	mailAdicional varchar(300),
	Url varchar(50)
	Password varchar(50)
)

insert into Empresa(nombreEmpresa,telEmpresa,mailPrimario,mailAdicional,Url)values
	('Tata','099111111','Hola@tata.com','adi@tata.com;adi2@tata.com','www.tata.com'),
	('Multi','099222222','Hola@multi.com','adi@multi.com;adi2@multi.com','www.multi.com')

select * from Empresa

/* Evento */
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
	idEmpresa int,
	constraint fk_idEmpresa Foreign key (idEmpresa) references Empresa,
	constraint ck_estado check (estado in('C', 'D', 'A'))
)

insert into Evento (Titulo,Descripcion,NombreArtista,fecha,hora,nombreLugar,direccionLugar,imagen,precio,estado,idEmpresa)values
	('Rock','Evento de Rock','Juan','12/05/2010','12:00:00','Lugar1','Calle 1',00000,'250','A',1),
	('Samba','Evento de Samba','Pedro','15/12/2015','21:00:00','Lugar2','Calle 2',00000,'520','D',2)
	
/* Consulta de testeo */
select *
from Evento E, Empresa P
where E.idEmpresa = P.idEmpresa and
p.idEmpresa = 1


/* UsuariosEventosUy */
create table usuarioEventosUY(
	idEuy int identity(1,1) primary key, 
	NroFuncionario int unique not null,
	NombreEuy varchar(30) not null,
	ApellidoEuy varchar(30) not null,
	EmailEuy varchar(50),
	PasswordEuy varchar(50) not null,
	Telefono varchar(30),
	Cargo varchar(50) not null,
)

insert into usuarioEventosUY (NroFuncionario,NombreEuy,ApellidoEuy,EmailEuy,PasswordEuy,Telefono,Cargo)values
	(123,'Pedro','Lopez','p.l@euy','123456//','099123123','Empleado1'),
	(456,'Martin','Perez','m.p@euy','123456//','099321654','Empleado2')

select * from usuarioEventosUY
