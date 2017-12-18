using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EDD_Practica1
{
    class NodoCola
    {
        private MatrizOrtogonal   dato;
        private NodoCola siguiente;

        public MatrizOrtogonal  Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public NodoCola  Siguiente
        {
            get { return siguiente; }
            set { siguiente  = value; }
        }
    }
}
