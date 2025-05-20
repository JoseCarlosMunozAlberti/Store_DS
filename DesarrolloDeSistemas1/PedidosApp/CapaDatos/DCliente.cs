using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente : DbConnection
    {
        private int _Id;
        private string _Nombres;
        private string _Apellidos;
        private DateTime _FechaNac;
        private string _Email;
        private string _TextoBuscar;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public DateTime FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public string Insertar(DCliente obj)
        {
            string rpta = "";
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO cliente (nombres, apellidos, fecha_nac, email) VALUES (@nombres, @apellidos, @fecha_nac, @email)", con);
                cmd.Parameters.AddWithValue("@nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@fecha_nac", obj.FechaNac);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al insertar";
            }
            return rpta;
        }

        public string Editar(DCliente obj)
        {
            string rpta = "";
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE cliente SET nombres=@nombres, apellidos=@apellidos, fecha_nac=@fecha_nac, email=@email WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@fecha_nac", obj.FechaNac);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al editar";
            }
            return rpta;
        }

        public string Eliminar(DCliente obj)
        {
            string rpta = "";
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM cliente WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al eliminar";
            }
            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("cliente");
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cliente ORDER BY Id DESC", con);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarNombre(DCliente obj)
        {
            DataTable dt = new DataTable("cliente");
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cliente WHERE nombres LIKE @texto OR apellidos LIKE @texto", con);
                cmd.Parameters.AddWithValue("@texto", $"%{obj.TextoBuscar}%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
