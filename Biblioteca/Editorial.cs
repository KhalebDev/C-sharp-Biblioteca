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
    public partial class Editorial : Form
    {
        public Editorial()
        {
            InitializeComponent();
        }
        ClsConexion con = new ClsConexion();
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Trim() != "" && txtpais.Text.Trim() != "")
            {
                con.InsertarEditorial(txtnombre.Text,txtpais.Text);
                con.loadEditorial(dtgeditorial);
                clearForm();
            }
            else {
                MessageBox.Show("Hay campos vacios");
            }
        }

        private void Editorial_Load(object sender, EventArgs e)
        {
            con.loadEditorial(dtgeditorial);
        }
        public void clearForm()
        {
            txtcodeditorial.Clear();
            txtnombre.Clear();
            txtpais.Clear();
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
        }

        private void dtgeditorial_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodeditorial.Text = dtgeditorial.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dtgeditorial.CurrentRow.Cells[1].Value.ToString();
            txtpais.Text = dtgeditorial.CurrentRow.Cells[2].Value.ToString();
            btnguardar.Enabled = false;
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            con.EditarEditorial(txtnombre.Text, txtpais.Text,txtcodeditorial.Text);
            con.loadEditorial(dtgeditorial);
            clearForm();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            con.EliminarEditorial(txtcodeditorial.Text);
            con.loadEditorial(dtgeditorial);
            clearForm();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            clearForm();
            
        }
    }
}
