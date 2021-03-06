--CREACIÓN DE TABLAS

drop table CLIENTE;
drop table COMPRAS;
drop table PRODUCTOS;
drop table CATEGORIA;
drop table PROVEEDORES;
drop table LOG_COMPRAS;


CREATE TABLE CLIENTE
(
  id_cliente  NUMBER NOT NULL 
, nombre  VARCHAR2(150) 
, apellidos  VARCHAR2(250)  
, fechaNacimiento  Date  
, lugarNacimiento VARCHAR2(250)  
, Telefono VARCHAR2(15)  
, CONSTRAINT CLIENTES_PK PRIMARY KEY 
  (
    id_cliente 
  )
  ENABLE 
);




CREATE TABLE COMPRAS
(
  id_compras  NUMBER NOT NULL 
, fecha DATE
, cantidad DECIMAL
, id_cliente  NUMBER  
, id_producto  NUMBER  
, CONSTRAINT COMPRAS_PK PRIMARY KEY 
  (
    id_compras 
  )
  ENABLE 
);

CREATE TABLE LOG_COMPRAS
(
  id_log  NUMBER NOT NULL 
  ,id_compras  NUMBER NOT NULL 
, fecha DATE
, cantidad DECIMAL
, id_cliente  NUMBER  
, id_producto  NUMBER 
,fechaDeRegistro DATE
,accion varchar(150)
, CONSTRAINT COMPRAS_PK PRIMARY KEY 
  (
    id_log 
  )
  ENABLE 
);

CREATE TABLE PRODUCTOS
(
  id_producto  NUMBER NOT NULL 
, nombre  VARCHAR2(150) 
, precio  decimal  
, cantidad  NUMBER  
, fechaProducto  DATE 
,id_categoria NUMBER
,id_proveedores NUMBER
, CONSTRAINT PRODUCTO_PK PRIMARY KEY 
  (
    id_producto 
  )
  ENABLE 
);

CREATE TABLE CATEGORIA 
(
  id_categoria   NUMBER NOT NULL 
, nombre  VARCHAR2(150) 
, fecha   DATE   
, CONSTRAINT CATEGORIA_PK PRIMARY KEY 
  (
    id_categoria 
  )
  ENABLE 
);


CREATE TABLE PROVEEDORES 
(
  id_proveedores   NUMBER NOT NULL 
, nombre  VARCHAR2(150) 
, CONSTRAINT PROVEEDORES_PK PRIMARY KEY 
  (
    id_proveedores 
  )
  ENABLE 
);

CREATE TABLE FACTURA 
(
  id_factura   NUMBER NOT NULL 
, fecha   DATE  
, nombreVendedor  VARCHAR2(150)  
,valorCompra DECIMAL
, id_compras  NUMBER  
, CONSTRAINT factura_PK PRIMARY KEY 
  (
    id_factura 
  )
  ENABLE 
);

DROP SEQUENCE SEQ_CLIENTE_CLASE;
DROP SEQUENCE SEQ_COMPRAS_CLASE;
DROP SEQUENCE SEQ_PRODUCTOS_CLASE;
DROP SEQUENCE SEQ_CATEGROIA_CLASE;
DROP SEQUENCE SEQ_PROVEEDORES_CLASE;
DROP SEQUENCE SEQ_FACTURA_CLASE;
DROP SEQUENCE SEQ_LOG_COMPRAS_CLASE;
-- SECUENCIAS
CREATE SEQUENCE SEQ_CLIENTE_CLASE MINVALUE 1 START WITH 1 INCREMENT BY 1 CACHE 10;
CREATE SEQUENCE SEQ_COMPRAS_CLASE MINVALUE 1 START WITH 1 INCREMENT BY 1 CACHE 10;
CREATE SEQUENCE SEQ_PRODUCTOS_CLASE MINVALUE 1 START WITH 1 INCREMENT BY 1 CACHE 10;
CREATE SEQUENCE SEQ_CATEGROIA_CLASE MINVALUE 1 START WITH 1 INCREMENT BY 1 CACHE 10;
CREATE SEQUENCE SEQ_PROVEEDORES_CLASE MINVALUE 1 START WITH 1 INCREMENT BY 1 CACHE 10;
CREATE SEQUENCE SEQ_FACTURA_CLASE MINVALUE 1 START WITH 1 INCREMENT BY 1 CACHE 10;
CREATE SEQUENCE SEQ_LOG_COMPRAS_CLASE MINVALUE 1 START WITH 1 INCREMENT BY 1 CACHE 10;

-- INSERTAR DATOS EN TABLA PRODUCTOS
INSERT INTO PRODUCTOS (ID_PRODUCTO, NOMBRE, PRECIO, CANTIDAD, FECHAPRODUCTO, ID_CATEGORIA, ID_PROVEEDORES) 
VALUES (SEQ_PRODUCTOS_CLASE.NEXTVAL, 'PESCADO', '20000', '120', SYSDATE, '1', '1');
INSERT INTO PRODUCTOS (ID_PRODUCTO, NOMBRE, PRECIO, CANTIDAD, FECHAPRODUCTO, ID_CATEGORIA, ID_PROVEEDORES) 
VALUES (SEQ_PRODUCTOS_CLASE.NEXTVAL, 'PAN', '2000', '200', SYSDATE, '1', '1');
INSERT INTO PRODUCTOS (ID_PRODUCTO, NOMBRE, PRECIO, CANTIDAD, FECHAPRODUCTO, ID_CATEGORIA, ID_PROVEEDORES) 
VALUES (SEQ_PRODUCTOS_CLASE.NEXTVAL, 'SANCOCHOS', '6000', '60', SYSDATE, '1', '1');
INSERT INTO PRODUCTOS (ID_PRODUCTO, NOMBRE, PRECIO, CANTIDAD, FECHAPRODUCTO, ID_CATEGORIA, ID_PROVEEDORES) 
VALUES (SEQ_PRODUCTOS_CLASE.NEXTVAL, 'SEVICHES', '18000', '120', SYSDATE, '1', '1');
INSERT INTO PRODUCTOS (ID_PRODUCTO, NOMBRE, PRECIO, CANTIDAD, FECHAPRODUCTO, ID_CATEGORIA, ID_PROVEEDORES) 
VALUES (SEQ_PRODUCTOS_CLASE.NEXTVAL, 'GASEOSA', '1800', '200', SYSDATE, '1', '1');

