using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso : DbConnection
    {
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_comprobante;
        private decimal _Precio_compra;
        private decimal _Precio_venta;
        private string _Estado;
        private string _TextoBuscar;
        private int _Idarticulo;
        private int _Cantidad;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_comprobante { get => _Tipo_comprobante; set => _Tipo_comprobante = value; }
        public decimal Precio_compra { get => _Precio_compra; set => _Precio_compra = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }

        public DIngreso()
        {
        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, decimal precio_compra, decimal precio_venta, string estado, string textobuscar, int idarticulo, int cantidad)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_comprobante = tipo_comprobante;
            this.Precio_compra = precio_compra;
            this.Precio_venta = precio_venta;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
            this.Idarticulo = idarticulo;
            this.Cantidad = cantidad;
        }

        public string Insertar(DIngreso Ingreso)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spinsertar_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Value = Ingreso.Idproveedor;
                        command.Parameters.Add(ParIdproveedor);

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Value = Ingreso.Idtrabajador;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParFecha = new SqlParameter();
                        ParFecha.ParameterName = "@fecha";
                        ParFecha.SqlDbType = SqlDbType.DateTime;
                        ParFecha.Value = Ingreso.Fecha;
                        command.Parameters.Add(ParFecha);

                        SqlParameter ParTipo_comprobante = new SqlParameter();
                        ParTipo_comprobante.ParameterName = "@tipo_comp";
                        ParTipo_comprobante.SqlDbType = SqlDbType.VarChar;
                        ParTipo_comprobante.Size = 20;
                        ParTipo_comprobante.Value = Ingreso.Tipo_comprobante;
                        command.Parameters.Add(ParTipo_comprobante);

                        SqlParameter ParPrecio_compra = new SqlParameter();
                        ParPrecio_compra.ParameterName = "@precio_compra";
                        ParPrecio_compra.SqlDbType = SqlDbType.Decimal;
                        ParPrecio_compra.Precision = 18;
                        ParPrecio_compra.Scale = 2;
                        ParPrecio_compra.Value = Ingreso.Precio_compra;
                        command.Parameters.Add(ParPrecio_compra);

                        SqlParameter ParPrecio_venta = new SqlParameter();
                        ParPrecio_venta.ParameterName = "@precio_venta";
                        ParPrecio_venta.SqlDbType = SqlDbType.Decimal;
                        ParPrecio_venta.Precision = 18;
                        ParPrecio_venta.Scale = 2;
                        ParPrecio_venta.Value = Ingreso.Precio_venta;
                        command.Parameters.Add(ParPrecio_venta);

                        SqlParameter ParEstado = new SqlParameter();
                        ParEstado.ParameterName = "@estado";
                        ParEstado.SqlDbType = SqlDbType.VarChar;
                        ParEstado.Size = 20;
                        ParEstado.Value = Ingreso.Estado;
                        command.Parameters.Add(ParEstado);

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@idarticulo";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Value = Ingreso.Idarticulo;
                        command.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCantidad = new SqlParameter();
                        ParCantidad.ParameterName = "@cantidad";
                        ParCantidad.SqlDbType = SqlDbType.Int;
                        ParCantidad.Value = Ingreso.Cantidad;
                        command.Parameters.Add(ParCantidad);

                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingresó el Registro";
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

        public string Editar(DIngreso Ingreso)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speditar_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdingreso = new SqlParameter();
                        ParIdingreso.ParameterName = "@idingreso";
                        ParIdingreso.SqlDbType = SqlDbType.Int;
                        ParIdingreso.Value = Ingreso.Idingreso;
                        command.Parameters.Add(ParIdingreso);

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Value = Ingreso.Idproveedor;
                        command.Parameters.Add(ParIdproveedor);

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Value = Ingreso.Idtrabajador;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParFecha = new SqlParameter();
                        ParFecha.ParameterName = "@fecha";
                        ParFecha.SqlDbType = SqlDbType.DateTime;
                        ParFecha.Value = Ingreso.Fecha;
                        command.Parameters.Add(ParFecha);

                        SqlParameter ParTipo_comprobante = new SqlParameter();
                        ParTipo_comprobante.ParameterName = "@tipo_comp";
                        ParTipo_comprobante.SqlDbType = SqlDbType.VarChar;
                        ParTipo_comprobante.Size = 20;
                        ParTipo_comprobante.Value = Ingreso.Tipo_comprobante;
                        command.Parameters.Add(ParTipo_comprobante);

                        SqlParameter ParPrecio_compra = new SqlParameter();
                        ParPrecio_compra.ParameterName = "@precio_compra";
                        ParPrecio_compra.SqlDbType = SqlDbType.Decimal;
                        ParPrecio_compra.Precision = 18;
                        ParPrecio_compra.Scale = 2;
                        ParPrecio_compra.Value = Ingreso.Precio_compra;
                        command.Parameters.Add(ParPrecio_compra);

                        SqlParameter ParPrecio_venta = new SqlParameter();
                        ParPrecio_venta.ParameterName = "@precio_venta";
                        ParPrecio_venta.SqlDbType = SqlDbType.Decimal;
                        ParPrecio_venta.Precision = 18;
                        ParPrecio_venta.Scale = 2;
                        ParPrecio_venta.Value = Ingreso.Precio_venta;
                        command.Parameters.Add(ParPrecio_venta);

                        SqlParameter ParEstado = new SqlParameter();
                        ParEstado.ParameterName = "@estado";
                        ParEstado.SqlDbType = SqlDbType.VarChar;
                        ParEstado.Size = 20;
                        ParEstado.Value = Ingreso.Estado;
                        command.Parameters.Add(ParEstado);

                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizó el Registro";
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

        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    
                    // Verificamos si el registro existe y no está anulado
                    using (SqlCommand checkCmd = new SqlCommand())
                    {
                        checkCmd.Connection = connection;
                        checkCmd.CommandText = "SELECT COUNT(*) FROM ingreso WHERE Id = @idingreso AND estado <> 'ANULADO'";
                        checkCmd.Parameters.AddWithValue("@idingreso", Ingreso.Idingreso);
                        
                        int existe = (int)checkCmd.ExecuteScalar();
                        
                        if (existe == 0)
                        {
                            return "El ingreso ya ha sido eliminado o no existe.";
                        }
                    }

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "speliminar_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdingreso = new SqlParameter();
                        ParIdingreso.ParameterName = "@idingreso";
                        ParIdingreso.SqlDbType = SqlDbType.Int;
                        ParIdingreso.Value = Ingreso.Idingreso;
                        command.Parameters.Add(ParIdingreso);
                        
                        int resultado = command.ExecuteNonQuery();
                        
                        if (resultado > 0)
                        {
                            rpta = "OK";
                        }
                        else
                        {
                            rpta = "No se pudo eliminar el ingreso.";
                        }
                    }
                }
                catch (SqlException ex)
                {
                    rpta = $"Error SQL: {ex.Message}";
                }
                catch (Exception ex)
                {
                    rpta = $"Error general: {ex.Message}";
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("ingreso");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_ingreso";
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

        public DataTable BuscarNombre(DIngreso Ingreso)
        {
            DataTable DtResultado = new DataTable("ingreso");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Ingreso.TextoBuscar;
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
