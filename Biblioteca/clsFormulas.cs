using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class clsFormulas
    {
        ///homonimia o sobre carga
        public void sumar() {

        }
        public void sumar(double val1, double val2)
        {

        }
        public virtual int diasMora()
        {

            return 0;
        }
        public virtual int diasMora(DateTime val1,DateTime val2)
        {

            return 0;
        }
        public virtual double Subtotal (int dias){

            return 0;
        }
        public virtual double Descuento()
        {

            return 0;
        }
        public virtual double Descuento(int edad,double subtotal)
        {

            return 0;
        }
        public virtual double Impuesto(double subtotal)
        {

            return 0;
        }
        public virtual double Total(double subt,double desc,double imp)
        {

            return 0;
        }


    }
}
