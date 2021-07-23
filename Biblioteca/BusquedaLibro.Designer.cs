namespace Biblioteca
{
    partial class BusquedaLibro
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
            this.ftglibro = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ftglibro)).BeginInit();
            this.SuspendLayout();
            // 
            // ftglibro
            // 
            this.ftglibro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ftglibro.Location = new System.Drawing.Point(12, 37);
            this.ftglibro.Name = "ftglibro";
            this.ftglibro.Size = new System.Drawing.Size(843, 199);
            this.ftglibro.TabIndex = 1;
            this.ftglibro.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ftglibro_CellContentDoubleClick);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(370, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BusquedaLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 302);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ftglibro);
            this.Name = "BusquedaLibro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BusquedaLibro";
            this.Load += new System.EventHandler(this.BusquedaLibro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ftglibro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ftglibro;
        private System.Windows.Forms.Button button1;
    }
}