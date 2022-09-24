create database NathRestaurant
go

use NathRestaurant
go

create table Rol(
Id int primary key identity(1,1),
Nombre varchar(50)not null
)
go

create table Usuario(
Id int primary key identity(1,1),
IdRol int not null,
Nombre varchar(75)not null,
Apellido varchar(75)not null,
Contacto varchar(75)not null,
Carnet varchar(75)not null,
Contrasenia varchar(32)not null,
FechaRegistro datetime,
Estado tinyint,
constraint FK_ROL foreign key(IdRol)references Rol(Id)
)
go

create table Configuracion(
Recurso varchar(50),
Propiedad varchar(50),
Valor varchar(60)
)
go

create table Cliente(
Id int primary key identity(1,1),
Nombre varchar(75)not null,
Apellido varchar(75)not null,
Correo varchar(75)not null,
Contrasenia varchar(32)not null,
FechaRegistro datetime,
)
go

create table Categoria(
Id int primary key identity(1,1),
Nombre varchar(50)not null
)
go

create table Producto(
Id int primary key identity(1,1),
IdCategoria int,
Nombre varchar(75)not null,
Descripcion varchar(75)not null,
NombreImagen varchar(500) not null,
RutaImagen varchar(500) not null,
Precio decimal,
FechaRegistro datetime not null,
Estado tinyint not null,
constraint FK_IDCATEGORIA foreign key(IdCategoria)references Categoria(Id)
)
go

create table Combos(
Id int primary key identity(1,1),
IdProducto int,
Nombre varchar(75)not null,
Descripcion varchar(75)not null,
NombreImagen varchar(500) not null,
RutaImagen varchar(500) not null,
Precio decimal,
FechaRegistro datetime,
Estado tinyint not null,
constraint FK_IDPRODUCTO foreign key(IdProducto)references Producto(Id)
)
go

create table Carrito(
Id int primary key identity(1,1),
IdProducto int,
IdCliente int,
constraint FK_IDPRODUCTOC foreign key(IdProducto)references Producto(Id),
constraint FK_IDCLIENTE foreign key(IdCliente)references Cliente(Id)
)
go

create table DetalleVenta(
Id int primary key identity(1,1),
IdProducto int not null,
Cantidad int not null,
Subtotal decimal not null,
constraint FK_IDPRODUCT foreign key(IdProducto)references Producto(Id)
)
go

create table Venta(
Id int primary key identity(1,1),
IdDetalleVenta int not null,
IdCliente int not null,
Contacto varchar(50),
TotalProducto decimal not null,
Direccion varchar(75)not null,
FechaRegistro datetime not null,
IdTransaccion decimal not null,
MontoTotal decimal not null,
constraint FK_IDCLIENT foreign key(IdCliente)references Cliente(Id),
constraint FK_DETALLEVENTA foreign key(IdDetalleVenta)references DetalleVenta(Id)
)
go


