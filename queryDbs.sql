create database Registration;
go
;
use Registration;
go
;
create table EventLogsType (
    id int identity primary key,
    nombre varchar(100) not null
);
go
;
insert into EventLogsType (nombre) values ('Formulario'), ('API');
go
;
create table EventLogs (
    id int identity primary key,
    idTipo int not null,
    descripcion varchar(max) not null,
    fecha_registra smalldatetime default getdate(),
    Foreign Key (idTipo) REFERENCES EventLogsType (id)
);