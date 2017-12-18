using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EDD_Practica1
{
    class NodoListaCircular
    {
        private Usuario  Dato;
        private NodoListaCircular Siguiente;
        private NodoListaCircular Atras;

        public Usuario dato
        {
            get { return Dato; }
            set { Dato = value; }
        }
        public NodoListaCircular siguiente
        {
            get { return Siguiente; }
            set { Siguiente = value; }
        }
       public NodoListaCircular atras
        {
            get { return Atras; }
            set { Atras = value; }
 }
    }
}
