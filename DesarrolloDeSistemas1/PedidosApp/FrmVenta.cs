using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmVenta : Form
    {
        private bool IsNuevo = false;
        private static FrmVenta instancia;

        public FrmVenta()
        {
            InitializeComponent();
            this.LlenarTrabajadores();
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();
        }

        public static FrmVenta GetInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmVenta();
            }
            return instancia;
        }

        private void LlenarTrabajadores()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Habilitar(bool valor)
        {
            this.txtCliente.ReadOnly = true;
            this.txtIdCliente.ReadOnly = true;
            this.cbTrabajador.Enabled = valor;
            this.dtpFechaVenta.Enabled = valor;
            this.txtNroFactura.ReadOnly = !valor;
            this.btnBuscarCliente.Enabled = valor;
        }

        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void Limpiar()
        {
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.cbTrabajador.SelectedIndex = -1;
            this.txtNroFactura.Text = string.Empty;
            this.dtpFechaVenta.Value = DateTime.Today;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

            if (!dataListado.Columns.Contains("Eliminar"))
            {
                DataGridViewCheckBoxColumn chkEliminar = new DataGridViewCheckBoxColumn();
                chkEliminar.Name = "Eliminar";
                chkEliminar.HeaderText = "Eliminar";
                chkEliminar.Width = 60;
                chkEliminar.ReadOnly = false;
                chkEliminar.TrueValue = true;
                chkEliminar.FalseValue = false;
                chkEliminar.ThreeState = false;
                dataListado.Columns.Insert(0, chkEliminar);
            }

            foreach (DataGridViewColumn col in dataListado.Columns)
            {
                col.ReadOnly = col.Name != "Eliminar";
            }

            MostrarColumnaEliminar(false);
        }

        private void MostrarColumnaEliminar(bool mostrar)
        {
            if (dataListado.Columns.Contains("Eliminar"))
            {
                dataListado.Columns["Eliminar"].Visible = mostrar;
            }
        }

        private void Buscar()
        {
            try
            {
                this.dataListado.DataSource = NVenta.Buscar(this.txtBuscar.Text.Trim());
                this.lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetCliente(string idCliente, string nombreCliente)
        {
            this.txtIdCliente.Text = idCliente;
            this.txtCliente.Text = nombreCliente;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.tabControl1.SelectedIndex = 1;
            this.cbTrabajador.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIdCliente.Text == string.Empty || this.cbTrabajador.SelectedIndex == -1 || this.txtNroFactura.Text == string.Empty)
                {
                    MessageBox.Show("Faltan ingresar algunos datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int idTrabajador = Convert.ToInt32(this.cbTrabajador.SelectedValue);

                    string rpta = NVenta.Insertar(
                        Convert.ToInt32(this.txtIdCliente.Text),
                        idTrabajador,
                        this.dtpFechaVenta.Value,
                        Convert.ToInt32(this.txtNroFactura.Text)
                    );

                    if (rpta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó correctamente el registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(rpta, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.tabControl1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.tabControl1.SelectedIndex = 0;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente vista = new FrmVistaCliente();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            MostrarColumnaEliminar(chkEliminar.Checked);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chkEliminar.Checked && e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Realmente desea eliminar las ventas seleccionadas?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Codigo = Convert.ToString(row.Cells["id"].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                MessageBox.Show("Se eliminó correctamente el registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(Rpta, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
    }
}

