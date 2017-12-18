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
        public Matriz()
        {
            InitializeComponent();
            label3.Text = Principal.UsuarioLogueado;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //String ingresarcolar = textBox3.Text;
            //cola.insertarCola(ingresarcolar);
            //textBox3.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Principal.logueado.colita.GraficarCola();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Principal.logueado.colita.desencolar();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // matrix.GraficarMatriz();
            //pictureBox1.Image = Image.FromFile("C:\\Users\\Usuario\\Desktop\\ListaCircular.png");
            // l.graficarLista();
          //  pictureBox1.Image = Image.FromFile("C:\\Users\\Usuario\\Pictures\\J1 2016\\Camera\\kili.jpeg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principal.logueado.pilita.peek ();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // pila.peek();
            Principal.logueado.pilita.GraficaPila();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Principal.logueado.pilita.peek();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "json files (*.json)|*.json";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            rootObject p1 = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                p1 = JsonConvert.DeserializeObject<rootObject>(File.ReadAllText(openFileDialog1.FileName));
            }
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


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        //    pila.pop();
        //    pila.GraficaPila();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Multiplicar clasemultiplicar = new Multiplicar();
            clasemultiplicar.ObtenerMatrices();
            
        }

        private void Matriz_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Principal.logueado.pilita.GraficaPila ();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Principal.logueado.colita.GraficarCola();

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
       
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Principal.logueado.colita.peek();
        }
    }
}
