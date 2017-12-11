using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    class Pila
    {
        private NodoPila primero = new NodoPila();
        public Pila()
        {
            primero = null;
        }
        public void Push(String dato)
        {
            NodoPila nuevo = new NodoPila();
            nuevo.Dato = int.Parse(dato);
            nuevo.Siguiente = primero;
            primero = nuevo;
            MessageBox.Show("Dato ingresado pila");

        }
        public NodoPila peek()
        {
            if(primero != null)
            {
                MessageBox.Show(" " + primero.Dato);
                return primero;
            }
            return null;

        }
        public NodoPila pop()
        {
            NodoPila actual =  primero;
            if (primero != null)
            {
                MessageBox.Show(" " + actual.Dato);
                primero = primero.Siguiente;
                return actual;
            }
            return null;
        }
    }
}
