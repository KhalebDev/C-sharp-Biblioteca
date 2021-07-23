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
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetMaster.Entrega' table. You can move, or remove it, as needed.
            this.EntregaTableAdapter.Fill(this.DataSetMaster.Entrega);

            this.reportViewer1.RefreshReport();
        }
    }
}
