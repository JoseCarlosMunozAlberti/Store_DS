// FrmVistaCliente.cs
using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmVistaCliente : Form
    {
        public FrmVistaCliente()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            this.OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false; // Ocultar ID si quieres
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCliente.BuscarNombre(this.txtBuscar.Text);
            this.lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaCliente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta frm = FrmVenta.GetInstancia();

            string idCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
            string nombreCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["nombres"].Value) + " " + Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);

            frm.SetCliente(idCliente, nombreCliente);
            this.Hide();
        }
    }
}
