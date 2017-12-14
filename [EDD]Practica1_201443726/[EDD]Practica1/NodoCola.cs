using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EDD_Practica1
{
    class NodoCola
    {
        private int dato;
        private NodoCola siguiente;

        public int Dato
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
