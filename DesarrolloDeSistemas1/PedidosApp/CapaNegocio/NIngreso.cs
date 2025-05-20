using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int idproveedor, int idtrabajador, DateTime fecha, string tipo_comprobante, decimal precio_compra, decimal precio_venta, string estado, int idarticulo, int cantidad)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idproveedor = idproveedor;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Precio_compra = precio_compra;
            Obj.Precio_venta = precio_venta;
            Obj.Estado = estado;
            Obj.Idarticulo = idarticulo;
            Obj.Cantidad = cantidad;
            return Obj.Insertar(Obj);
        }

        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static string Editar(int idingreso, int idproveedor, int idtrabajador, DateTime fecha, string tipo_comprobante, decimal precio_compra, decimal precio_venta, string estado)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            Obj.Idproveedor = idproveedor;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Precio_compra = precio_compra;
            Obj.Precio_venta = precio_venta;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }
    }
}
