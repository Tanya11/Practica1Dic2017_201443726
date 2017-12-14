using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    class Cola
    {
        private NodoCola primero = new NodoCola();
        private NodoCola ultimo = new NodoCola();
        public Cola()
        {
            primero = null;
            ultimo = null;
               }
        public void insertarCola(String datoencolar)
        {
            NodoCola nuevo = new NodoCola();
            nuevo.Dato  = int.Parse(datoencolar );
            if (primero == null)//indica que esta vacio y el nuevo es el primero
            {
                primero = nuevo;
                primero.Siguiente = null;
                ultimo = nuevo; //como solo exite uno el primero y ultimo es el mismo >D
            }
            else
            {
                ultimo.Siguiente = nuevo; //para agregar al otro
                nuevo.Siguiente = null;
                ultimo = nuevo;
            }
            MessageBox.Show("Dato encolado  "+ nuevo.Dato );
        }

    public void vercola()//seria graficar
        {
            NodoCola actual = new NodoCola();
            actual = primero;
             if ( primero != null) //si no esta vacia
            {
                while (actual != null)
                {
                    //listar nodos
                    //enlazar nodos
                    MessageBox.Show("->" + actual.Dato);
                    actual = actual.Siguiente;//para que recorra e imprima
                }
            }else
            {
                MessageBox.Show("Cola vacia :u");
            }
        }

        public void peek()
        {
            if (primero != null)
            {
                //primero.Dato.Graficar();
                MessageBox.Show(" " + primero.Dato);
            }

        }

        public NodoCola desencolar()
        {
            NodoCola actual = primero; //el actual es como el aux
            if (actual != null)
            {
                primero = primero.Siguiente;
                return actual;
            }
            return null;
            }

        public void GraficarCola()
        {

        }
    }

}
