using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class ReporteLibro : Form
    {
        public ReporteLibro()
        {
            InitializeComponent();
        }

        private void ReporteLibro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetMaster.Libro' table. You can move, or remove it, as needed.
            this.LibroTableAdapter.Fill(this.DataSetMaster.Libro);

            this.reportViewer1.RefreshReport();
        }
    }
}
