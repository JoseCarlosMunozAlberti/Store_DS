--use master
--create database DBventas
use DBventas

create table categoria (
Id int not null primary key identity(1,1),
nombre varchar(50) unique not null,
subcat int null,
fecha datetime
)
insert into categoria(nombre,subcat) values('Gaseosas',null)
select * from categoria

create table presentacion (
Id int not null primary key identity(1,1),
nombre varchar(50) unique not null,
fecha datetime
)
insert into presentacion(nombre) values('Unidad')
select * from presentacion
--delete from presentacion where id=1

create table articulo(
Id int not null primary key identity(1,1),
codigo varchar(20) unique not null,
nombre varchar(100) unique not null,
imagen image,
idcategoria int foreign key references categoria(Id),
idpresentacion int foreign key references presentacion(Id)
)

alter table articulo add fecha datetime default getdate()

create table trabajador(
Id int not null primary key identity(1,1),
nombres varchar(50) not null,
apellidos varchar(50) not null,
genero varchar(1) null,
fecha_nac date not null,
nro_doc varchar(20) not null,
nro_tel varchar(20) null,
email varchar(50) null,
acceso varchar(50) null,
usuario varchar(50) null,
clave varchar(50) null,
fecha datetime default getdate()
)

create table detalle_ingreso(
Id int not null primary key identity(1,1),
idingreso int foreign key references ingreso(Id),
idarticulo int foreign key references articulo(Id),
precio_compra money not null,
precio_venta money null,
stock_inicial int not null,
stock_actual int null,
fecha datetime default getdate()
)

create table ingreso(
Id int not null primary key identity(1,1),
idtrabajador int foreign key references trabajador(Id),
idproveedor int foreign key references proveedor(Id),
fecha_ing datetime default getdate(),
tipo_comp varchar(20) default 'Factura',
precio_compra decimal(18,2) not null,
precio_venta decimal(18,2) not null,
estado varchar(20) default 'ACEPTADO',
fecha datetime default getdate()
)

create table proveedor(
Id int not null primary key identity(1,1),
razon_social varchar(50) unique not null,
sec_com varchar(50) null,
nit varchar(50) not null,
nro_tel varchar(20) null,
email varchar(50) null,
fecha datetime default getdate()
)

create table cliente(
Id int not null primary key identity(1,1),
nombres varchar(50) not null,
apellidos varchar(50) not null,
genero varchar(1) null,
fecha_nac date not null,
nro_doc varchar(20) not null,
nro_tel varchar(20) null,
email varchar(50) null,
fecha datetime default getdate()
)

create table venta(
Id int not null primary key identity(1,1),
idcliente int foreign key references cliente(Id),
idtrabajador int foreign key references trabajador(Id),
fecha_ven datetime default getdate(),
nro_fac int not null,
iva decimal(2,2) default 0.13,
fecha datetime default getdate()
)

create table detalle_venta(
Id int not null primary key identity(1,1),
idventa int foreign key references venta(Id),
iddetalle_ingreso int foreign key references detalle_ingreso(Id),
cantidad int not null,
precio_ven money not null,
descuento decimal(2,2) default 0,
fecha datetime default getdate()
)