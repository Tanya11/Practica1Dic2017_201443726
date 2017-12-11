using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    class ListaCircular
    {
        public static ListaCircular listCirc = new ListaCircular();
        NodoListaCircular primero = new NodoListaCircular();
        NodoListaCircular ultimo = new NodoListaCircular();

        public ListaCircular()
        {
            primero = null;
            ultimo = null;
        }

        public void insertarNodoListaCircular(String nombre, string contrasena)
        {
            NodoListaCircular nuevo = new NodoListaCircular();
            //nuevo.dato = int.Parse (Console.ReadLine() );//recibe el dato de la interfaz
            Usuario user = new Usuario(nombre, contrasena);
            nuevo.dato = user;
            if (primero == null)
            {
                primero = nuevo; //como no hay nada el mismo nodo sera los dos
                ultimo = nuevo;
                primero.siguiente = primero;
                primero.atras = ultimo;
            }
            else
            {
                ultimo.siguiente = nuevo; //para qu ehaga el enlace del siguiente 
                nuevo.atras = ultimo;
                nuevo.siguiente = primero;//para que se haga circular
                ultimo = nuevo;
                primero.atras = ultimo;
            }
            MessageBox.Show("dato ingresado");
            //Console.WriteLine("dato ingresado biennn!!");
        }

        internal void mostrar()
        {
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/c C:\\Users\\Usuario\\Desktop\\ListaCircular.png");
            informacion.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();
        }

        public void RecorrerListaCircular()
        {
            NodoListaCircular actual = new NodoListaCircular();
            // Usuario user = new Usuario();
            actual = primero;
            if (actual != null)
            {
                do
                {
                    MessageBox.Show(actual.dato.nombre + "," + actual.dato.contraseña);
                    actual = actual.siguiente;
                } while (actual != primero);
            }
                    }

        System.Diagnostics.ProcessStartInfo informacion;
        System.Diagnostics.Process Proceso;

        public Boolean BuscarListaCircular(String nombre, String contra)
        {
            NodoListaCircular actual = new NodoListaCircular();
            Usuario abuscar = new Usuario(nombre, contra);
            actual = primero;
            if (actual != null) //si no esta vacia
            {
                do
                {
                    if (actual.dato.nombre == nombre && actual.dato.contraseña == contra)
                    {
                        //   MessageBox.Show("el usuario ya existe: " + actual.dato.nombre );
                        return true;
                    }
                    actual = actual.siguiente;//para que siga buscando
                } while (actual != primero); //si es el primero ya recorrio toda la lista

            }
            else
            {
                // MessageBox.Show("Lista vacia");
            }
            return false;
        }

        public void EliminarListaCircular(String nombre, String contrasena)
        {
            NodoListaCircular actual = new NodoListaCircular();
            Usuario aeliminar = new Usuario(nombre, contrasena);
            actual = primero;
            bool encontrado = false;
            // aeliminar = int.Parse(datoEliminar );//dato que viene de la interfaz
            if (actual != null) //si no esta vacia
            {
                do
                {
                    if (actual.dato.nombre == nombre && actual.dato.contraseña == contrasena)
                    {
                        MessageBox.Show("Usuario a eliminar : " + actual.dato.nombre);
                        encontrado = true;
                        actual.atras.siguiente = actual.siguiente; //para pasar el puntero al siguiente 
                        actual.siguiente.atras = actual.atras; //para enlazar el siguiente de eliminar con el anterior 
                    }
                    actual = actual.siguiente;//para que siga buscando
                } while (actual != primero); //si es el primero ya recorrio toda la lista
                if (!encontrado)
                {
                    MessageBox.Show("El usuario no existe  :( " + actual.dato.nombre);
                }
            }
            else
            {
                MessageBox.Show("Lista vacia >:");
            }
        }

        public  void graficarLista()
                    {
            TextWriter archivo;
            archivo = new StreamWriter("C:\\Users\\Usuario\\Desktop\\ListaCircular.dot");
            //            String mensaje = "hola";
            //archivo.WriteLine(mensaje);
               
            MessageBox.Show("creado correctamente");
              //try
            //{
            //    file1 = new File(nombre);
            //    escribirarchivo = new FileWriter(file1);
            //    bufferw = new BufferedWriter(escribirarchivo);
            //    imprimirescrito = new PrintWriter(bufferw);

             archivo.WriteLine ("digraph ListaS{\n");
            archivo.WriteLine ("label= \"Lista Circular\"\n");
            archivo.WriteLine("\tnode [fontcolor=\"red\", height=0.5, color=\"black\"]\n");
            archivo.WriteLine("\tedge [color=\"black\", dir=fordware]\n");
            recorrerGraficar(archivo);
            archivo.WriteLine("\n}");
            archivo.Close();
           
            informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/cdot C:\\Users\\Usuario\\Desktop\\ListaCircular.dot -Tpng -o C:\\Users\\Usuario\\Desktop\\ListaCircular.png");
            //informacion.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            informacion.RedirectStandardOutput = true;
            informacion.UseShellExecute = false;
            informacion.CreateNoWindow = false;
            Proceso = new System.Diagnostics.Process();
            Proceso.StartInfo = informacion;
            Proceso.Start();
            //}
            //catch (Exception e)
            //{
            //}
        }

        public void recorrerGraficar(TextWriter   archivo)
        {
           NodoListaCircular  nodito = new NodoListaCircular ();
            nodito = primero;
            String texto;
            if (nodito != null)
            {
                do
                {
                    texto = "nodo" + nodito.dato.nombre + nodito.dato.contraseña + "[label= \"" + nodito.dato.nombre + " | " + nodito.dato.contraseña + "\"];\n";
                    //  texto = "nodo" + nodito.getNombre() + "[label= \"" + nodito.getNombre() + "\"];\n";
                    archivo.WriteLine(texto);
                    nodito = nodito.siguiente;
                } while (nodito != primero);
                nodito = primero;
                do//crear enlaces
                {
                    texto = "nodo" + nodito.dato.nombre + nodito.dato.contraseña + "-> nodo" + nodito.siguiente.dato.nombre + nodito.siguiente.dato.contraseña + ";\n";
                    archivo.WriteLine(texto);
                    nodito = nodito.siguiente;
                } while (nodito != primero);
                nodito = primero;
                do//crear enlaces
                {
                    texto = "nodo" + nodito.dato.nombre + nodito.dato.contraseña + "-> nodo" + nodito.atras.dato.nombre + nodito.atras.dato.contraseña + ";\n";
                    archivo.WriteLine(texto);
                    nodito = nodito.atras;
                } while (nodito != primero);
            } else
            {
                MessageBox.Show("lista vacia");
            }
        }
    }

}
