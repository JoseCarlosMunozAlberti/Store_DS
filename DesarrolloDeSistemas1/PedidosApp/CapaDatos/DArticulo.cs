using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulo : DbConnection
    {
        //Campos y propiedades
        private int _Id;
        private string _codigo;
        private string _nombre;
        private byte[] _imagen;
        private int _idcategoria;
        private int _idpresentacion;
        private DateTime _fecha;
        private string _textobuscar;
        //Refactorizar las variables privadas para generar las propiedades
        public int Id { get => _Id; set => _Id = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public byte[] Imagen { get => _imagen; set => _imagen = value; }
        public int Idcategoria { get => _idcategoria; set => _idcategoria = value; }
        public int Idpresentacion { get => _idpresentacion; set => _idpresentacion = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }
        //Constructores
        public DArticulo() { }
        public DArticulo(int id, string codigo, string nombre, byte[] imagen,
            int idcategoria, int idpresentacion, DateTime fecha, string textobuscar)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Imagen = imagen;
            Idcategoria = idcategoria;
            Idpresentacion = idpresentacion;
            Fecha = fecha;
            Textobuscar = textobuscar;
        }
        //Metodo Insertar
        public string Insertar(DArticulo Articulo)
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
                        command.CommandText = "spinsertar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@id";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCodigo = new SqlParameter();
                        ParCodigo.ParameterName = "@codigo";
                        ParCodigo.SqlDbType = SqlDbType.VarChar;
                        ParCodigo.Size = 20;
                        ParCodigo.Value = Articulo.Codigo;
                        command.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 100;
                        ParNombre.Value = Articulo.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParImagen = new SqlParameter();
                        ParImagen.ParameterName = "@imagen";
                        ParImagen.SqlDbType = SqlDbType.Image;
                        ParImagen.Value = Articulo.Imagen;
                        command.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Articulo.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Articulo.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);
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
        public string Editar(DArticulo Articulo)
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
                        command.CommandText = "speditar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@id";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Value = Articulo.Id;
                        command.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCodigo = new SqlParameter();
                        ParCodigo.ParameterName = "@codigo";
                        ParCodigo.SqlDbType = SqlDbType.VarChar;
                        ParCodigo.Size = 20;
                        ParCodigo.Value = Articulo.Codigo;
                        command.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 100;
                        ParNombre.Value = Articulo.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParImagen = new SqlParameter();
                        ParImagen.ParameterName = "@imagen";
                        ParImagen.SqlDbType = SqlDbType.Image;
                        ParImagen.Value = Articulo.Imagen;
                        command.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Articulo.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Articulo.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);
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
        public string Eliminar(DArticulo Articulo)
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
                        command.CommandText = "speliminar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@id";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Value = Articulo.Id;
                        command.Parameters.Add(ParIdarticulo);
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
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_articulo";
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
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_articulo_nombre";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Articulo.Textobuscar;
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
        //Metodo stock articulos
        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spstock_articulos";
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
    }
}
