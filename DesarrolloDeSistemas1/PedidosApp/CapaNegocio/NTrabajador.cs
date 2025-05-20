using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTrabajador
    {
        public static string Insertar(string nombres, string apellidos, DateTime fechaNac, string acceso, string usuario, string clave)
        {
            DTrabajador obj = new DTrabajador
            {
                Nombres = nombres,
                Apellidos = apellidos,
                FechaNac = fechaNac,
                Acceso = acceso,
                Usuario = usuario,
                Clave = clave
            };
            return obj.Insertar(obj);
        }

        public static string Editar(int id, string nombres, string apellidos, DateTime fechaNac, string acceso, string usuario, string clave)
        {
            DTrabajador obj = new DTrabajador
            {
                Id = id,
                Nombres = nombres,
                Apellidos = apellidos,
                FechaNac = fechaNac,
                Acceso = acceso,
                Usuario = usuario,
                Clave = clave
            };
            return obj.Editar(obj);
        }

        public static string Eliminar(int id)
        {
            DTrabajador obj = new DTrabajador { Id = id };
            return obj.Eliminar(obj);
        }

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        public static DataTable BuscarNombre(string texto)
        {
            DTrabajador obj = new DTrabajador { TextoBuscar = texto };
            return obj.BuscarNombre(obj);
        }

        public static DataTable Login(string usuario, string clave)
        {
            DTrabajador obj = new DTrabajador
            {
                Usuario = usuario,
                Clave = clave
            };
            return obj.Login(obj);
        }
        public static DataTable MostrarVendedores()
        {
            return new DTrabajador().MostrarVendedores();
        }

    }
}
