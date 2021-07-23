using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteca
{
    class ClsValidaciones
    {
        public  bool ValidarCaracteres(string cadena)
        {
            return cadena != null && Regex.IsMatch(cadena, @"^[a-zA-Z]+$");
        }
        public  bool ValidarNumeros(string cadena)
        {
            return cadena != null && Regex.IsMatch(cadena, "[0-9]");
        }
        public  bool ValidarEmail(string email)
        {
            return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
        }
    }
}
