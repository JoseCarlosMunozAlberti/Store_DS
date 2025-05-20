using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha_ven, int nro_fac)
        {
            DVenta Obj = new DVenta
            {
                IdCliente = idcliente,
                IdTrabajador = idtrabajador,
                FechaVen = fecha_ven,
                NroFac = nro_fac
            };
            return Obj.Insertar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            return new DVenta().Buscar(textoBuscar);
        }

        public static string Eliminar(int idventa)
        {
            return new DVenta().Eliminar(idventa);
        }
    }
}
