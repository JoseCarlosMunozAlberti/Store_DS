// NProveedor.cs
using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        public static string Insertar(string razonSocial, string secCom, string email)
        {
            DProveedor obj = new DProveedor
            {
                RazonSocial = razonSocial,
                SecCom = secCom,
                Email = email
            };
            return obj.Insertar(obj);
        }

        public static string Editar(int id, string razonSocial, string secCom, string email)
        {
            DProveedor obj = new DProveedor
            {
                Id = id,
                RazonSocial = razonSocial,
                SecCom = secCom,
                Email = email
            };
            return obj.Editar(obj);
        }

        public static string Eliminar(int id)
        {
            DProveedor obj = new DProveedor { Id = id };
            return obj.Eliminar(obj);
        }

        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        public static DataTable BuscarRazonSocial(string texto)
        {
            DProveedor obj = new DProveedor { TextoBuscar = texto };
            return obj.BuscarRazonSocial(obj);
        }
    }
}
