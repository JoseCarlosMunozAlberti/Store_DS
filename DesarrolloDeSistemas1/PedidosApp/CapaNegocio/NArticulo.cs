using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NArticulo
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DArticulo de
        // la CapaDatos
        public static string Insertar(string codigo, string nombre, byte[] imagen,
            int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la clase DArticulo de
        // la CapaDatos
        public static string Editar(int idarticulo, string codigo, string nombre, byte[] imagen,
            int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Id = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Eliminar de la clase DArticulo de
        // la CapaDatos
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Id = idarticulo;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la clase DArticulo de
        // la CapaDatos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }
        //Metodo BuscarNombre que llama al metodo BuscarNombre de la clase DArticulo 
        //de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.Textobuscar = textobuscar;
            return new DArticulo().BuscarNombre(Obj);
        }
        //Metodo Stock_articulos que llama al metodo Stock_articulos de la clase 
        //DArticulo de la CapaDatos
        public static DataTable Stock_articulos()
        {
            return new DArticulo().Stock_Articulos();
        }
    }
}
