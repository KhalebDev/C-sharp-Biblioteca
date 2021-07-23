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
    public partial class ReporteLectores : Form
    {
        public ReporteLectores()
        {
            InitializeComponent();
        }

        private void ReporteLectores_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetMaster.Lector' table. You can move, or remove it, as needed.
            this.LectorTableAdapter.Fill(this.DataSetMaster.Lector);

            this.reportViewer1.RefreshReport();
        }
    }
}
