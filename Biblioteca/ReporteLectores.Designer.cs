namespace Biblioteca
{
    partial class ReporteLectores
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
            this.LectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LectorTableAdapter = new Biblioteca.DataSetMasterTableAdapters.LectorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LectorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LectorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Biblioteca.rptLectores.rdlc";
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
            // LectorBindingSource
            // 
            this.LectorBindingSource.DataMember = "Lector";
            this.LectorBindingSource.DataSource = this.DataSetMaster;
            // 
            // LectorTableAdapter
            // 
            this.LectorTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteLectores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 362);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteLectores";
            this.Text = "ReporteLectores";
            this.Load += new System.EventHandler(this.ReporteLectores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LectorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource LectorBindingSource;
        private DataSetMaster DataSetMaster;
        private DataSetMasterTableAdapters.LectorTableAdapter LectorTableAdapter;
    }
}