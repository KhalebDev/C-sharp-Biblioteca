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
    public partial class Libros : Form
    {
        public Libros()
        {
            InitializeComponent();
        }
        ClsConexion con = new ClsConexion();
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtitulo.Text != "") {

                con.InsertarLibro(
                    cmbautor.SelectedItem.ToString(),
                    cmbeditorial.SelectedItem.ToString(),
                    cmbeditorial.SelectedItem.ToString(),
                    cmbIdioma.SelectedItem.ToString(),
                    npPaginas.Value.ToString(),
                    dtppublicado.Value.ToShortDateString(),
                    txtitulo.Text
                    );
                con.loadLibro(dtglibros);
                clearForm();
            }

        }

        private void Libros_Load(object sender, EventArgs e)
        {
            con.loadLibro(dtglibros);
            con.loadCategoria(cmbcategoria);
            con.loadEditorial(cmbeditorial);
            con.loadAutor(cmbautor);

            ///
            cmbautor.SelectedIndex = 0;
            cmbcategoria.SelectedIndex = 0;
            cmbeditorial.SelectedIndex = 0;
            cmbIdioma.SelectedIndex = 0;
        }
        public void clearForm()
        {
            txtitulo.Clear();
            cmbautor.SelectedIndex = 0;
            cmbcategoria.SelectedIndex = 0;
            cmbeditorial.SelectedIndex = 0;
            cmbIdioma.SelectedIndex = 0;
            npPaginas.Value = 18;
            btnagregar.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            con.EditarLibro(
                    cmbautor.SelectedItem.ToString(),
                    cmbeditorial.SelectedItem.ToString(),
                    cmbeditorial.SelectedItem.ToString(),
                    cmbIdioma.SelectedItem.ToString(),
                    npPaginas.Value.ToString(),
                    dtppublicado.Value.ToShortDateString(),
                    txtitulo.Text
                    );
            con.loadLibro(dtglibros);
            clearForm();
        }

        private void dtglibros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnagregar.Enabled = false;
            btneliminar.Enabled = true;
            btnmodificar.Enabled = true;
           ClsConexion.CodLibro = dtglibros.CurrentRow.Cells[0].Value.ToString();
            txtitulo.Text = dtglibros.CurrentRow.Cells[1].Value.ToString();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            con.EliminarLibro();
            con.loadLibro(dtglibros);
            clearForm();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
