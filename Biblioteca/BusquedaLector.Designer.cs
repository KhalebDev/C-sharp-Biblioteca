namespace Biblioteca
{
    partial class BusquedaLector
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
            this.dtglector = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtglector)).BeginInit();
            this.SuspendLayout();
            // 
            // dtglector
            // 
            this.dtglector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtglector.Location = new System.Drawing.Point(12, 50);
            this.dtglector.Name = "dtglector";
            this.dtglector.Size = new System.Drawing.Size(765, 199);
            this.dtglector.TabIndex = 0;
            this.dtglector.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtglector_CellContentDoubleClick);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(339, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BusquedaLector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 312);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtglector);
            this.Name = "BusquedaLector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BusquedaLector";
            this.Load += new System.EventHandler(this.BusquedaLector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtglector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtglector;
        private System.Windows.Forms.Button button1;
    }
}