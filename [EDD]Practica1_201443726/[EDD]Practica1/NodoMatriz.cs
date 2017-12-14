using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EDD_Practica1
{
    class NodoMatriz
    {
        private NodoMatriz derecha;
        private NodoMatriz izquierda;
        private NodoMatriz arriba;
        private NodoMatriz abajo;
        private int dato;
        public int x, y;

        public int Dato
        {
            get { return dato; }
            set { dato = value; }
        }

        public NodoMatriz Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }
        public NodoMatriz Izquierda
        {
            get { return izquierda ; }
            set { izquierda  = value; }
        }
        public NodoMatriz Arriba
        {
            get { return  arriba; }
            set { arriba = value; }
                    }
        public NodoMatriz Abajo
        {
            get { return abajo; }
            set { abajo = value; }
        }
    }
}
