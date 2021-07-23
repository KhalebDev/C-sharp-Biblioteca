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
    public partial class MenuGeneral : Form
    {
        public MenuGeneral()
        {
            InitializeComponent();
            hideSubMenu();
        }
        ClsEmpleado emp = new ClsEmpleado();
        private void MenuGeneral_Load(object sender, EventArgs e)
        {
            if (emp.CodAcceso == "1") {
                button1.Enabled = false;
                btnlibreria.Enabled = false;
            }

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
            pnlHijo.Controls.Add(childForm);// agregar al panel, el formulario hijo
            pnlHijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //oculta todos los paneles
        private void hideSubMenu()
        {
            pnlEmpleado.Visible = false;
            pnlLibreria.Visible = false;
            pnloperativo.Visible = false;

        }
        // verifica que el panel no este abierto ya, de no estarlo
        //veririfica que si existen paneles abiertos, los cierra y abre el panel que se envia como parametro
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlEmpleado);
        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Empleados());
           
        }

        private void btnlibreria_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlLibreria);
        }

        private void btnacciones_Click(object sender, EventArgs e)
        {
            showSubMenu(pnloperativo);
        }

        private void btnusuario_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Usuario());
         
        }

        private void btncategoria_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Categoria());
        }

        private void btneditorial_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Editorial());
        }

        private void btnlibro_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Libros());
        }

        private void btnlector_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Lectores());
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Prestamos());
        }

        private void btnEntregas_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Entregas());
        }

        private void btnAutor_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Autores());
        }

        private void btnreportes_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Reporteia());
        }
    }
}
