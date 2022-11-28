CREATE DATABASE controlnegocio;
USE controlnegocio;

CREATE TABLE categoria(
id INT PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(50));

CREATE TABLE medida(
id INT PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(50),
abreviatura VARCHAR(10));

CREATE TABLE proveedor(
id INT PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(50));

CREATE TABLE venta(
id INT PRIMARY KEY AUTO_INCREMENT,
total DOUBLE,
fecha DATETIME);

CREATE TABLE producto(
id INT PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(50),
descripcion VARCHAR(100),
precio DOUBLE,
id_medida INT,
id_categoria INT,
FOREIGN KEY(id_medida) REFERENCES medida(id),
FOREIGN KEY(id_categoria) REFERENCES categoria(id));

CREATE TABLE almacen(
id INT PRIMARY KEY AUTO_INCREMENT,
id_producto INT,
cantidad INT,
FOREIGN KEY(id_producto) REFERENCES producto(id));

CREATE TABLE detalle_venta(
id INT PRIMARY KEY AUTO_INCREMENT,
id_venta INT,
id_producto INT,
cantidad INT,
precio DOUBLE,
FOREIGN KEY(id_venta) REFERENCES venta(id) ON DELETE CASCADE,
FOREIGN KEY(id_producto) REFERENCES producto(id) ON UPDATE CASCADE);

CREATE TABLE compra(
id INT PRIMARY KEY AUTO_INCREMENT,
id_proveedor INT,
id_producto INT,
costo DOUBLE,
cantidad INT,
fecha DATETIME,
FOREIGN KEY(id_proveedor) REFERENCES proveedor(id) ON DELETE CASCADE,
FOREIGN KEY(id_producto) REFERENCES producto(id) ON UPDATE CASCADE);

