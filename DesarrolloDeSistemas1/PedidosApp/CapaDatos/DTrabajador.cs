using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador : DbConnection
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public string Acceso { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string TextoBuscar { get; set; }

        public string Insertar(DTrabajador obj)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO trabajador (nombres, apellidos, fecha_nac, acceso, usuario, clave) VALUES (@nombres, @apellidos, @fecha_nac, @acceso, @usuario, @clave)", con);
                cmd.Parameters.AddWithValue("@nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@fecha_nac", obj.FechaNac);
                cmd.Parameters.AddWithValue("@acceso", obj.Acceso);
                cmd.Parameters.AddWithValue("@usuario", obj.Usuario);
                cmd.Parameters.AddWithValue("@clave", obj.Clave);
                return cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al insertar";
            }
        }

        public string Editar(DTrabajador obj)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE trabajador SET nombres=@nombres, apellidos=@apellidos, fecha_nac=@fecha_nac, acceso=@acceso, usuario=@usuario, clave=@clave WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@fecha_nac", obj.FechaNac);
                cmd.Parameters.AddWithValue("@acceso", obj.Acceso);
                cmd.Parameters.AddWithValue("@usuario", obj.Usuario);
                cmd.Parameters.AddWithValue("@clave", obj.Clave);
                return cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al editar";
            }
        }

        public string Eliminar(DTrabajador obj)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM trabajador WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                return cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al eliminar";
            }
        }

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("trabajador");
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM trabajador ORDER BY id DESC", con);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarNombre(DTrabajador obj)
        {
            DataTable dt = new DataTable("trabajador");
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM trabajador WHERE nombres LIKE @texto OR apellidos LIKE @texto", con);
                cmd.Parameters.AddWithValue("@texto", "%" + obj.TextoBuscar + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable Login(DTrabajador obj)
        {
            DataTable dt = new DataTable("trabajador");
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id, nombres, apellidos, acceso FROM trabajador WHERE usuario = @usuario AND clave = @clave", con);
                    cmd.Parameters.AddWithValue("@usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("@clave", obj.Clave);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception)
                {
                    dt = null;
                }
            }
            return dt;
        }
        public DataTable MostrarVendedores()
        {
            DataTable dt = new DataTable("trabajador");
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT id, nombres, apellidos FROM trabajador WHERE acceso = 'Vendedor' ORDER BY nombres", con);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
