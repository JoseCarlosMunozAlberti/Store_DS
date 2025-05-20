// FrmCliente.cs
using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombres, "Ingrese los nombres del cliente");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese los apellidos del cliente");
            this.ttMensaje.SetToolTip(this.dtpFechaNac, "Seleccione la fecha de nacimiento");
            this.ttMensaje.SetToolTip(this.txtEmail, "Ingrese el correo electrónico del cliente");

            this.txtIdcliente.Visible = false;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.chkEliminar.CheckedChanged += new EventHandler(this.chkEliminar_CheckedChanged);
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            // Agregar columna checkbox si no existe
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

            // Solo permitir edición en la columna Eliminar
            foreach (DataGridViewColumn col in dataListado.Columns)
            {
                col.ReadOnly = col.Name != "Eliminar";
            }

            // Ocultar columna Eliminar por defecto
            MostrarColumnaEliminar(false);
        }

        private void MostrarColumnaEliminar(bool mostrar)
        {
            if (dataListado.Columns.Contains("Eliminar"))
            {
                dataListado.Columns["Eliminar"].Visible = mostrar;
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            MostrarColumnaEliminar(chkEliminar.Checked);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCliente.BuscarNombre(this.txtBuscar.Text);
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Habilitar(bool valor)
        {
            this.txtNombres.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.dtpFechaNac.Enabled = valor;
            this.txtEmail.ReadOnly = !valor;
        }

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

        private void Limpiar()
        {
            this.txtIdcliente.Text = string.Empty;
            this.txtNombres.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.dtpFechaNac.Value = DateTime.Today;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombres.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombres.Text == string.Empty || this.txtApellidos.Text == string.Empty)
                {
                    MessageBox.Show("Faltan ingresar algunos datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorIcono.SetError(txtNombres, "Ingrese un valor");
                    return;
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(), this.dtpFechaNac.Value, this.txtEmail.Text.Trim());
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text), this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(), this.dtpFechaNac.Value, this.txtEmail.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        MessageBox.Show(this.IsNuevo ? "Se insertó correctamente el registro" : "Se actualizó correctamente el registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(rpta, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!this.txtIdcliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                MessageBox.Show("Debe seleccionar primero el registro a modificar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id"].Value);
            this.txtNombres.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombres"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.dtpFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nac"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion = MessageBox.Show("¿Realmente desea eliminar los registros?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Codigo = Convert.ToString(row.Cells["Id"].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chkEliminar.Checked && e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
    }
}
