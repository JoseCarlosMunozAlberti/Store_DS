namespace PedidosApp.Reportes
{
    partial class FrmIngresos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spreporteingresosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new PedidosApp.dsPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spreporteingresosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_reporte_ingresosTableAdapter = new PedidosApp.dsPrincipalTableAdapters.sp_reporte_ingresosTableAdapter();
            this.spreporteingresosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // spreporteingresosBindingSource1
            // 
            this.spreporteingresosBindingSource1.DataMember = "sp_reporte_ingresos";
            this.spreporteingresosBindingSource1.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsreporte_ingresos";
            reportDataSource1.Value = this.spreporteingresosBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidosApp.Reportes.rptIngresos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(19, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // spreporteingresosBindingSource
            // 
            this.spreporteingresosBindingSource.DataMember = "sp_reporte_ingresos";
            this.spreporteingresosBindingSource.DataSource = this.dsPrincipal;
            // 
            // sp_reporte_ingresosTableAdapter
            // 
            this.sp_reporte_ingresosTableAdapter.ClearBeforeFill = true;
            // 
            // spreporteingresosBindingSource2
            // 
            this.spreporteingresosBindingSource2.DataMember = "sp_reporte_ingresos";
            this.spreporteingresosBindingSource2.DataSource = this.dsPrincipal;
            // 
            // FrmIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmIngresos";
            this.Text = "FrmIngresos";
            this.Load += new System.EventHandler(this.FrmIngresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private dsPrincipal dsPrincipal;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spreporteingresosBindingSource;
        private dsPrincipalTableAdapters.sp_reporte_ingresosTableAdapter sp_reporte_ingresosTableAdapter;
        private System.Windows.Forms.BindingSource spreporteingresosBindingSource1;
        private System.Windows.Forms.BindingSource spreporteingresosBindingSource2;
    }
}