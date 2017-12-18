using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _EDD_Practica1
{
    public partial class Matriz : Form
    {
        Cola cola = new Cola();
        ListaCircular l;
        Pila pila = new Pila();
        int f, c = 0;
        MatrizOrtogonal matrix = new MatrizOrtogonal (0,0);
        Usuario   user = new Usuario("", "");

        public Matriz()
        {
            InitializeComponent();
        }
        public void setLista(object l)
        {
            this.l = (ListaCircular)l;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //String ingresarcolar = textBox3.Text;
            //cola.insertarCola(ingresarcolar);
            //textBox3.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cola.GraficarCola();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cola.desencolar();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Usuario\\Desktop\\ListaCircular.png");
            // l.graficarLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //String datoPila = textBox1.Text;
            //pila.Push(datoPila);
            //textBox1.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // pila.peek();
            pila.GraficaPila();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //qqui solo las voy a crear y llenar
            MatrizOrtogonal matrix = new MatrizOrtogonal(1, 3);
            MatrizOrtogonal matrix2 = new MatrizOrtogonal(3, 1);
            MatrizOrtogonal matrix3 = new MatrizOrtogonal(3, 2);
          //  matrix.CrearMatriz();
            int dato, fila, col;
            dato = 10;
            fila = 0;
            col = 1;
            matrix.CrearMatriz();
            matrix.setearValor(dato, fila, col);
            /// matrix.GraficarMatriz(matrix.Inicio);
            cola.insertarCola(matrix);
            matrix2.CrearMatriz();
            pila.Push(matrix2);
            matrix3.CrearMatriz();
            pila.Push(matrix3);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "json files (*.json)|*.json";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        if ((myStream = openFileDialog1.OpenFile()) != null)
            //        {
            //            using (myStream)
            //            {
            //                //Insert code to read the stream here.
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //    }
            //            }

            //LeerArchivo l = new LeerArchivo();

            String ruta = File.ReadAllText("C:\\Users\\Usuario\\Desktop\\archivo1.json");
            rootObject    p1 = JsonConvert.DeserializeObject <rootObject >(ruta);
            MatrizOrtogonal objinicial;
            MatrizJson jsonmatriz;
            ValorJson jsonvalor;
            int fila, columna, dato, x, y;
            if (p1 != null)
            {
                if (p1.archivo != null)
                {
                    if (p1.archivo.cola != null)
                    {
                        if (p1.archivo.cola.matrices != null)
                        {
                            if (p1.archivo.cola.matrices.matriz != null)
                            {
                                for (int xi = 0; xi < p1.archivo.cola.matrices.matriz.Count; xi++)
                                {
                                    jsonmatriz = p1.archivo.cola.matrices.matriz[xi];
                                    fila = jsonmatriz.size_y;
                                    columna = jsonmatriz.size_x;
                                    objinicial = new MatrizOrtogonal(fila, columna);
                                    objinicial.CrearMatriz();
                                    if (jsonmatriz.valores != null)
                                    {
                                        if (jsonmatriz.valores.valor != null)
                                        {
                                            {
                                                for (int yi = 0; yi < jsonmatriz.valores.valor.Count; yi++)
                                                {
                                                    jsonvalor = jsonmatriz.valores.valor[yi];
                                                    dato = jsonvalor.dato;
                                                    x = jsonvalor.pos_x;
                                                    y = jsonvalor.pos_y;
                                                    objinicial.setearValor(dato, x, y);
                                                }
                                            }
                                        }
                                    }
                                    Principal.logueado.colita.insertarCola(objinicial);
                                }
                            }
                        }
                    }
                    if (p1.archivo.pila != null)
                    {
                        if (p1.archivo.pila.matrices != null)
                        {
                            if (p1.archivo.pila.matrices.matriz != null)
                            {
                                for (int xi = 0; xi < p1.archivo.pila.matrices.matriz.Count; xi++)
                                {
                                    jsonmatriz = p1.archivo.pila.matrices.matriz[xi];
                                    fila = jsonmatriz.size_y;
                                    columna = jsonmatriz.size_x;
                                    objinicial = new MatrizOrtogonal(fila, columna);
                                    objinicial.CrearMatriz();
                                    if (jsonmatriz.valores != null)
                                    {
                                        if (jsonmatriz.valores.valor != null)
                                        {
                                            {
                                                for (int yi = 0; yi < jsonmatriz.valores.valor.Count; yi++)
                                                {
                                                    jsonvalor = jsonmatriz.valores.valor[yi];
                                                    dato = jsonvalor.dato;
                                                    x = jsonvalor.pos_x;
                                                    y = jsonvalor.pos_y;
                                                    objinicial.setearValor(dato, x, y);
                                                }
                                            }
                                        }
                                    }
                                    Principal.logueado.pilita.Push(objinicial);
                                }
                            }
                        }
                    }

                }
            }


            //using (StreamReader r = new StreamReader("C:\\Users\\Usuario\\Desktop\\prueba.json"))
            //{
            //    string json = r.ReadToEnd();
            //    List<Persona> items = JsonConvert.DeserializeObject<List<Persona>>(json);

            //}

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pila.pop();
            pila.GraficaPila();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Multiplicar clasemultiplicar = new Multiplicar();
            clasemultiplicar.ObtenerMatrices();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            cola.desencolar();
            cola.GraficarCola();
        }


        //public void multiplicarMatrices(MatrizOrtogonal ma1, MatrizOrtogonal ma2)
        //{

        //    int suma = 0, i = 0, j = 0, k = 0;
        //    if (ma1.columnas == ma2.filas)// m*n x n*b entonces verifica si n=m la resultante
        //                                  //sera de m*b
        //    {
        //        MatrizOrtogonal matrizResultante = new MatrizOrtogonal(ma1.filas, ma2.columnas);
        //        //como si seran iguales se puede multiplicar
        //        //la matriz resultante
        //        matrizResultante.CrearMatriz();
        //        // matrizResultante.setearValor(ma1.Inicio.x, ma2.Inicio.y); 
        //        while (i < ma1.filas)
        //        { //A(1i)+B(i1)
        //            while (j < ma2.columnas)
        //            {
        //                suma = 0;
        //                while (k < ma1.columnas)
        //                {
        //                    suma += ma1.ObtenerNodo(i, k).Dato * ma2.ObtenerNodo(k, j).Dato;
        //                }
        //                matrizResultante.setearValor(suma, i, j);
        //            }

        //        }
        //        matrizResultante.GraficarMatriz(matrizResultante.Inicio);//GRAFICAR RESULTANTE
        //    }

        //}
        //public void ObtenerMatrices()
        //{
        //    //aqui las voy a obtener haciendo un pop de dequeque en cada una
        //    MatrizOrtogonal matrizA, matrizB;
        //    //NodoCola cola = cola.Desencolar();
        //    //NodoPila pila = pilita.pop();
        //    if (cola != null && pila != null)
        //    {
        //        matrizA = cola.desencolar().Dato;
        //        matrizB = pila.pop().Dato;
        //        user.multiplicarMatrices(matrizA, matrizB);
        //    }


        //}

    }
}
