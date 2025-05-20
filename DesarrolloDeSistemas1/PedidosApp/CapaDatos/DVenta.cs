using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdTrabajador { get; set; }
        public DateTime FechaVen { get; set; }
        public int NroFac { get; set; }

        public DVenta() { }

        // Insertar
        public string Insertar(DVenta venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(DbConnection.cn);

            try
            {
                SqlCon.Open();
                string query = "INSERT INTO venta (idcliente, idtrabajador, fecha_ven, nro_fac, fecha) " +
                               "VALUES (@idcliente, @idtrabajador, @fecha_ven, @nro_fac, GETDATE())";
                SqlCommand SqlCmd = new SqlCommand(query, SqlCon);

                SqlCmd.Parameters.AddWithValue("@idcliente", venta.IdCliente);
                SqlCmd.Parameters.AddWithValue("@idtrabajador", venta.IdTrabajador);
                SqlCmd.Parameters.AddWithValue("@fecha_ven", venta.FechaVen);
                SqlCmd.Parameters.AddWithValue("@nro_fac", venta.NroFac);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        // Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection(DbConnection.cn);

            try
            {
                string query = "SELECT id, idcliente, idtrabajador, fecha_ven, nro_fac, fecha FROM venta ORDER BY id DESC";
                SqlCommand SqlCmd = new SqlCommand(query, SqlCon);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        // Buscar por nro_fac
        public DataTable Buscar(string textoBuscar)
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection(DbConnection.cn);

            try
            {
                string query = "SELECT id, idcliente, idtrabajador, fecha_ven, nro_fac, fecha " +
                               "FROM venta WHERE CAST(nro_fac AS VARCHAR) LIKE @textobuscar + '%' ORDER BY id DESC";
                SqlCommand SqlCmd = new SqlCommand(query, SqlCon);

                SqlCmd.Parameters.AddWithValue("@textobuscar", textoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        // Eliminar
        public string Eliminar(int idVenta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(DbConnection.cn);

            try
            {
                SqlCon.Open();
                string query = "DELETE FROM venta WHERE id = @id";
                SqlCommand SqlCmd = new SqlCommand(query, SqlCon);

                SqlCmd.Parameters.AddWithValue("@id", idVenta);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }
    }
}
