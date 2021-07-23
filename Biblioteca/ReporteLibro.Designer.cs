namespace Biblioteca
{
    partial class ReporteLibro
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetMaster = new Biblioteca.DataSetMaster();
            this.LibroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LibroTableAdapter = new Biblioteca.DataSetMasterTableAdapters.LibroTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LibroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LibroBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Biblioteca.rptLibros.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(827, 362);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetMaster
            // 
            this.DataSetMaster.DataSetName = "DataSetMaster";
            this.DataSetMaster.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LibroBindingSource
            // 
            this.LibroBindingSource.DataMember = "Libro";
            this.LibroBindingSource.DataSource = this.DataSetMaster;
            // 
            // LibroTableAdapter
            // 
            this.LibroTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 362);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteLibro";
            this.Text = "ReporteLibro";
            this.Load += new System.EventHandler(this.ReporteLibro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LibroBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource LibroBindingSource;
        private DataSetMaster DataSetMaster;
        private DataSetMasterTableAdapters.LibroTableAdapter LibroTableAdapter;
    }
}