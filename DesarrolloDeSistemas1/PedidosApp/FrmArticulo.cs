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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PedidosApp
{
    public partial class FrmArticulo : Form
    {
        private bool Isnuevo = false;
        private bool Iseditar = false;
        private static FrmArticulo _Instancia;
        public static FrmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmArticulo();
            }
            return _Instancia;
        }
        public void setCategoria(string idcategoria, string nombre)
        {
            txtIdcategoria.Text = idcategoria;
            txtCategoria.Text = nombre;
        }
        public FrmArticulo()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre del articulo");
            ttMensaje.SetToolTip(pxImagen, "Agregue la imagen del articulo");
            ttMensaje.SetToolTip(txtCategoria, "Agregue la categoria del articulo");
            ttMensaje.SetToolTip(txtNombre, "Seleccione la presentacion del articulo");

            txtIdcategoria.Visible = false;
            txtCategoria.ReadOnly = true;
            LlenarComboPresentacion();
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
            txtIdarticulo.Text =string.Empty;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtIdcategoria.Text= string.Empty;
            txtCategoria.Text= string.Empty;
            pxImagen.Image = global::PedidosApp.Properties.Resources.images;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            txtIdarticulo.ReadOnly = !valor;
            txtCodigo.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            btnBuscarCategoria.Enabled = valor;
            cbIdpresentacion.Enabled = valor;
            btnCargar.Enabled = valor;
            btnLimpiar.Enabled = valor;
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
            if(dataListado.RowCount > 0) {
                dataListado.Columns[0].Visible = false;
                dataListado.Columns[1].Visible = false;
                dataListado.Columns[4].Visible = false;
                dataListado.Columns[5].Visible = false;
            }
            chkEliminar.Checked = false;
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NArticulo.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Registros encontrados : " + Convert.ToString(dataListado.Rows.Count);
            tabControl1.SelectedIndex = 0;
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = NArticulo.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Registros encontrados : " + Convert.ToString(dataListado.Rows.Count);

        }
        //Poblar la lista de presentaciones
        private void LlenarComboPresentacion()
        {
            cbIdpresentacion.DataSource = NPresentacion.Mostrar();
            cbIdpresentacion.ValueMember = "id";
            cbIdpresentacion.DisplayMember = "nombre";
        }
        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pxImagen.Image = global::PedidosApp.Properties.Resources.imagen_vacia;
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
            Iseditar= false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtCodigo.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = string.Empty;
                if(txtCodigo.Text == string.Empty || txtNombre.Text == string.Empty
                    || txtCategoria.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtCodigo, "Ingrese codigo de barra");
                    errorIcono.SetError(txtNombre, "Ingrese nombre del articulo");
                    errorIcono.SetError(txtCategoria, "Seleccione una categoria");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();
                    if (Isnuevo)
                    {
                        rpta = NArticulo.Insertar(txtCodigo.Text, txtNombre.Text.Trim().ToUpper(),
                            imagen, Convert.ToInt32(txtIdcategoria.Text),
                            Convert.ToInt32(cbIdpresentacion.SelectedValue));
                    }
                    else 
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(txtIdarticulo.Text), 
                            txtCodigo.Text, txtNombre.Text.Trim().ToUpper(),
                            imagen, Convert.ToInt32(txtIdcategoria.Text),
                            Convert.ToInt32(cbIdpresentacion.SelectedValue));
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
            if (!txtIdarticulo.Text.Equals(""))
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
            txtIdarticulo.Text = Convert.ToString(dataListado.CurrentRow.Cells["id"].Value);
            txtCodigo.Text = Convert.ToString(dataListado.CurrentRow.Cells["codigo"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);

            byte[] imagenBuffer = (byte[])dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            pxImagen.Image = Image.FromStream(ms);
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            txtIdcategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["categoria"].Value);
            cbIdpresentacion.SelectedValue = Convert.ToString(dataListado.CurrentRow.Cells["idpresentacion"].Value);
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
                    "Pedidos App",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int codigo;
                    string rpta = string.Empty;
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            rpta = NArticulo.Eliminar(codigo);
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
        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmVistaCategoria_Articulo form = new FrmVistaCategoria_Articulo();
            form.ShowDialog();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FrmStockArticulos frm = new Reportes.FrmStockArticulos();
            frm.ShowDialog();
        }
        private void FrmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
