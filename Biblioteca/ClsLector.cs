using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class ClsLector:ClsDatosGenerales
    {
        private static string codLector = "";
        
        public string CodLector
        {
            get
            {
                return codLector;
            }

            set
            {
                codLector = value;
            }
        }

     
        
    }
}
