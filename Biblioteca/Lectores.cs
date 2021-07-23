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
    public partial class Lectores : Form
    {
        public Lectores()
        {
            InitializeComponent();
        }
        ClsValidaciones val = new ClsValidaciones();
        ClsConexion con = new ClsConexion();
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (!val.ValidarCaracteres(txtnombre.Text))
            {
                MessageBox.Show("Nombre invalido");
            }
            else if (!val.ValidarCaracteres(txtapellido.Text))
            {
                MessageBox.Show("Apellido invalido");
            }
            else if (!val.ValidarEmail(txtemail.Text))
            {
                MessageBox.Show("Formato Email invalido");
            }
            else if (!val.ValidarNumeros(txttelefono.Text))
            {
                MessageBox.Show("Formato Telefono invalido");
            }
            else if (txtdirec.Text.Length < 10)
            {
                MessageBox.Show("Direccion invalida");
            }
            else {
                con.InsertarLector(
                        txtnombre.Text,
                        txtapellido.Text,
                        npedad.Value.ToString(),
                        txtemail.Text,
                        txttelefono.Text,
                        txtdirec.Text
                    );
                con.loadLector(dtglectores);
                clearForm();
            }
        }
        public void clearForm() {
            txtnombre.Clear();
            txtapellido.Clear();
            txtemail.Clear();
            txtdirec.Clear();
            txttelefono.Clear();
            btnagregar.Enabled = true;
            btneliminar.Enabled = false;
            btnmodificar.Enabled = false;

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (!val.ValidarCaracteres(txtnombre.Text))
            {
                MessageBox.Show("Nombre invalido");
            }
            else if (!val.ValidarCaracteres(txtapellido.Text))
            {
                MessageBox.Show("Apellido invalido");
            }
            else if (!val.ValidarEmail(txtemail.Text))
            {
                MessageBox.Show("Formato Email invalido");
            }
            else if (!val.ValidarNumeros(txttelefono.Text))
            {
                MessageBox.Show("Formato Telefono invalido");
            }
            else if (txtdirec.Text.Length < 10)
            {
                MessageBox.Show("Direccion invalida");
            }
            else
            {
                con.EditarLector(
                        txtnombre.Text,
                        txtapellido.Text,
                        npedad.Value.ToString(),
                        txtemail.Text,
                        txttelefono.Text,
                        txtdirec.Text
                    );
                con.loadLector(dtglectores);
                clearForm();
            }
        }

        private void Lectores_Load(object sender, EventArgs e)
        {
            con.loadLector(dtglectores);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            con.EliminarLector();
            con.loadLector(dtglectores);
            clearForm();
        }

        private void dtglectores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnagregar.Enabled = false;
            btneliminar.Enabled = true;
            btnmodificar.Enabled = true;
            btncancel.Enabled = true;
            ClsConexion.codLector = dtglectores.CurrentRow.Cells[0].Value.ToString();

            txtnombre.Text = dtglectores.CurrentRow.Cells[1].Value.ToString();
            txtapellido.Text = dtglectores.CurrentRow.Cells[2].Value.ToString();
            npedad.Value = Convert.ToInt16(dtglectores.CurrentRow.Cells[3].Value.ToString());
            txtemail.Text = dtglectores.CurrentRow.Cells[4].Value.ToString();
            txttelefono.Text = dtglectores.CurrentRow.Cells[5].Value.ToString();
            txtdirec.Text = dtglectores.CurrentRow.Cells[6].Value.ToString();
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
