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
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
        }
        ClsConexion con = new ClsConexion();
        private void button1_Click(object sender, EventArgs e)
        {
            ClsLector lectorr = new ClsLector();
            BusquedaLector lector = new BusquedaLector();
            if (lector.ShowDialog() == DialogResult.OK) {

                txtcodlector.Text = lectorr.CodLector;
                txtnombrelector.Text = lectorr.Nombre;
            }
        }

        private void btnlibro_Click(object sender, EventArgs e)
        {
           
            BusquedaLibro libro = new BusquedaLibro();
            if (libro.ShowDialog() == DialogResult.OK)
            {

                txtcodlibro.Text = libro.CodLibro;
                txttitulo.Text = libro.NombreLibro;
            }
        }

        private void Prestamos_Load(object sender, EventArgs e)
        {
            dtpentrega.Value= DateTime.Today.AddDays(4);
            txtcodprestamo.Text = Convert.ToString(con.CodUprestamo() + 1);
           
            con.loadPrestamo(dtgprestamo);
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtcodlector.Text != "" && txtcodlibro.Text != "") {

                con.InsertarPrestamo(txtnombrelector.Text,txttitulo.Text,dtpprestamo.Value.ToShortDateString(),
                    dtpentrega.Value.ToShortDateString());
                con.loadPrestamo(dtgprestamo);
                clearForm();
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (txtcodlector.Text != "" && txtcodlibro.Text != "")
            {

                con.EditarPrestamo(txtcodlector.Text, txtcodlibro.Text, dtpprestamo.Value.ToShortDateString(),
                    dtpentrega.Value.AddDays(4).ToShortDateString());
                con.loadPrestamo(dtgprestamo);
                clearForm();
            }
        }

        private void dtgprestamo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            btnagregar.Enabled = false;
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            ClsConexion.codPrestamo = dtgprestamo.CurrentRow.Cells[0].Value.ToString();
            txtnombrelector.Text= dtgprestamo.CurrentRow.Cells[1].Value.ToString();
            txttitulo.Text = dtgprestamo.CurrentRow.Cells[2].Value.ToString();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            con.EliminarPrestamo();
            con.loadPrestamo(dtgprestamo);
            clearForm(); ;
        }

        public void clearForm() {
            txtnombrelector.Clear();
            txttitulo.Clear();
            btnagregar.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btncancel_Click_1(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
