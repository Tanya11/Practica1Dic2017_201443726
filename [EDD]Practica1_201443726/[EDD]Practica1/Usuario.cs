using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EDD_Practica1
{
    class Usuario
    {
        public string nombre = null;
        public string contraseña = null;

        public Usuario(String n, String c)
        {
            nombre = n;
            contraseña  = c;
        }
    }
}
