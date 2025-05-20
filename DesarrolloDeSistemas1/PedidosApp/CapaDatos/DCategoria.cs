using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria : DbConnection
    {
        //Campos y propiedades
        private int _Id;
        private string _nombre;
        private int _subcat;
        private string _textobuscar;
        //Refactorizar las variables privadas para generar la propiedades
        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Subcat { get => _subcat; set => _subcat = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }
        //Constructor vacio
        public DCategoria() { }
        //Constructor con parametros
        public DCategoria(int id, string nombre, int subcat, string textobuscar)
        {
            Id = id;
            Nombre = nombre;
            Subcat = subcat;
            Textobuscar = textobuscar;
        }
        //Metodo Insertar
        public string Insertar(DCategoria Categoria)
        {
            string rpta = string.Empty;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spinsertar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@id";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Categoria.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParSubcat = new SqlParameter();
                        ParSubcat.ParameterName = "@subcat";
                        ParSubcat.SqlDbType = SqlDbType.Int;
                        ParSubcat.Value = Categoria.Subcat;
                        command.Parameters.Add(ParSubcat);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return rpta;
        }
        //Metodo Editar
        public string Editar(DCategoria Categoria)
        {
            string rpta = string.Empty;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speditar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@id";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Categoria.Id;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Categoria.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParSubcat = new SqlParameter();
                        ParSubcat.ParameterName = "@subcat";
                        ParSubcat.SqlDbType = SqlDbType.Int;
                        ParSubcat.Value = Categoria.Subcat;
                        command.Parameters.Add(ParSubcat);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return rpta;
        }
        //Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
        {
            string rpta = string.Empty;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speliminar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@id";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Categoria.Id;
                        command.Parameters.Add(ParIdcategoria);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return rpta;
        }
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        //Metodo BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Categoria.Textobuscar;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
    }
}
