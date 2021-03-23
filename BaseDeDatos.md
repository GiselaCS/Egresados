# Egresados

create database EgresadoSENA;
use EgresadoSENA;

create table ESUsuarios(
usu_id int IDENTITY(1,1),
usu_documento int PRIMARY KEY NOT NULL,
usu_tipodoc varchar(100),
usu_nombre varchar(100),
usu_celular int,
usu_email varchar(100),
usu_genero varchar(100),
usu_aprendiz varchar(30),
usu_egresado varchar(30),
usu_areaformacion varchar(200),
usu_fechaegresado date,
usu_direccion varchar(100),
usu_barrio varchar(100),
usu_ciudad varchar(100),
usu_departamento varchar(100),
usu_fecharegistro date

);

select * from ESUsuarios;
