using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    class Pila
    {
        private NodoPila primero = new NodoPila();
        NodoPila nuevo = new NodoPila();
        public Pila()
        {
            primero = null;
        }
        public void Push(MatrizOrtogonal  matriz)
        {
            nuevo = new NodoPila();
            nuevo.Dato = matriz;
            nuevo.Siguiente = primero;
            primero = nuevo;
            //MessageBox.Show("Ingresado a pila "+ nuevo.Dato );

        }
        public void peek()//ver
        {
            if (primero != null)
            {
                primero.Dato.GraficarMatriz(primero.Dato.Inicio);
            }
        }
        public NodoPila pop()
        {
            NodoPila actual = primero;
            if (primero != null)
            {
               /// MessageBox.Show(" " + actual.Dato);
                primero = primero.Siguiente;
                return actual;
            }
            MessageBox.Show("pila vacia");
            return null;
        }
        public void recorrerPila(TextWriter archivo)
        {
            
            NodoPila nodo = new NodoPila ();
            nodo = primero;
                       
            String texto;
            int contador=0;
            //nodo.Dato.hacerSuma();
            if (primero == null)
            {
                return;
            }
                while (nodo != null)
            {
                texto = "nodo" +contador+ "[label= \"" + nodo.Dato.hacerSuma()  + "\"];\n";
                archivo.WriteLine(texto);
                nodo = nodo.Siguiente;
                contador++;
            }
            contador = 0;
            nodo = primero;
           
            while (nodo.Siguiente != null)
            {
                texto = "nodo" + contador + "-> nodo" + (contador+1)  + ";\n";
                archivo.WriteLine(texto);
                nodo = nodo.Siguiente;
                contador++;
            }

        }
        public void GraficaPila()
        {
            TextWriter archivo;
            archivo = new StreamWriter("C:\\Users\\Usuario\\Desktop\\Pila.dot");
            archivo.WriteLine("digraph ListaS{\n");
            archivo.WriteLine("label= \"Pila\"\n");
            archivo.WriteLine("\tnode [fontcolor=\"purple\", height=0.5, color=\"black\"]\n");
            archivo.WriteLine("\tedge [color=\"black\", dir=fordware]\n");

            System.Diagnostics.ProcessStartInfo informacion;
            System.Diagnostics.Process Proceso;
            recorrerPila(archivo);
            archivo.WriteLine("\n}");
            archivo.Close();
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/cdot C:\\Users\\Usuario\\Desktop\\Pila.dot -Tpng -o C:\\Users\\Usuario\\Desktop\\Pila.png");
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/cC:\\Users\\Usuario\\Desktop\\Pila.png");
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();

        }
    }
}
