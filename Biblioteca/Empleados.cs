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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
            cmbocupacion.SelectedIndex = 0;
        }
        ClsConexion con = new ClsConexion();
        ClsEmpleado emp = new ClsEmpleado();
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCaracteres(txtnombre.Text))
            {
                MessageBox.Show("Nombre incorrecto, no debe contener numeros");
            }
            else if (!ValidarCaracteres(txtapellido.Text))
            {
                MessageBox.Show("Apellido incorrecto, no debe contener numeros");
            }
            else if (!ValidarEmail(txtemail.Text))
            {
                MessageBox.Show("Fomrato de correo invalido");
            }
            else if (!ValidarNumeros(txttelefono.Text))
            {
                MessageBox.Show("Formato de telefono invalido");
            }
            else {

             
                emp.Nombre = txtnombre.Text;
                emp.Apellido = txtapellido.Text;
                emp.Edad = npedad.Value.ToString();
                emp.Telefono = txttelefono.Text;
                emp.Email = txtemail.Text;
                emp.Ocupacion = Convert.ToString(cmbocupacion.SelectedIndex + 1);

                con.InsertarEmpleado(
                    emp.Nombre,emp.Apellido
                    ,emp.Edad,emp.Email,
                    emp.Telefono,
                    emp.Ocupacion
                    );
                con.loadEmpleados(dtgempleado);
            }
            
        }
        public static bool ValidarCaracteres(string cadena)
        {
            return cadena != null && Regex.IsMatch(cadena, @"^[a-zA-Z]+$");
        }
        public static bool ValidarNumeros(string cadena)
        {
            return cadena != null && Regex.IsMatch(cadena, "[0-9]");
        }
        public static bool ValidarEmail(string email)
        {
            return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
        }

        private void txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtnombre_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            con.loadEmpleados(dtgempleado);
        }

        private void dtgempleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void FormActive() {
            btnguardar.Enabled = true;
            btneliminar.Enabled = false;
            btnmodificar.Enabled = false;
            btncancel.Enabled = false;

        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (!ValidarCaracteres(txtnombre.Text))
            {
                MessageBox.Show("Nombre incorrecto, no debe contener numeros");
            }
            else if (!ValidarCaracteres(txtapellido.Text))
            {
                MessageBox.Show("Apellido incorrecto, no debe contener numeros");
            }
            else if (!ValidarEmail(txtemail.Text))
            {
                MessageBox.Show("Fomrato de correo invalido");
            }
            else if (!ValidarNumeros(txttelefono.Text))
            {
                MessageBox.Show("Formato de telefono invalido");
            }
            else
            {


                emp.Nombre = txtnombre.Text;
                emp.Apellido = txtapellido.Text;
                emp.Edad = npedad.Value.ToString();
                emp.Telefono = txttelefono.Text;
                emp.Email = txtemail.Text;
                emp.Ocupacion = Convert.ToString(cmbocupacion.SelectedIndex + 1);

                con.EditarEmpleado(
                       emp.Nombre, emp.Apellido
                       , emp.Edad, emp.Email,
                       emp.Telefono,
                       emp.Ocupacion
                       );
                con.loadEmpleados(dtgempleado);
                FormActive();
            }
            
        }

        private void dtgempleado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnguardar.Enabled = false;
            btneliminar.Enabled = true;
            btnmodificar.Enabled = true;
            btncancel.Enabled = true;
            con.CodEmpleado = dtgempleado.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dtgempleado.CurrentRow.Cells[1].Value.ToString();
            txtapellido.Text = dtgempleado.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = dtgempleado.CurrentRow.Cells[4].Value.ToString();
            txttelefono.Text = dtgempleado.CurrentRow.Cells[5].Value.ToString();
            npedad.Value = Convert.ToInt16(dtgempleado.CurrentRow.Cells[3].Value.ToString());
            cmbocupacion.SelectedIndex = Convert.ToInt16(dtgempleado.CurrentRow.Cells[6].Value.ToString());
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            con.EliminarEmpleado();
            con.loadEmpleados(dtgempleado);
            FormActive();
        }

        private void btneliminartodo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Seguro que quiere salir eliminar todos los registros?", "Consulta", 
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                con.EliminarEmpleados();
                con.loadEmpleados(dtgempleado);

            }
       }

        private void btncancel_Click(object sender, EventArgs e)
        {

            txtnombre.Text = "";
            txtapellido.Text = "";
            txtemail.Text = "";
            txttelefono.Text = "";
            npedad.Value = 1;
            cmbocupacion.SelectedIndex = 0;

            FormActive();

        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
     if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
    }
}
