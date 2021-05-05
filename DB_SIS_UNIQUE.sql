USE master
GO

--------------------------------------CREACION DE LA BASE DE DATOS

IF DB_ID('BD_SIS_UNIQUE') IS NOT NULL
	BEGIN
		DROP DATABASE BD_SIS_UNIQUE
	END
GO

CREATE DATABASE BD_SIS_UNIQUE
GO

USE BD_SIS_UNIQUE
GO

-------------------------------------------VALIDACION Y CREACION DE TABLAS---------------------


IF OBJECT_ID ('CATEGORIA_PRODUCTO') IS NOT NULL
	BEGIN
	DROP TABLE CATEGORIA_PRODUCTO
	END 
GO

CREATE TABLE CATEGORIA_PRODUCTO(
	cod_cat int not null primary key,
	des_cat varchar(50),
)
GO

IF OBJECT_ID ('PRODUCTO') IS NOT NULL
	BEGIN
	DROP TABLE PRODUCTO
	END 
GO

CREATE TABLE PRODUCTO(
	cod_prod int identity(1,1) not null primary key,
	nom_prod varchar(200) not null,
	stock int not null,
	precio decimal(10,2) not null,
	cat_prod int not null foreign key references CATEGORIA_PRODUCTO(cod_cat) 
)
GO

/* No se empleo este modo de tablas de detalle por el requerimiento del usuario
IF OBJECT_ID ('VENTA_CAB') IS NOT NULL
	BEGIN
	DROP TABLE VENTA_CAB
	END
GO

CREATE TABLE VENTA_CAB(
	cod_venta int not null primary key,
	fecha date default(getdate()) not null
)
GO

IF OBJECT_ID ('VENTA_DET') IS NOT NULL
	BEGIN
	DROP TABLE VENTA_DET
	END
GO

CREATE TABLE VENTA_DET(
	cod_venta int not null foreign key references VENTA_CAB(cod_venta),
	cod_prod int not null foreign key references PRODUCTO(cod_prod),
	cantidad int not null
)
GO*/

IF OBJECT_ID ('VENTAS') IS NOT NULL
	BEGIN
	DROP TABLE VENTAS
	END
GO

CREATE TABLE VENTAS(
	cod_venta int identity(1,1) not null primary key,
	cod_prod int not null foreign key references PRODUCTO(cod_prod),
	cantidad int not null,
	fecha date default(getdate()) not null
)
GO
------------------------INSERCION DE DATOS -------------------------------------------

INSERT INTO CATEGORIA_PRODUCTO VALUES (1,'Perfumes para varones')
INSERT INTO CATEGORIA_PRODUCTO VALUES (2,'Perfumes para mujeres')
INSERT INTO CATEGORIA_PRODUCTO VALUES (3,'Colonias para varones')
INSERT INTO CATEGORIA_PRODUCTO VALUES (4,'Colonias para mujeres')
INSERT INTO CATEGORIA_PRODUCTO VALUES (5,'Shampoos')
INSERT INTO CATEGORIA_PRODUCTO VALUES (6,'Cremas de cuerpo')
INSERT INTO CATEGORIA_PRODUCTO VALUES (7,'Cremas de manos')
INSERT INTO CATEGORIA_PRODUCTO VALUES (8,'Cremas faciales')
INSERT INTO CATEGORIA_PRODUCTO VALUES (9,'Esmaltes')
INSERT INTO CATEGORIA_PRODUCTO VALUES (10,'Labiales')
INSERT INTO CATEGORIA_PRODUCTO VALUES (12,'Colecciones')
INSERT INTO CATEGORIA_PRODUCTO VALUES (12,'Aretes')
INSERT INTO CATEGORIA_PRODUCTO VALUES (13,'Collares')
INSERT INTO CATEGORIA_PRODUCTO VALUES (14,'Desodorantes para varones')
INSERT INTO CATEGORIA_PRODUCTO VALUES (15,'Desodorantes para mujeres')
INSERT INTO CATEGORIA_PRODUCTO VALUES (16,'Jabones')
GO


-------------------------CREACION DE PROCEDURES----------------------

CREATE PROCEDURE sp_categorias_combo
As
	select * from CATEGORIA_PRODUCTO
GO

CREATE PROCEDURE sp_listarProductosxCategoria
@cod int
As
	select p.nom_prod as 'Nombre de Producto',p.stock as Stock,p.precio as Precio from PRODUCTO p
	where p.cat_prod = @cod
GO

CREATE PROCEDURE sp_listarProductosxCategoria_combo
@cod int
As
	select p.cod_prod,p.nom_prod from PRODUCTO p
	where p.cat_prod = @cod
GO

-----------------Añade productos nuevos ------------------
CREATE PROC sp_agregarProducto
@nom varchar(200),
@stock int,
@precio decimal(10,2),
@categoria int
as
	INSERT INTO PRODUCTO(nom_prod,stock,precio,cat_prod) VALUES (@nom,@stock,@precio,@categoria)
GO


----------Lista de las ventas
CREATE PROCEDURE sp_listarVentas
as
	select p.nom_prod as nombreProducto,v.cantidad,v.fecha from VENTAS v
	inner join PRODUCTO p
	on v.cod_prod=p.cod_prod
	where v.fecha = CAST(GETDATE() as date)
GO

CREATE PROCEDURE sp_listarProductosVendidos
@fec1 date,
@fec2 date
as
	select p.nom_prod as 'Nombre de Producto',v.cantidad as Cantidad,v.fecha as 'Fecha de Venta' from VENTAS v
	inner join PRODUCTO p
	on v.cod_prod=p.cod_prod
	where v.fecha between @fec1 and @fec2
GO


----------Añade productos vendidos a la tabla Ventas (vende productos)-----------
CREATE PROCEDURE sp_vender
@cod_prod int,
@cantidad int
as
	INSERT INTO VENTAS(cod_prod,cantidad) VALUES (@cod_prod,@cantidad)

	IF EXISTS( SELECT p.cod_prod FROM PRODUCTO p WHERE p.cod_prod = @cod_prod) 
		BEGIN
			UPDATE PRODUCTO
			SET stock = stock - @cantidad 
			WHERE cod_prod = @cod_prod
		END
GO

----------------Aumenta el Stock de los productos------------------
CREATE PROC sp_aumentarStock
@cod_prod int,
@cantidad int
as
	IF EXISTS( SELECT p.cod_prod FROM PRODUCTO p WHERE p.cod_prod = @cod_prod) 
		BEGIN
			UPDATE PRODUCTO
			SET stock = stock + @cantidad 
			WHERE cod_prod = @cod_prod
		END
GO

-------------------Devuelve el producto solicitado---------------------
CREATE PROC sp_buscarProducto
@cod_prod int
as
	IF EXISTS( SELECT p.cod_prod FROM PRODUCTO p WHERE p.cod_prod = @cod_prod) 
		BEGIN
			select p.nom_prod as 'Nombre del Producto' , p.stock as 'Stock' , p.precio as 'Precio'
			from PRODUCTO p
			where p.cod_prod = @cod_prod
		END
GO

----------------------Elimina el producto segun codigo-----------------
CREATE PROC sp_eliminarProducto
@cod_prod int
as
	Delete from PRODUCTO 
	where cod_prod=@cod_prod
GO


------------------lista todos los productos
CREATE PROC sp_productos
as
	select * from PRODUCTO
GO

