using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmPresentacion : Form
    {
        private bool Isnuevo = false;
        private bool Iseditar = false;

        public FrmPresentacion()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre de la presentación");
            this.dataListado.CellClick += new DataGridViewCellEventHandler(this.dataListado_CellClick); // <<< AÑADIDO
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            txtIdpresentacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            txtIdpresentacion.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
        }

        private void Botones()
        {
            if (Isnuevo || Iseditar)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            if (dataListado.RowCount > 0)
            {
                dataListado.Columns[0].Visible = false;
                dataListado.Columns[1].Visible = false;
            }
            chkEliminar.Checked = false;
        }

        private void Mostrar()
        {
            dataListado.DataSource = NPresentacion.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Registros encontrados : " + dataListado.Rows.Count.ToString();
            tabControl1.SelectedIndex = 0;
        }

        private void BuscarNombre()
        {
            dataListado.DataSource = NPresentacion.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Registros encontrados : " + dataListado.Rows.Count.ToString();
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Isnuevo = true;
            Iseditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese nombre de la presentación");
                }
                else
                {
                    if (Isnuevo)
                    {
                        rpta = NPresentacion.Insertar(txtNombre.Text.Trim().ToUpper());
                    }
                    else
                    {
                        rpta = NPresentacion.Editar(Convert.ToInt32(txtIdpresentacion.Text),
                            txtNombre.Text.Trim().ToUpper());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (Isnuevo)
                        {
                            MensajeOK("Se insertó correctamente el registro");
                        }
                        else
                        {
                            MensajeOK("Se actualizó correctamente el registro");
                        }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }

                    Isnuevo = false;
                    Iseditar = false;
                    Botones();
                    Limpiar();
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdpresentacion.Text.Equals(""))
            {
                Iseditar = true;
                Botones();
                Habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Isnuevo = false;
            Iseditar = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !(chkEliminar.Value != null && (bool)chkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdpresentacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Id"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            dataListado.Columns[0].Visible = chkEliminar.Checked;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Está seguro de eliminar los registros?",
                    "Pedidos App", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    int codigo;
                    string rpta = "";
                    bool algunoEliminado = false;

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (row.Cells["Eliminar"].Value != null &&
                            Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells["Id"].Value);
                            rpta = NPresentacion.Eliminar(codigo);

                            if (rpta == "OK")
                            {
                                algunoEliminado = true;
                            }
                            else
                            {
                                MensajeError(rpta);
                            }
                        }
                    }

                    if (algunoEliminado)
                        MensajeOK("Se eliminaron correctamente los registros");
                    else
                        MensajeError("No se seleccionó ningún registro para eliminar");

                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Agrega lógica de impresión si aplica
        }
    }
}
