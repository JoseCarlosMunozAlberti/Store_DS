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

namespace PedidosApp.Reportes
{
    public partial class FrmStockArticulos : Form
    {
        public FrmStockArticulos()
        {
            InitializeComponent();
            this.Load += FrmStockArticulos_Load;
        }

        private void FrmStockArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                RefrescarReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefrescarReporte()
        {
            try
            {
                this.spstock_articulosTableAdapter.Fill(this.dsPrincipal.spstock_articulos);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
