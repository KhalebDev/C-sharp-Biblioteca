using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Entregas : Form
    {
        public Entregas()
        {
            InitializeComponent();
        }
        ClsConexion con = new ClsConexion();
        clsCalculos calc = new clsCalculos();
        ClsValidaciones val = new ClsValidaciones();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!val.ValidarNumeros(txtmonto.Text))
            {
                MessageBox.Show("El monto es un valor numerico");
            }
            else if (Convert.ToDouble(txtmonto.Text) < Convert.ToDouble(txtneto.Text))
            {
                MessageBox.Show("Monto insuficiente");
            }
            else {
                txtcambio.Text = (Convert.ToDouble(txtmonto.Text) - Convert.ToDouble(txtneto.Text)).ToString("N2");

                con.InsertarEntrega(
                    txtcodprestamo.Text,
                    txtnombre.Text,
                    txtLibro.Text,
                    txtdiasmora.Text,
                    txtsub.Text,
                    txtdesc.Text,
                    txtimp.Text,
                    txtneto.Text,
                    txtmonto.Text,
                    txtcambio.Text
                    );


                txtfacturar.Enabled = true;

            }
        }

        private void txtcodprestamo_TextChanged(object sender, EventArgs e)
        {
            clearForm();
            SqlConnection cond = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True");
            int cod = 0;
            try
            {

             
                
                cond.Open();
                string sql = "SELECT * FROM Prestamo WHERE idPrestamo =@cod";
                SqlCommand cmd = new SqlCommand(sql, cond);
                cmd.Parameters.AddWithValue("@cod", txtcodprestamo.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtnombre.Text =Convert.ToString(reader["fkLector"]);
                    txtLibro.Text = Convert.ToString(reader["fkLibro"]);
                    txtfprestamo.Value = Convert.ToDateTime(reader["FechaDevoluacion"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + ex, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cond.Close();
            
        }

        private void Entregas_Load(object sender, EventArgs e)
        {
            txtfentrega.Value = DateTime.Today;
        }

        private void txtcalcular_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "")
            {

                DateTime fechaUno = txtfprestamo.Value.Date;
                DateTime fechaDos = txtfentrega.Value.Date;

                txtdiasmora.Text = calc.diasMora(fechaDos, fechaUno).ToString();
                txtsub.Text = calc.Subtotal(calc.diasMora(fechaDos, fechaUno)).ToString();
                txtdesc.Text = calc.Descuento(con.edadLector(txtnombre.Text), Convert.ToDouble(txtsub.Text)).ToString();
                txtimp.Text = calc.Impuesto(Convert.ToDouble(txtsub.Text)).ToString();
                txtneto.Text = calc.Total(Convert.ToDouble(txtsub.Text),
                    Convert.ToDouble(txtdesc.Text),
                    Convert.ToDouble(txtimp.Text)).ToString();
                txtguardar.Enabled = true;
            }
            else {
                MessageBox.Show("Debes ingresar un codigo de prestamo");
            }

        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtlimpiar_Click(object sender, EventArgs e)
        {
            clearForm();

        }
        public void clearForm() {
            txtguardar.Enabled = false;
            txtfacturar.Enabled = false;
           // txtcodprestamo.Clear();
            txtnombre.Clear();
            txtLibro.Clear();
            txtfentrega.Value = DateTime.Today;
            txtfprestamo.Value = DateTime.Today;
            txtdiasmora.Clear();
            txtsub.Clear();
            txtdesc.Clear();
            txtimp.Clear();
            txtneto.Clear();
            txtmonto.Clear();
            txtcambio.Clear();

        }

        private void txtfacturar_Click(object sender, EventArgs e)
        {
            new Factura().Show();
            clearForm();
        }
    }
}
