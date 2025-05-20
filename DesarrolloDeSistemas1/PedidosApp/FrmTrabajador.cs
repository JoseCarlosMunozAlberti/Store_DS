// FrmTrabajador.cs
using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmTrabajador : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombres, "Ingrese el nombre del trabajador");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese el apellido del trabajador");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese el usuario de acceso");
            this.ttMensaje.SetToolTip(this.txtClave, "Ingrese la contraseña de acceso");

            this.txtIdtrabajador.Visible = false;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.chkEliminar.CheckedChanged += new EventHandler(this.chkEliminar_CheckedChanged);
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NTrabajador.Mostrar();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (!dataListado.Columns.Contains("Eliminar"))
            {
                DataGridViewCheckBoxColumn chkEliminar = new DataGridViewCheckBoxColumn();
                chkEliminar.Name = "Eliminar";
                chkEliminar.HeaderText = "Eliminar";
                chkEliminar.Width = 60;
                chkEliminar.ReadOnly = false;
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            MostrarColumnaEliminar(chkEliminar.Checked);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNombre(this.txtBuscar.Text);
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Habilitar(bool valor)
        {
            this.txtNombres.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.dtpFechaNac.Enabled = valor;
            this.cbAcceso.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtClave.ReadOnly = !valor;
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
            this.txtIdtrabajador.Text = string.Empty;
            this.txtNombres.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtClave.Text = string.Empty;
            this.cbAcceso.SelectedIndex = -1;
            this.dtpFechaNac.Value = DateTime.Today;
        }

        private void FrmTrabajador_Load(object sender, EventArgs e)
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
                if (this.txtNombres.Text == string.Empty || this.txtApellidos.Text == string.Empty || this.cbAcceso.Text == string.Empty || this.txtUsuario.Text == string.Empty || this.txtClave.Text == string.Empty)
                {
                    MessageBox.Show("Faltan ingresar algunos datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorIcono.SetError(txtNombres, "Ingrese un valor");
                    return;
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NTrabajador.Insertar(this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(), this.dtpFechaNac.Value, this.cbAcceso.Text, this.txtUsuario.Text.Trim(), this.txtClave.Text.Trim());
                    }
                    else
                    {
                        rpta = NTrabajador.Editar(Convert.ToInt32(this.txtIdtrabajador.Text), this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(), this.dtpFechaNac.Value, this.cbAcceso.Text, this.txtUsuario.Text.Trim(), this.txtClave.Text.Trim());
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
            if (!this.txtIdtrabajador.Text.Equals(""))
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
            this.txtIdtrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
            this.txtNombres.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombres"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.dtpFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nac"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtClave.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["clave"].Value);
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
                            Codigo = Convert.ToString(row.Cells["id"].Value);
                            Rpta = NTrabajador.Eliminar(Convert.ToInt32(Codigo));

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
