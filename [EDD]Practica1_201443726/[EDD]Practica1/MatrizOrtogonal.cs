using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    class MatrizOrtogonal
    {

        public int filas, columnas = 0;
        NodoMatriz inicio = new NodoMatriz();

        public MatrizOrtogonal(int columnas, int filas)
        {
            this.filas = filas;
            this.columnas = columnas;
        }
        public NodoMatriz Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }
        public void CrearMatriz()
        {

            inicio.Dato = 0;
            inicio.x = 0;
            inicio.y = 0;
            CrearFila(inicio);
            CrearColumna(inicio);
            EnlazarLosDemas(inicio);
           //GraficarMatriz(inicio);
        }
        public void CrearFila(NodoMatriz inicio)
        {
            NodoMatriz actual = inicio; //tomar el actual para ir enlazando 

            for (int i = 1; i < columnas; i++)
            {
                NodoMatriz nuevo;//
                nuevo = new NodoMatriz();
                nuevo.x = i;
                nuevo.y = inicio.y;
                actual.Derecha = nuevo; //creo nuevo nodo para crear filas inicio -> nodo
                nuevo.Dato = 0; //como crea el nuevo nodo le seteo el dato 0 para que no quede nulo
                nuevo.Izquierda = actual; //para hacer el enlaze doble al anterio CREOOOOO
                actual = nuevo;
            }

        }

        public void CrearColumna(NodoMatriz inicio)
        {
            NodoMatriz actual = inicio; //no se pierde el inicio y crea las filas hacia abajo
            int ii = 1;
            while (ii < filas) //debe crear las filas solamente enlazando el inicio y abajo
            {
                NodoMatriz nuevo = new NodoMatriz(); //inivio -> nuevo
                nuevo.x = inicio.x;
                nuevo.y = ii;
                actual.Abajo = nuevo; //ahora hace el nodo hacia abajo
                nuevo.Arriba = actual;
                nuevo.Dato = 0;
                actual = actual.Abajo; // el actual ahora sera el de abajo para ue haga la de abajo
                CrearFila(actual);//llamo al metodo crear fila para que siga haciendo la siguiente
                ii++;
            }
        }
        //ahora para enlazar los de arriba y abajo que quedaron sueltos despues del inicial
        // y despues de los de abajo del inicial
        public void EnlazarLosDemas(NodoMatriz inicio)
        {
            NodoMatriz actual = inicio;
            NodoMatriz filaAnterior = inicio; //las filas que se crearon ya con enlazes 
            NodoMatriz filaActual = inicio.Abajo;//la fila de abajo que solo esta unida arriba y abajo con el inicio
            int a = 0;
            int b = 0;
            NodoMatriz anterior;//
            while (a < filas - 1) //porque la fila de arriba ya esta hecha
            {
                anterior = filaAnterior;
                actual = filaActual;

                while (b < columnas - 1) //hacer los enlaces antes que columnas -1 porque el ultimo ya no se enlaza
                {
                    anterior = anterior.Derecha;
                    actual = actual.Derecha; //estas dos son para menearse arriba y abajo la misma cantidad
                    anterior.Abajo = actual; //hacer el enlace de abajo hacia arriba
                    actual.Arriba = anterior;
                    b++;
                }
                b = 0;
                a++;
                filaAnterior = filaActual; //al salir del ciclo necesito que se vaya hacia abajo
                filaActual = filaActual.Abajo; //para que se desplace de donde estaba y siga hacienod los mismos enlaces

            }
        }

        public void RecorrerParaGraficar(TextWriter archivo) //nose si debe de llevar algo inicio
        {
            NodoMatriz nodo = new NodoMatriz();
            nodo = inicio;
            String texto = string.Empty;
            if (nodo != null)
            {
                NodoMatriz aux = nodo;
                for (int i = 0; i < filas; i++)
                {
                    //texto += "{rank = min ";
                    for (int j = 0; j < columnas; j++)
                    {
                        if (i == 0)
                        {
                            texto += "{rank =min;\nNodo" + nodo.y + nodo.x + " [label=\"" + nodo.Dato + "|" + nodo.y + "," + nodo.x + "\"];\n";
                        }
                        else if (i == filas - 1)
                        {
                            texto += "{rank =max;\nNodo" + nodo.y + nodo.x + " [label=\"" + nodo.Dato + "|" + nodo.y + "," + nodo.x + "\"];\n";
                        }
                        else
                        {
                            texto += "{rank =same;\nNodo" + nodo.y + nodo.x + " [label=\"" + nodo.Dato + "|" + nodo.y + "," + nodo.x + "\"];\n";
                        }

                        if (nodo.Izquierda != null)
                        {
                            texto += "Nodo" + nodo.y + nodo.x + " -> Nodo" + nodo.Izquierda.y + nodo.Izquierda.x + "\n ";

                        }
                        if (nodo.Derecha != null)
                        {
                            //texto += "}";
                            texto += "Nodo" + nodo.y + nodo.x + " -> Nodo" + nodo.Derecha.y + nodo.Derecha.x + "\n";
                        }
                        texto += "}";
                        if (nodo.Arriba != null)
                        {
                            texto += "Nodo" + nodo.y + nodo.x + " -> Nodo" + nodo.Arriba.y + nodo.Arriba.x + "\n";

                        }
                        if (nodo.Abajo != null)
                        {
                            texto += "Nodo" + nodo.y + nodo.x + " -> Nodo" + nodo.Abajo.y + nodo.Abajo.x + "\n";

                        }
                        nodo = nodo.Derecha;
                        if (j == columnas - 1)

                            aux = aux.Abajo;
                    }
                    nodo = aux;
                }
                archivo.Write(texto);
            }
        }
        System.Diagnostics.ProcessStartInfo informacion;
        System.Diagnostics.Process Proceso;

        public void GraficarMatriz(NodoMatriz inicio)
        {
            TextWriter archivo;
            archivo = new StreamWriter("C:\\Users\\Usuario\\Desktop\\Matriz.dot");
            archivo.WriteLine("digraph Matriz{\n");
            archivo.WriteLine("label= \"Matriz Ortogonal\"\n");
            archivo.WriteLine("\tnode [shape=box];\n");
            //archivo.WriteLine("\trankdir = UD;\n");
            archivo.WriteLine("\tnode [fontcolor=\"purple\", height=0.5, color=\"black\"]\n");
            archivo.WriteLine("\tedge [color=\"black\", dir=fordware]\n");
            RecorrerParaGraficar(archivo);
            archivo.WriteLine("\n}");
            archivo.Close();
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/cdot C:\\Users\\Usuario\\Desktop\\Matriz.dot -Tpng -o C:\\Users\\Usuario\\Desktop\\Matriz.png");
            ///  informacion.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/cC:\\Users\\Usuario\\Desktop\\Matriz.png");
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();
        }
        public NodoMatriz ObtenerNodo(int fi, int col) //metodo get para obtener posicion
        {//este debe obtener el nodo de la posicion y retornar el valor para llamar el metodo de
            //setear y que le coloque el valor
            NodoMatriz nodo, aux;
            nodo = inicio;//(0,0)
            aux = inicio;//(0,0)
            //si viene 3,3
            for (int i = 0; i <= fi; i++) //recorrer filas hasta que no sea la que venga //0,1,2,3
            {
                for (int j = 0; j <= col; j++) //recorrer columnas  //0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3
                {
                    //algo que compare si llego a al nodo con la posicion
                    if (i == fi && j == col)     //si encontro el nodo en esa posicion    //falsex17,true
                    {//tonces retornas el nodo en esa posicion
                        return nodo;//return correcto
                    }
                    nodo = nodo.Derecha; //(3,3)  <----------------- posición correcta
                    if (j == col)//falsex3,true,falsex3,true,falsex3,true, falsex3
                        aux = aux.Abajo;//(3,0)
                }
                nodo = aux;//(3,0)
            }
            return null;
        }

        public void setearValor(int dato, int fil, int col)
        {
            NodoMatriz obtener = ObtenerNodo(fil, col);
            if (obtener != null)
            {
                obtener.Dato = dato;
            }
        }

        public int hacerSuma()
        {
            int suma = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    suma += ObtenerNodo(i, j).Dato;
                }
            }
          return suma;
        }

}
}
