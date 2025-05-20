using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;
using System.Collections.Generic;

namespace PedidosApp
{
    public partial class FrmIngreso : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static FrmIngreso _Instancia;
        private int Idingreso;

        public static FrmIngreso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmIngreso();
            }
            return _Instancia;
        }

        public FrmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.cbTrabajador, "Seleccione el trabajador");
            this.ttMensaje.SetToolTip(this.cbArticulo, "Seleccione el artículo");
            this.ttMensaje.SetToolTip(this.txtPrecCompra, "Ingrese el precio de compra");
            this.ttMensaje.SetToolTip(this.txtPrecVenta, "Ingrese el precio de venta");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _Instancia = null;
            base.OnFormClosing(e);
        }

        //Mostrar mensaje de confirmación
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdingreso.Text = string.Empty;
            this.txtPrecCompra.Text = string.Empty;
            this.txtPrecVenta.Text = string.Empty;
            this.cbProveedor.SelectedIndex = -1;
            this.cbTrabajador.SelectedIndex = -1;
            this.cbArticulo.SelectedIndex = -1;
            this.dtpFechaIngreso.Value = DateTime.Now;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtPrecCompra.ReadOnly = !valor;
            this.txtPrecVenta.ReadOnly = !valor;
            this.cbProveedor.Enabled = valor;
            this.cbTrabajador.Enabled = valor;
            this.cbArticulo.Enabled = valor;
            this.dtpFechaIngreso.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            try
            {
                DataTable dt = NIngreso.Mostrar();
                if (dt != null)
                {
                    // Verificar que la tabla tiene las columnas necesarias
                    if (!dt.Columns.Contains("Id"))
                    {
                        MessageBox.Show("Error: La tabla no contiene la columna 'Id'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.dataListado.DataSource = dt;
                    this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
                    
                    // Verificar que los IDs se están mostrando correctamente
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (row.Cells["Id"].Value == null)
                        {
                            MessageBox.Show("Error: Se encontró una fila sin ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    this.OcultarColumnas();
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.Message + "\n\nDetalles: " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            try
            {
                DataTable dt = NIngreso.BuscarNombre(this.txtBuscar.Text);
                if (dt != null)
                {
                    this.dataListado.DataSource = dt;
                    this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar los datos: " + ex.Message);
            }
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.LlenarComboProveedor();
            this.LlenarComboTrabajador();
            this.LlenarComboArticulo();
        }

        private void LlenarComboProveedor()
        {
            try
            {
                DataTable dtProveedores = NProveedor.Mostrar();
                if (dtProveedores != null && dtProveedores.Rows.Count > 0)
                {
                    this.cbProveedor.DataSource = dtProveedores;
                    this.cbProveedor.ValueMember = "id";
                    this.cbProveedor.DisplayMember = "razon_social";
                    this.cbProveedor.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No hay proveedores registrados en la base de datos.", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboTrabajador()
        {
            try
            {
                DataTable dtTrabajadores = NTrabajador.MostrarVendedores();
                dtTrabajadores.Columns.Add("NombreCompleto", typeof(string));

                foreach (DataRow row in dtTrabajadores.Rows)
                {
                    row["NombreCompleto"] = row["nombres"].ToString() + " " + row["apellidos"].ToString();
                }

                this.cbTrabajador.DataSource = dtTrabajadores;
                this.cbTrabajador.ValueMember = "id";
                this.cbTrabajador.DisplayMember = "NombreCompleto";
                this.cbTrabajador.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar trabajadores: " + ex.Message);
            }
        }

        private void LlenarComboArticulo()
        {
            try
            {
                DataTable dtArticulos = NArticulo.Mostrar();
                if (dtArticulos != null && dtArticulos.Rows.Count > 0)
                {
                    this.cbArticulo.DataSource = dtArticulos;
                    this.cbArticulo.ValueMember = "Id";
                    this.cbArticulo.DisplayMember = "nombre";
                    this.cbArticulo.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No hay artículos registrados en la base de datos.", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar artículos:\n\n{ex.Message}\n\nDetalles técnicos:\n{ex.StackTrace}", 
                    "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay registros seleccionados
                List<int> idsSeleccionados = new List<int>();
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
                        {
                            idsSeleccionados.Add(Convert.ToInt32(row.Cells["Id"].Value));
                        }
                    }
                }

                if (idsSeleccionados.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos un registro para eliminar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult Opcion = MessageBox.Show(
                    $"¿Realmente desea eliminar {idsSeleccionados.Count} registro(s) seleccionado(s)?", 
                    "Sistema de Ventas", 
                    MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Question
                );

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    bool algunoEliminado = false;
                    int contadorEliminados = 0;

                    foreach (int id in idsSeleccionados)
                    {
                        Rpta = NIngreso.Anular(id);

                        if (Rpta.Equals("OK"))
                        {
                            algunoEliminado = true;
                            contadorEliminados++;
                        }
                        else
                        {
                            this.MensajeError($"Error al eliminar ingreso {id}: {Rpta}");
                        }
                    }

                    if (algunoEliminado)
                    {
                        this.MensajeOK($"Se eliminaron {contadorEliminados} registro(s) correctamente");
                        this.Mostrar();
                        // Actualizar el reporte de stock si está abierto
                        if (Application.OpenForms["FrmStockArticulos"] != null)
                        {
                            ((Reportes.FrmStockArticulos)Application.OpenForms["FrmStockArticulos"]).RefrescarReporte();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message + "\n\nDetalles: " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (this.dataListado.Columns.Contains("Eliminar") && 
                    e.ColumnIndex == this.dataListado.Columns["Eliminar"].Index)
                {
                    DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                    ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtPrecCompra.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.cbProveedor.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(cbProveedor, "Ingrese un Proveedor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(
                            Convert.ToInt32(this.cbProveedor.SelectedValue),
                            Convert.ToInt32(this.cbTrabajador.SelectedValue),
                            this.dtpFechaIngreso.Value,
                            "Factura",
                            Convert.ToDecimal(this.txtPrecCompra.Text),
                            Convert.ToDecimal(this.txtPrecVenta.Text),
                            "ACEPTADO",
                            Convert.ToInt32(this.cbArticulo.SelectedValue),
                            Convert.ToInt32(this.txtCantIngreso.Text)
                        );
                    }
                    else
                    {
                        rpta = NIngreso.Editar(
                            this.Idingreso,
                            Convert.ToInt32(this.cbProveedor.SelectedValue),
                            Convert.ToInt32(this.cbTrabajador.SelectedValue),
                            this.dtpFechaIngreso.Value,
                            "Factura",
                            Convert.ToDecimal(this.txtPrecCompra.Text),
                            Convert.ToDecimal(this.txtPrecVenta.Text),
                            "ACEPTADO"
                        );
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Insertó de forma correcta el registro");
                            // Actualizar el reporte de stock si está abierto
                            if (Application.OpenForms["FrmStockArticulos"] != null)
                            {
                                ((Reportes.FrmStockArticulos)Application.OpenForms["FrmStockArticulos"]).RefrescarReporte();
                            }
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdingreso.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
        }

        private void txtPrecVenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPrecVenta.Text == string.Empty)
                {
                    this.txtPrecVenta.Text = "0.00";
                }
                else
                {
                    decimal precio = Convert.ToDecimal(this.txtPrecVenta.Text);
                    if (precio < 0)
                    {
                        this.txtPrecVenta.Text = "0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPrecCompra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPrecCompra.Text == string.Empty)
                {
                    this.txtPrecCompra.Text = "0.00";
                }
                else
                {
                    decimal precio = Convert.ToDecimal(this.txtPrecCompra.Text);
                    if (precio < 0)
                    {
                        this.txtPrecCompra.Text = "0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementar lógica si es necesario
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementar lógica si es necesario
        }

        private void cbTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementar lógica si es necesario
        }

        private void dtpFechaIngreso_ValueChanged(object sender, EventArgs e)
        {
            // Implementar lógica si es necesario
        }

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {
            // Implementar lógica si es necesario
        }

        private void txtIdingreso_TextChanged(object sender, EventArgs e)
        {
            // Implementar lógica si es necesario
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Verificamos que se haya hecho clic en una fila válida
                {
                    DataGridViewRow row = this.dataListado.Rows[e.RowIndex];
                    this.txtIdingreso.Text = Convert.ToString(row.Cells["Id"].Value);
                    this.Idingreso = Convert.ToInt32(row.Cells["Id"].Value);
                    
                    // Buscar el ID del proveedor por su nombre
                    string nombreProveedor = Convert.ToString(row.Cells["proveedor"].Value);
                    foreach (DataRowView item in this.cbProveedor.Items)
                    {
                        if (item["razon_social"].ToString() == nombreProveedor)
                        {
                            this.cbProveedor.SelectedValue = item["id"];
                            break;
                        }
                    }

                    // Buscar el ID del trabajador por su nombre
                    string nombreTrabajador = Convert.ToString(row.Cells["trabajador"].Value);
                    foreach (DataRowView item in this.cbTrabajador.Items)
                    {
                        if (item["NombreCompleto"].ToString() == nombreTrabajador)
                        {
                            this.cbTrabajador.SelectedValue = item["id"];
                            break;
                        }
                    }

                    this.dtpFechaIngreso.Value = Convert.ToDateTime(row.Cells["fecha"].Value);
                    this.txtPrecCompra.Text = Convert.ToString(row.Cells["precio_compra"].Value);
                    this.txtPrecVenta.Text = Convert.ToString(row.Cells["precio_venta"].Value);

                    // Desactivamos el modo de edición y nuevo
                    this.IsEditar = false;
                    this.IsNuevo = false;
                    this.Botones();
                    this.Habilitar(false);

                    // Cambiamos a la pestaña de mantenimiento
                    this.tabControl1.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirClick_Click(object sender, EventArgs e)
        {
            Reportes.FrmIngresos frm = new Reportes.FrmIngresos();
            frm.ShowDialog();
        }
    }
}
