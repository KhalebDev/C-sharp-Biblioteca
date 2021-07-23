using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class ClsEmpleado:ClsDatosGenerales
    {

        private string ocupacion;
        private static string codAcceso;

        public string Ocupacion
        {
            get
            {
                return ocupacion;
            }

            set
            {
                ocupacion = value;
            }
        }

        public string CodAcceso
        {
            get
            {
                return codAcceso;
            }

            set
            {
                codAcceso = value;
            }
        }
    }
}
