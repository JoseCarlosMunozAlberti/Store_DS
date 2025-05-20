// FrmCliente.Designer.cs - Actualizado con eventos conectados
namespace PedidosApp
{
    partial class FrmCliente
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtIdcliente;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.ErrorProvider errorIcono;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtIdcliente = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();

            // Setup de controles
            this.txtBuscar.Location = new System.Drawing.Point(120, 20);
            this.label1.Text = "Buscar:";
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.lblTotal.Location = new System.Drawing.Point(30, 60);
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.Location = new System.Drawing.Point(30, 90);

            this.dataListado.Location = new System.Drawing.Point(30, 120);
            this.dataListado.Size = new System.Drawing.Size(700, 250);
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.MultiSelect = false;

            this.btnBuscar.Text = "Buscar";
            this.btnEliminar.Text = "Eliminar";
            this.btnBuscar.Location = new System.Drawing.Point(450, 20);
            this.btnEliminar.Location = new System.Drawing.Point(550, 20);

            this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtBuscar, this.label1, this.lblTotal,
                this.chkEliminar, this.dataListado,
                this.btnBuscar, this.btnEliminar });

            this.txtNombres.Location = new System.Drawing.Point(150, 40);
            this.txtApellidos.Location = new System.Drawing.Point(150, 80);
            this.dtpFechaNac.Location = new System.Drawing.Point(150, 120);
            this.txtEmail.Location = new System.Drawing.Point(150, 160);

            this.label2.Text = "Nombres:";
            this.label3.Text = "Apellidos:";
            this.label4.Text = "Fecha Nac:";
            this.label5.Text = "Email:";

            this.label2.Location = new System.Drawing.Point(30, 40);
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label4.Location = new System.Drawing.Point(30, 120);
            this.label5.Location = new System.Drawing.Point(30, 160);

            this.btnNuevo.Text = "Nuevo";
            this.btnGuardar.Text = "Guardar";
            this.btnEditar.Text = "Editar";
            this.btnCancelar.Text = "Cancelar";

            this.btnNuevo.Location = new System.Drawing.Point(30, 220);
            this.btnGuardar.Location = new System.Drawing.Point(130, 220);
            this.btnEditar.Location = new System.Drawing.Point(230, 220);
            this.btnCancelar.Location = new System.Drawing.Point(330, 220);

            // Asociar eventos a botones
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnBuscar.Click += new System.EventHandler(this.txtBuscar_TextChanged);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);

            this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtIdcliente, this.txtNombres, this.txtApellidos,
                this.dtpFechaNac, this.txtEmail,
                this.label2, this.label3, this.label4, this.label5,
                this.btnNuevo, this.btnGuardar, this.btnEditar, this.btnCancelar });

            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabPage1.Text = "Listado";
            this.tabPage2.Text = "Mantenimiento";
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(this.tabControl1);
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmCliente_Load);

            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
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