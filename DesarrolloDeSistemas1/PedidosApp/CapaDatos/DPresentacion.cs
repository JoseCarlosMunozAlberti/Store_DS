using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPresentacion : DbConnection
    {
        private int _Id;
        private string _Nombre;
        private string _TextoBuscar;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DPresentacion() { }

        public DPresentacion(int id, string nombre, string textobuscar)
        {
            Id = id;
            Nombre = nombre;
            TextoBuscar = textobuscar;
        }

        public string Insertar(DPresentacion obj)
        {
            string rpta = "";
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spinsertar_presentacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pid = new SqlParameter("@id", SqlDbType.Int);
                    pid.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pid);

                    SqlParameter pnombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                    pnombre.Value = obj.Nombre;
                    cmd.Parameters.Add(pnombre);

                    rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESÓ EL REGISTRO";
                }
                catch (Exception ex)
                {
                    rpta = ex.Message;
                }
            }
            return rpta;
        }

        public string Editar(DPresentacion obj)
        {
            string rpta = "";
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("speditar_presentacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);

                    rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZÓ EL REGISTRO";
                }
                catch (Exception ex)
                {
                    rpta = ex.Message;
                }
            }
            return rpta;
        }

        public string Eliminar(DPresentacion obj)
        {
            string rpta = "";
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("speliminar_presentacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", obj.Id);

                    rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINÓ EL REGISTRO";
                }
                catch (Exception ex)
                {
                    rpta = ex.Message;
                }
            }
            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("presentacion");
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spmostrar_presentacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch
                {
                    dt = null;
                }
            }
            return dt;
        }

        public DataTable BuscarNombre(DPresentacion obj)
        {
            DataTable dt = new DataTable("presentacion");
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spbuscar_presentacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pbuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                    pbuscar.Value = obj.TextoBuscar;
                    cmd.Parameters.Add(pbuscar);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch
                {
                    dt = null;
                }
            }
            return dt;
        }
    }
}
