namespace Biblioteca
{
    partial class Factura
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
            this.EntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetMaster = new Biblioteca.DataSetMaster();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EntregaTableAdapter = new Biblioteca.DataSetMasterTableAdapters.EntregaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EntregaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // EntregaBindingSource
            // 
            this.EntregaBindingSource.DataMember = "Entrega";
            this.EntregaBindingSource.DataSource = this.DataSetMaster;
            // 
            // DataSetMaster
            // 
            this.DataSetMaster.DataSetName = "DataSetMaster";
            this.DataSetMaster.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.EntregaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Biblioteca.rptFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(939, 454);
            this.reportViewer1.TabIndex = 0;
            // 
            // EntregaTableAdapter
            // 
            this.EntregaTableAdapter.ClearBeforeFill = true;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 454);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Factura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EntregaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EntregaBindingSource;
        private DataSetMaster DataSetMaster;
        private DataSetMasterTableAdapters.EntregaTableAdapter EntregaTableAdapter;
    }
}