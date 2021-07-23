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
    public partial class Autores : Form
    {
        public Autores()
        {
            InitializeComponent();
        }
        ClsConexion con = new ClsConexion();
        private void Autores_Load(object sender, EventArgs e)
        {
            con.loadAutor(dtgautores);
        }
        public void clearForm()
        {
            txtautor.Clear();
            txtapellido.Clear();
            txtedad.Clear();
            txtautorcod.Clear();
            btnGuardar.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }


        private void dtgautores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtautor.Text = dtgautores.CurrentRow.Cells[1].Value.ToString();
            txtapellido.Text = dtgautores.CurrentRow.Cells[2].Value.ToString();
            txtedad.Text = dtgautores.CurrentRow.Cells[3].Value.ToString();
            txtautorcod.Text = dtgautores.CurrentRow.Cells[0].Value.ToString();
            btnGuardar.Enabled = false;
            btnedit.Enabled = true;
            btndelete.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            con.InsertarAutor(txtautor.Text, txtapellido.Text,txtedad.Text);
            con.loadAutor(dtgautores);
            clearForm();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            con.EditarAutor(txtautor.Text, txtapellido.Text, txtedad.Text,txtautorcod.Text);
            con.loadAutor(dtgautores);
            clearForm();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            con.EliminarAutor( txtautorcod.Text);
            con.loadAutor(dtgautores);
            clearForm();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
