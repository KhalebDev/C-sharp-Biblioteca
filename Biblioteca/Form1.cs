using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ClsEmpleado emp = new ClsEmpleado();
        private void Form1_Load(object sender, EventArgs e)
        {
            pnllogin.BackColor = Color.FromArgb(75, Color.Gray);
        }

        private void btnacss_Click(object sender, EventArgs e)
        {
            //Trim, funcion para eliminar espacios en una cadena
            // ""
            if (txtuser.Text.Trim() != "" && txtpass.Text.Trim() != "")
            {

                if (ValidarEmail(txtuser.Text))
                {
                    ClsConexion con = new ClsConexion();
                    if (con.loggin(txtuser.Text, txtpass.Text))
                    {
                        emp.CodAcceso = con.privilegioUsuario(txtuser.Text).ToString();
                        MessageBox.Show("Bienvenido al sistema");
                        new MenuGeneral().Show();
                    }
                    else {
                        MessageBox.Show("Usuario o clave incorrectos");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Formato de correo invalido");
                }

            }
            else {
                MessageBox.Show("Hay campos vacios");
            }
            
        }
        public static bool ValidarEmail(string email)
        {
            return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtpass.Text;
            if (checkBox1.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
                txtpass.Text = text;

            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
                txtpass.Text = text;
            }
        }
    }
}
