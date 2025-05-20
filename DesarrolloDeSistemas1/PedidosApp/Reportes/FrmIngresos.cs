using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp.Reportes
{
    public partial class FrmIngresos : Form
    {
        public FrmIngresos()
        {
            InitializeComponent();
        }

        private void FrmIngresos_Load(object sender, EventArgs e)
        {
            try 
            { 
                // Cargar los datos del reporte pasando null para todos los parámetros
                // Esto mostrará todos los ingresos sin filtros
                this.sp_reporte_ingresosTableAdapter.Fill(
                    this.dsPrincipal.sp_reporte_ingresos,
                    null,  // IdIngreso
                    null,  // FechaInicio
                    null   // FechaFin
                );
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
