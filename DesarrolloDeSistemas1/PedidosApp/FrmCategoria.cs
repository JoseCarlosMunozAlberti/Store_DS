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
    public partial class FrmCategoria : Form
    {
        private bool Isnuevo = false;
        private bool Iseditar = false;
        public FrmCategoria()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre de la categoria");
            ttMensaje.SetToolTip(cboSubcategoria, "Seleccione una categoria");
            LlenarComboCategoria();
        }
        //Mostrar mensaje de confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Limpiar todos los controles el formulario
        private void Limpiar()
        {
            txtIdcategoria.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cboSubcategoria.SelectedIndex = -1;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            txtIdcategoria.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            cboSubcategoria.Enabled = valor;
        }
        //Habilitar los botones
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
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            if (dataListado.RowCount > 0)
            {
                dataListado.Columns[0].Visible = false;
                dataListado.Columns[1].Visible = false;
                dataListado.Columns[4].Visible = false;
            }
            chkEliminar.Checked = false;
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NCategoria.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Registros encontrados : " + Convert.ToString(dataListado.Rows.Count);
            tabControl1.SelectedIndex = 0;
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = NCategoria.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Registros encontrados : " + Convert.ToString(dataListado.Rows.Count);

        }
        //Poblar la lista de categorias
        private void LlenarComboCategoria()
        {
            cboSubcategoria.DataSource = NCategoria.Mostrar();
            cboSubcategoria.ValueMember = "id";
            cboSubcategoria.DisplayMember = "nombre";
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
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
                string rpta = string.Empty;
                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese nombre de la categoria");
                }
                else
                {
                    if (Isnuevo)
                    {
                        rpta = NCategoria.Insertar(txtNombre.Text.Trim().ToUpper(),
                            Convert.ToInt32(cboSubcategoria.SelectedValue));
                    }
                    else
                    {
                        rpta = NCategoria.Editar(Convert.ToInt32(txtIdcategoria.Text),
                            txtNombre.Text.Trim().ToUpper(),
                            Convert.ToInt32(cboSubcategoria.SelectedValue));
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (Isnuevo) { MensajeOK("Se inserto de forma correcta el registro"); }
                        else { MensajeOK("Se actualizo de forma correcta el registro"); }
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
            if (!txtIdcategoria.Text.Equals(""))
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
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdcategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["id"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            cboSubcategoria.SelectedValue = Convert.ToString(dataListado.CurrentRow.Cells["subcat"].Value);
            tabControl1.SelectedIndex = 1;
        }
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dataListado.Columns[0].Visible = true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Esta seguro de eliminar los registros?",
                    "Pedidos App", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int codigo;
                    string rpta = string.Empty;
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            rpta = NCategoria.Eliminar(codigo);
                            if (rpta.Equals("OK"))
                            {
                                MensajeOK("Se eliminaron correctamente los registros");
                            }
                            else { MensajeError(rpta); }
                        }
                    }
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Reportes.FrmCategorias frm = new Reportes.FrmCategorias();
            //frm.ShowDialog();
        }
    }
}
