using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NPresentacion
    {
        public static string Insertar(string nombre)
        {
            DPresentacion obj = new DPresentacion();
            obj.Nombre = nombre;
            return obj.Insertar(obj);
        }

        public static string Editar(int id, string nombre)
        {
            DPresentacion obj = new DPresentacion();
            obj.Id = id;
            obj.Nombre = nombre;
            return obj.Editar(obj);
        }

        public static string Eliminar(int id)
        {
            DPresentacion obj = new DPresentacion();
            obj.Id = id;
            return obj.Eliminar(obj);
        }

        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        public static DataTable BuscarNombre(string texto)
        {
            DPresentacion obj = new DPresentacion();
            obj.TextoBuscar = texto;
            return new DPresentacion().BuscarNombre(obj);
        }
    }
}
