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

namespace _EDD_Practica1
{
    public partial class Matriz : Form
    {
        Cola cola = new Cola();
        ListaCircular l;
        Pila pila = new Pila();

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
            String ingresarcolar = textBox3.Text;
            cola.insertarCola(ingresarcolar);
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cola.vercola();
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
            String datoPila = textBox1.Text;
            pila.Push(datoPila);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pila.peek();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int num1 = 3;
            int num2 = 2;
            MatrizOrtogonal matrix = new MatrizOrtogonal(num1, num2);
            matrix.CrearMatriz();
            int dato, fila, col;
            dato = 1000;
            fila =0;
            col = 1;
            matrix.setearValor(dato, fila, col);
            matrix.GraficarMatriz(matrix.Inicio );
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
