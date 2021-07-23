using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class clsCalculos:clsFormulas
    {


        public override int diasMora(DateTime val1, DateTime val2)
        {
            TimeSpan difFechas = val1 - val2;
            int dias = difFechas.Days;

            if (dias < 0) {
                dias = 0;
            }
            return dias;
        }
        public override double Subtotal(int dias)
        {
            double subtotal = 0.00;
            if (dias == 0)
            {
                subtotal = 20;
            }
            else {
                subtotal = 20;
                for (int i=0; i<dias; i++) {

                    subtotal = (subtotal * 0.20) + subtotal;
                }

            }


            return subtotal;
        }
        //
        public override double Descuento(int edad,double subtotal)
        {
            double desc = 0.00;
            if (edad >= 60) {
                desc = subtotal * 0.25;

            }

            return desc;
        }
        //
        public override double Impuesto(double subtotal)
        {
            double imp = subtotal*0.15;

            return imp ;
        }
        //
        public override double Total(double subt, double desc, double imp)
        {
            double total = (subt - desc) + imp;
            return total;
        }
    }
}
