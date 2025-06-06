﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCategoria
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DCategoria de
        // la CapaDatos
        public static string Insertar(string nombre, int subcat)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Subcat = subcat;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la clase DCategoria de
        // la CapaDatos
        public static string Editar(int idcategoria, string nombre, int subcat)
        {
            DCategoria Obj = new DCategoria();
            Obj.Id = idcategoria;
            Obj.Nombre = nombre;
            Obj.Subcat = subcat;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Eliminar de la clase DCategoria de
        // la CapaDatos
        public static string Eliminar(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Id = idcategoria;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la clase DCategoria de
        // la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }
        //Metodo BuscarNombre que llama al metodo BuscarNombre de la clase DCategoria 
        //de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.Textobuscar = textobuscar;
            return new DCategoria().BuscarNombre(Obj);
        }
    }
}
