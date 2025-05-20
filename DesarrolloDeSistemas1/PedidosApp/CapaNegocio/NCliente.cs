using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        public static string Insertar(string nombres, string apellidos, DateTime fechaNac, string email)
        {
            DCliente obj = new DCliente
            {
                Nombres = nombres,
                Apellidos = apellidos,
                FechaNac = fechaNac,
                Email = email
            };
            return obj.Insertar(obj);
        }

        public static string Editar(int id, string nombres, string apellidos, DateTime fechaNac, string email)
        {
            DCliente obj = new DCliente
            {
                Id = id,
                Nombres = nombres,
                Apellidos = apellidos,
                FechaNac = fechaNac,
                Email = email
            };
            return obj.Editar(obj);
        }

        public static string Eliminar(int id)
        {
            DCliente obj = new DCliente { Id = id };
            return obj.Eliminar(obj);
        }

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        public static DataTable BuscarNombre(string texto)
        {
            DCliente obj = new DCliente { TextoBuscar = texto };
            return obj.BuscarNombre(obj);
        }
    }
}
