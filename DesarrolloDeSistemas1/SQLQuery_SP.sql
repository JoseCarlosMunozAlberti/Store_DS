create procedure spinsertar_articulo
@id int output,
@codigo varchar(20),
@nombre varchar(100),
@imagen image,
@idcategoria int,
@idpresentacion int
as
insert into articulo(codigo,nombre,imagen,idcategoria,
idpresentacion) 
values(@codigo,@nombre,@imagen,
@idcategoria,@idpresentacion)

create proc speditar_articulo
@id int,
@codigo varchar(20),
@nombre varchar(100),
@imagen image,
@idcategoria int,
@idpresentacion int
as
update articulo set codigo=@codigo,nombre=@nombre,
imagen=@imagen,idcategoria=@idcategoria,
@idpresentacion=@idpresentacion
where Id=@id

create proc speliminar_articulo
@id int
as
delete from articulo
where Id = @id

create proc spmostrar_articulo
as
select a.Id,a.codigo,a.nombre,a.imagen,a.idcategoria,
c.nombre as categoria,a.idpresentacion,p.nombre as 
presentacion
from articulo a inner join categoria c
on a.idcategoria = c.Id
inner join presentacion p
on a.idpresentacion = p.Id
order by a.Id desc

create proc spbuscar_articulo_nombre
@textobuscar varchar(50)
as
select a.Id,a.codigo,a.nombre,a.imagen,a.idcategoria,
c.nombre as categoria,a.idpresentacion,p.nombre as 
presentacion
from articulo a inner join categoria c
on a.idcategoria = c.Id
inner join presentacion p
on a.idpresentacion = p.Id
where a.nombre like '%'+@textobuscar+'%'
order by a.Id desc

create proc spstock_articulos
as
select 
    a.codigo,
    a.nombre,
    c.nombre as categoria,
    ISNULL(SUM(di.stock_inicial), 0) as Cantidad_ingreso,
    ISNULL(SUM(di.stock_actual), 0) as Cantidad_stock,
    ISNULL(SUM(di.stock_inicial - di.stock_actual), 0) as Cantidad_Vendida
from articulo a 
left join categoria c on a.idcategoria = c.Id
left join detalle_ingreso di on a.Id = di.idarticulo
left join ingreso i on di.idingreso = i.Id and i.estado <> 'ANULADO'
group by a.codigo, a.nombre, c.nombre

create proc spinsertar_categoria
@id int output,
@nombre varchar(50),
@subcat int
as
insert into categoria(nombre,subcat)
values(@nombre,@subcat)
go
create proc speditar_categoria
@id int,
@nombre varchar(50),
@subcat int
as
update categoria set nombre=@nombre,subcat=@subcat
where Id=@id
go
create proc speliminar_categoria
@id int
as
delete from categoria where Id=@id
go
create proc spmostrar_categoria
as
select * from categoria
order by Id desc
go
create proc spbuscar_categoria
@textobuscar varchar(50)
as
select * from categoria
where nombre like '%'+@textobuscar+'%'
go

create proc spinsertar_presentacion
@id int output,
@nombre varchar(50)
as
insert into presentacion(nombre)
values(@nombre)
go
create proc speditar_presentacion
@id int,
@nombre varchar(50)
as
update presentacion set nombre=@nombre
where Id=@id
go
create proc speliminar_presentacion
@id int
as
delete from presentacion where Id=@id
go
create proc spmostrar_presentacion
as
select * from presentacion
order by Id desc
go
create proc spbuscar_presentacion
@textobuscar varchar(50)
as
select * from presentacion
where nombre like '%'+@textobuscar+'%'

