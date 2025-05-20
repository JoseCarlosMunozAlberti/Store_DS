// DProveedor.cs
using CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor : DbConnection
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string SecCom { get; set; }
        public string Email { get; set; }
        public string TextoBuscar { get; set; }

        public string Insertar(DProveedor obj)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO proveedor (razon_social, sec_com, email) VALUES (@razon_social, @sec_com, @email)", con);
                cmd.Parameters.AddWithValue("@razon_social", obj.RazonSocial);
                cmd.Parameters.AddWithValue("@sec_com", obj.SecCom);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                return cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al insertar";
            }
        }

        public string Editar(DProveedor obj)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE proveedor SET razon_social=@razon_social, sec_com=@sec_com, email=@email WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@razon_social", obj.RazonSocial);
                cmd.Parameters.AddWithValue("@sec_com", obj.SecCom);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                return cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al editar";
            }
        }

        public string Eliminar(DProveedor obj)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM proveedor WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                return cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al eliminar";
            }
        }

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("proveedor");
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM proveedor ORDER BY id DESC", con);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarRazonSocial(DProveedor obj)
        {
            DataTable dt = new DataTable("proveedor");
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM proveedor WHERE razon_social LIKE @texto", con);
                cmd.Parameters.AddWithValue("@texto", "%" + obj.TextoBuscar + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
