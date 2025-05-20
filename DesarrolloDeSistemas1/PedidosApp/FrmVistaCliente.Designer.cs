// FrmVistaCliente.Designer.cs
namespace PedidosApp
{
    partial class FrmVistaCliente
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataListado;

        private void InitializeComponent()
        {
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.Text = "Buscar:";
            this.label1.Location = new System.Drawing.Point(30, 20);

            // txtBuscar
            this.txtBuscar.Location = new System.Drawing.Point(100, 20);
            this.txtBuscar.Width = 300;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // lblTotal
            this.lblTotal.Location = new System.Drawing.Point(30, 60);

            // dataListado
            this.dataListado.Location = new System.Drawing.Point(30, 90);
            this.dataListado.Size = new System.Drawing.Size(700, 300);
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.MultiSelect = false;
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);

            // FrmVistaCliente
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataListado);
            this.Text = "Seleccionar Cliente";
            this.Load += new System.EventHandler(this.FrmVistaCliente_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
