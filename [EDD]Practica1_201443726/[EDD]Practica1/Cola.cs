using System;
using System.Collections.Generic;
using System.IO;
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
        public void insertarCola(MatrizOrtogonal matrizdesencolada)//int matrizdesencolada
        {
            NodoCola nuevo = new NodoCola();
            //nuevo.Dato  = int.Parse(matrizdesencolada);
            nuevo.Dato = matrizdesencolada;
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
            //MessageBox.Show("Dato encolado  " + nuevo.Dato);
        }

        public void vercola()//seria graficar
        {
            NodoCola actual = new NodoCola();
            actual = primero;
            if (primero != null) //si no esta vacia
            {
                while (actual != null)
                {
                    //listar nodos
                    //enlazar nodos
                    MessageBox.Show("->" + actual.Dato);
                    actual = actual.Siguiente;//para que recorra e imprima
                }
            }
            else
            {
                MessageBox.Show("Cola vacia :u");
            }
        }

        public void peek()
        {
            if (primero != null)
            {
                primero.Dato.GraficarMatriz(primero.Dato.Inicio);
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
            TextWriter archivo;
            archivo = new StreamWriter("C:\\Users\\Usuario\\Desktop\\Cola.dot");
            archivo.WriteLine("digraph ListaS{\n");
            archivo.WriteLine("label= \"Cola\"\n");
            archivo.WriteLine("\tnode [fontcolor=\"blue\", height=0.5, color=\"black\"]\n");
            archivo.WriteLine("\tedge [color=\"black\", dir=fordware]\n");
            archivo.WriteLine("rankdir = LR;");
            System.Diagnostics.ProcessStartInfo informacion;
            System.Diagnostics.Process Proceso;
            recorrerCola(archivo);
            archivo.WriteLine("\n}");
            archivo.Close();
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/cdot C:\\Users\\Usuario\\Desktop\\Cola.dot -Tpng -o C:\\Users\\Usuario\\Desktop\\Cola.png");
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/cC:\\Users\\Usuario\\Desktop\\Cola.png");
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();
        }

        public void recorrerCola(TextWriter archivo)
        {
            NodoCola nodo = primero;
            String texto;
            int contador = 0;

            if (primero == null)
            {
                return;
            }
            while (nodo != null)
            {
                // texto += "{rank =min;";
                texto = "nodo" + contador + "[label= \"" + nodo.Dato.hacerSuma () + "\"];\n";
                archivo.WriteLine(texto);
                nodo = nodo.Siguiente;
                contador++;
            }
            contador = 0;
            nodo = primero;

            while (nodo.Siguiente != null)
            {
                texto = "nodo" + contador + "-> nodo" + (contador + 1) + ";\n";
                archivo.WriteLine(texto);
                nodo = nodo.Siguiente;
                contador++;
            }

        }


    }

}