create procedure spinsertar_ingreso
@idproveedor int,
@idtrabajador int,
@fecha datetime,
@tipo_comp varchar(20),
@precio_compra decimal(18,2),
@precio_venta decimal(18,2),
@estado varchar(20),
@idarticulo int,
@cantidad int
as
begin
    begin try
        begin transaction;
        
        declare @idingreso int
        
        -- Insertar en la tabla ingreso
        insert into ingreso(idproveedor,idtrabajador,fecha_ing,tipo_comp,precio_compra,precio_venta,estado)
        values(@idproveedor,@idtrabajador,@fecha,@tipo_comp,@precio_compra,@precio_venta,@estado)
        
        -- Obtener el ID del ingreso insertado
        set @idingreso = SCOPE_IDENTITY()
        
        -- Insertar en la tabla detalle_ingreso
        -- stock_inicial es la cantidad que ingresa
        -- stock_actual es la cantidad disponible (inicialmente igual a stock_inicial)
        insert into detalle_ingreso(idingreso,idarticulo,precio_compra,precio_venta,stock_inicial,stock_actual)
        values(@idingreso,@idarticulo,@precio_compra,@precio_venta,@cantidad,@cantidad)
        
        commit transaction;
        select 'OK' as resultado;
    end try
    begin catch
        rollback transaction;
        select ERROR_MESSAGE() as resultado;
    end catch
end

create proc spmostrar_ingreso
as
select 
    i.Id,
    i.idproveedor,
    p.razon_social as proveedor,
    i.idtrabajador,
    t.nombres + ' ' + t.apellidos as trabajador,
    i.fecha_ing as fecha,
    i.tipo_comp,
    i.precio_compra,
    i.precio_venta,
    i.estado
from ingreso i 
inner join proveedor p on i.idproveedor = p.Id
inner join trabajador t on i.idtrabajador = t.Id
where i.estado <> 'ANULADO'
order by i.Id desc

create proc spbuscar_ingreso
@textobuscar varchar(50)
as
select i.Id,i.idproveedor,p.razon_social as proveedor,
i.idtrabajador,t.nombres + ' ' + t.apellidos as trabajador,
i.fecha_ing,i.tipo_comp,i.precio_compra,i.precio_venta,i.estado
from ingreso i inner join proveedor p
on i.idproveedor = p.Id
inner join trabajador t
on i.idtrabajador = t.Id
where p.razon_social like '%'+@textobuscar+'%'
order by i.Id desc

create procedure speliminar_ingreso
@idingreso int
as
begin
    begin try
        begin transaction;
        
        -- Primero eliminamos los detalles del ingreso específico
        delete from detalle_ingreso
        where idingreso = @idingreso;
        
        -- Luego eliminamos el ingreso específico
        delete from ingreso
        where Id = @idingreso;
        
        commit transaction;
        select 'OK' as resultado;
    end try
    begin catch
        rollback transaction;
        select ERROR_MESSAGE() as resultado;
    end catch
end

create proc speditar_ingreso
@idingreso int,
@idproveedor int,
@idtrabajador int,
@fecha datetime,
@tipo_comp varchar(20),
@precio_compra decimal(18,2),
@precio_venta decimal(18,2),
@estado varchar(20)
as
update ingreso set idproveedor=@idproveedor,idtrabajador=@idtrabajador,fecha_ing=@fecha,tipo_comp=@tipo_comp,precio_compra=@precio_compra,precio_venta=@precio_venta,estado=@estado
where Id=@idingreso

-- Procedimiento para corregir los datos de stock
create procedure spcorregir_stock
as
begin
    begin try
        begin transaction;
        
        -- Actualizar stock_actual para que sea igual a stock_inicial menos las ventas
        update di
        set di.stock_actual = di.stock_inicial - ISNULL((
            select SUM(dv.cantidad)
            from detalle_venta dv
            where dv.iddetalle_ingreso = di.Id
        ), 0)
        from detalle_ingreso di
        inner join ingreso i on di.idingreso = i.Id
        where i.estado <> 'ANULADO';
        
        commit transaction;
        select 'OK' as resultado;
    end try
    begin catch
        rollback transaction;
        select ERROR_MESSAGE() as resultado;
    end catch
end


