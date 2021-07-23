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
    public partial class Reporteia : Form
    {
        public Reporteia()
        {
            InitializeComponent();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new ReporteLibro());
        }
        private Form activeForm = null;

        //childform, espera un parametro tipo formulario, para abrirlo en el panel 
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)// verifica que si se encuentra un formulario abierto y lo cierra
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHijo.Controls.Add(childForm);// agregar al panel, el formulario hijo
            panelHijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Reporteia_Load(object sender, EventArgs e)
        {

        }

        private void lectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new ReporteLectores());
        }
    }
}
