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
    public partial class BusquedaLibro : Form
    {
        public BusquedaLibro()
        {
            InitializeComponent();
        }
        ClsConexion con = new ClsConexion();
        private void BusquedaLibro_Load(object sender, EventArgs e)
        {
            con.loadLibro(ftglibro);
        }

        private void ftglibro_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           Prestamos pres = new Prestamos();
           codLibro = ftglibro.CurrentRow.Cells[0].Value.ToString();
           nombreLibro= ftglibro.CurrentRow.Cells[1].Value.ToString();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        private static string codLibro = "";
        private static string nombreLibro = "";

        public  string CodLibro
        {
            get
            {
                return codLibro;
            }

            set
            {
                codLibro = value;
            }
        }

        public  string NombreLibro
        {
            get
            {
                return nombreLibro;
            }

            set
            {
                nombreLibro = value;
            }
        }
    }
}
