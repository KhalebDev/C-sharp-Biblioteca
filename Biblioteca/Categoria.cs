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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        ClsValidaciones val = new ClsValidaciones();
        ClsConexion con = new ClsConexion();
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtcategdesc.Text.Trim() == "")
            {
                MessageBox.Show("El campo descripcion esta vacio");
            }
            else {
                if (!val.ValidarCaracteres(txtcategdesc.Text))
                {

                    MessageBox.Show("Error, no deben ingresarse numeros");
                }
                else {
                    con.InsertarCategoria(txtcategdesc.Text);
                    con.loadUCategoria(dtgcategoria);
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodcateg.Text = dtgcategoria.CurrentRow.Cells[0].Value.ToString();
            txtcategdesc.Text = dtgcategoria.CurrentRow.Cells[1].Value.ToString();
            btnguardar.Enabled = false;
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clearForm();

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            con.EditarCategoria(txtcategdesc.Text, txtcodcateg.Text);
            con.loadUCategoria(dtgcategoria);
            clearForm();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            con.EliminarCategoria(txtcodcateg.Text);
            con.loadUCategoria(dtgcategoria);
            clearForm();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            con.loadUCategoria(dtgcategoria);
        }
        public void clearForm() {
            txtcategdesc.Clear();
            txtcodcateg.Clear();
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
        }
    }
}
