using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EDD_Practica1
{
    class NodoPila
    {
        private MatrizOrtogonal  dato;
        private NodoPila siguiente;

        public MatrizOrtogonal  Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public NodoPila Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
    }
}