INSERT INTO COMPRAS (ID_COMPRAS, FECHA, ID_CLIENTE, ID_PRODUCTO, ID_FACTURA, CANTIDAD) 
VALUES (SEQ_COMPRAS_CLASE.NEXTVAL, sysdate ,'1', '1', '1', '2');






--TRIGGER DE PARA INSERTAR FACTURA CADA VEZ QUE SE REALIZA UNA COMPRA
-- TAMBIEN SE ENCARGA DE RESTAR LA CANDIDA DE PRODUCTOS PARA EL INVENTARIO
-- CADA VEZ QUE SE REALIZA UNA COMPRA
create or replace TRIGGER InsertarFactura
BEFORE  INSERT
   ON COMPRAS
   FOR EACH ROW
DECLARE
   var_ValorCompra NUMBER;

BEGIN
  -- Se consulta el valor de la compra por producto y se almacena en la variable var_ValorCompra
select (pro.PRECIO * cop.CANTIDAD) into var_ValorCompra  from COMPRAS cop 
INNER JOIN PRODUCTOS pro on cop.ID_PRODUCTO=pro.ID_PRODUCTO where cop.ID_PRODUCTO = :new.ID_PRODUCTO;

-- SE INSERTA LA FACTURA POR CADA PRODUCTO COMPRADO RELACIONA AL CLIENTE
INSERT INTO FACTURA (ID_FACTURA, FECHA, NOMBREVENDEDOR, VALORCOMPRA, ID_COMPRAS, CLIENTE)
VALUES (SEQ_FACTURA_CLASE.NEXTVAL, SYSDATE, 'Mejor Vendedor', var_ValorCompra, :new.ID_COMPRAS, :new.ID_CLIENTE);

-- SE ACTUALIZA LOS PRODUCTOS EXISTENTES POR LA CANDIDAD DE COMPRAS
UPDATE PRODUCTOS SET CANTIDAD = (CANTIDAD - :new.CANTIDAD);

END;




----********************* TRIGGER PARA LOG DE VENTAS **************************

-- CREACIÓN DE TRRIGGER INSERTAR TABLAS
create or replace TRIGGER TRG_LOG_VENTA_INSERT
BEFORE  INSERT
   ON COMPRAS
   FOR EACH ROW
DECLARE
   --var_ValorCompra NUMBER;

BEGIN
  -- Se consulta el valor de la compra por producto y se almacena en la variable var_ValorCompra
INSERT INTO LOG_COMPRAS (id_log,id_compras,fecha,cantidad,id_cliente,id_producto,fechaDeRegistro,accion)
values (SEQ_LOG_COMPRAS_CLASE.NEXTVAL,:new.id_compras,:new.fecha,:new.cantidad,:new.id_cliente,:new.id_producto,sysdate,'INSERTAR');

END;

-- CREACIÓN DE TRRIGGER ACTUALIZAR TABLAS
create or replace TRIGGER TRG_LOG_VENTA_UPDATE
BEFORE  UPDATE
   ON COMPRAS
   FOR EACH ROW
DECLARE
   --var_ValorCompra NUMBER;

BEGIN
  -- Se consulta el valor de la compra por producto y se almacena en la variable var_ValorCompra
INSERT INTO LOG_COMPRAS (id_log,id_compras,fecha,cantidad,id_cliente,id_producto,fechaDeRegistro,accion)
values (SEQ_LOG_COMPRAS_CLASE.NEXTVAL,:old.id_compras,:old.fecha,:new.cantidad,:old.id_cliente,:new.id_producto,sysdate,'ACTUALIZAR');

END;


-- CREACIÓN DE TRRIGGER ELIMINAR TABLAS
create or replace TRIGGER TRG_LOG_VENTA_ELIMINAR
BEFORE  DELETE
   ON COMPRAS
   FOR EACH ROW
DECLARE
   --var_ValorCompra NUMBER;

BEGIN
INSERT INTO LOG_COMPRAS (id_log,id_compras,fecha,cantidad,id_cliente,id_producto,fechaDeRegistro,accion)
values (SEQ_LOG_COMPRAS_CLASE.NEXTVAL,:old.id_compras,:old.fecha,:old.cantidad,:old.id_cliente,:old.id_producto,sysdate,'ELIMINAR');

END;

----- ******* FIN DE TRIIGGGER ************************


-- INSERT PARA REGISTRAR COMPRAS
INSERT INTO COMPRAS (ID_COMPRAS, FECHA, ID_CLIENTE, ID_PRODUCTO, CANTIDAD) 
VALUES (SEQ_COMPRAS_CLASE.NEXTVAL, sysdate ,1,  1,10 );









