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
    public partial class BusquedaLector : Form
    {
        public BusquedaLector()
        {
            InitializeComponent();
        }
        ClsConexion con = new ClsConexion();
        private void BusquedaLector_Load(object sender, EventArgs e)
        {
            con.loadLector(dtglector);
        }

        private void dtglector_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            ClsLector lector = new ClsLector();
            lector.CodLector = dtglector.CurrentRow.Cells[0].Value.ToString();
            lector.Nombre = dtglector.CurrentRow.Cells[1].Value.ToString();
            //MessageBox.Show("el codigo es" + dtglector.CurrentRow.Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            this.Hide();
            
        }
       
    }
}
