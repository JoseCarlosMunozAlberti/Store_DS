namespace PedidosApp.Reportes
{
    partial class FrmStockArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spstockarticulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new PedidosApp.dsPrincipal();
            this.spstock_articulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spstock_articulosTableAdapter = new PedidosApp.dsPrincipalTableAdapters.spstock_articulosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spstockarticulosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spstock_articulosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            reportDataSource2.Name = "dsstock_articulos";
            reportDataSource2.Value = this.spstockarticulosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidosApp.Reportes.rptStockArticulos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(788, 438);
            this.reportViewer1.TabIndex = 0;
            // 
            // spstockarticulosBindingSource
            // 
            this.spstockarticulosBindingSource.DataMember = "spstock_articulos";
            this.spstockarticulosBindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spstock_articulosBindingSource
            // 
            this.spstock_articulosBindingSource.DataMember = "spstock_articulos";
            this.spstock_articulosBindingSource.DataSource = this.dsPrincipal;
            // 
            // spstock_articulosTableAdapter
            // 
            this.spstock_articulosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmStockArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmStockArticulos";
            this.Text = "FrmStockArticulos";
            this.Load += new System.EventHandler(this.FrmStockArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spstockarticulosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spstock_articulosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private dsPrincipal dsPrincipal;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spstock_articulosBindingSource;
        private System.Windows.Forms.BindingSource spstockarticulosBindingSource;
        private dsPrincipalTableAdapters.spstock_articulosTableAdapter spstock_articulosTableAdapter;
    }
}