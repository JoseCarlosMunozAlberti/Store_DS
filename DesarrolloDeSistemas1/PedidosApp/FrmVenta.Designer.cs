// FrmVenta.Designer.cs actualizado con chkEliminar
namespace PedidosApp
{
    partial class FrmVenta
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cbTrabajador;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private void InitializeComponent()
        {
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cbTrabajador = new System.Windows.Forms.ComboBox();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();

            // tabPage1 - Listado
            this.label1.Text = "Listado de Ventas";
            this.label1.Location = new System.Drawing.Point(30, 20);

            this.txtBuscar.Location = new System.Drawing.Point(150, 20);
            this.txtBuscar.Size = new System.Drawing.Size(200, 22);

            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(370, 20);
            this.btnBuscar.Size = new System.Drawing.Size(80, 25);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(460, 20);
            this.btnEliminar.Size = new System.Drawing.Size(80, 25);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Location = new System.Drawing.Point(550, 20);
            this.btnActualizar.Size = new System.Drawing.Size(90, 25);
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.Location = new System.Drawing.Point(650, 20);
            this.chkEliminar.CheckedChanged += new System.EventHandler(this.chkEliminar_CheckedChanged);

            this.lblTotal.Location = new System.Drawing.Point(30, 50);

            this.dataListado.Location = new System.Drawing.Point(30, 80);
            this.dataListado.Size = new System.Drawing.Size(700, 300);
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.MultiSelect = false;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);

            this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label1, this.txtBuscar, this.btnBuscar, this.btnEliminar, this.btnActualizar, this.chkEliminar,
                this.lblTotal, this.dataListado });

            // tabPage2 - Mantenimiento
            this.label2.Text = "Cliente:";
            this.label2.Location = new System.Drawing.Point(30, 30);

            this.txtIdCliente.Location = new System.Drawing.Point(150, 30);
            this.txtIdCliente.Size = new System.Drawing.Size(50, 22);
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.ForeColor = System.Drawing.Color.Black;

            this.txtCliente.Location = new System.Drawing.Point(210, 30);
            this.txtCliente.Size = new System.Drawing.Size(200, 22);
            this.txtCliente.ReadOnly = true;
            this.txtCliente.ForeColor = System.Drawing.Color.Black;

            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.Location = new System.Drawing.Point(420, 28);
            this.btnBuscarCliente.Size = new System.Drawing.Size(120, 25);
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);

            this.label3.Text = "Trabajador:";
            this.label3.Location = new System.Drawing.Point(30, 80);

            this.cbTrabajador.Location = new System.Drawing.Point(150, 80);
            this.cbTrabajador.Width = 200;

            this.label4.Text = "Fecha Venta:";
            this.label4.Location = new System.Drawing.Point(30, 130);

            this.dtpFechaVenta.Location = new System.Drawing.Point(150, 130);

            this.label5.Text = "Nro Factura:";
            this.label5.Location = new System.Drawing.Point(30, 180);

            this.txtNroFactura.Location = new System.Drawing.Point(150, 180);
            this.txtNroFactura.Width = 200;

            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(30, 230);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(130, 230);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(230, 230);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label2, this.txtIdCliente, this.txtCliente, this.btnBuscarCliente,
                this.label3, this.cbTrabajador, this.label4, this.dtpFechaVenta,
                this.label5, this.txtNroFactura, this.btnNuevo, this.btnGuardar, this.btnCancelar });

            // tabControl
            this.tabPage1.Text = "Listado";
            this.tabPage2.Text = "Mantenimiento";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;

            // FrmVenta
            this.Controls.Add(this.tabControl1);
            this.Text = "Registro de Ventas";
            this.Load += new System.EventHandler(this.FrmVenta_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
