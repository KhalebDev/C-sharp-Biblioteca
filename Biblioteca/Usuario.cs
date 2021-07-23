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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        ClsValidaciones val = new ClsValidaciones();
        ClsConexion con = new ClsConexion();
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtclave.Text.Trim().Length < 8)
            {
                MessageBox.Show("Clave invalida, minimo 8 caracteres");
            }
            else {
                con.InsertarUsuario(txtverificar.Text, Convert.ToString(cmbcategoria.SelectedIndex + 1), txtclave.Text);
                con.loadUsuarios(dtgusuario);
                ClearForm();
            }
        }

        private void btnverificar_Click(object sender, EventArgs e)
        {
            if (!val.ValidarEmail(txtverificar.Text))
            {
                MessageBox.Show("formato de correo invalido");
            }
            else {
                if (con.VerificarUsuario(txtverificar.Text) == 0)
                {
                    MessageBox.Show("No se encontro ningun empleado vinculado a este correo");
                   
                    
                }
                else if (con.VerificarUsuario(txtverificar.Text) == 2)
                {
                    MessageBox.Show("El empleado ya cuenta con un usuario");
                    btnmodificar.Enabled = true;
                    btnCancel.Enabled = true;
                    btneliminar.Enabled = true;
                    txtclave.Enabled = true;
                    cmbcategoria.Enabled = true;
                    //
                    txtverificar.Enabled = false;
                    btnverificar.Enabled = false;
                  
                }
                else if (con.VerificarUsuario(txtverificar.Text) == 3)
                {
                    MessageBox.Show("El empleado no cuenta con un usuario");
                    btnguardar.Enabled = true;
                    btnCancel.Enabled = true;
                    txtclave.Enabled = true;
                    cmbcategoria.Enabled = true;
                    ///
                    txtverificar.Enabled = false;
                    btnverificar.Enabled = false;

                }
                
              

            }
           
        }
        public void ClearForm() {
            txtverificar.Enabled = true;
            btnverificar.Enabled = true;
            ///
            txtclave.Text = "";
            txtverificar.Text = "";
            btnguardar.Enabled = false;
            btneliminar.Enabled = false;
            btnCancel.Enabled = false;
            btnmodificar.Enabled = false;
            txtclave.Enabled = false;
            cmbcategoria.Enabled = false;

        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            cmbcategoria.SelectedIndex = 0;
            con.loadUsuarios(dtgusuario);
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            con.EditarUsuario(txtverificar.Text, Convert.ToString(cmbcategoria.SelectedIndex + 1), txtclave.Text);
            con.loadUsuarios(dtgusuario);
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            con.EliminarUsuario(txtverificar.Text);
            ClearForm();
        }
    }
}
