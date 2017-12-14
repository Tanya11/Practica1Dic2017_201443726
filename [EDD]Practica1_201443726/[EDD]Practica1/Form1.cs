using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    public partial class Form1 : Form
    {
        ListaCircular listCirc = new ListaCircular();
                Cola cola = new Cola();
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Llene los dos campos");

                return;

            }
            else {
                String nombre = null;
                nombre = textBox2.Text;
                String contra = textBox1.Text;
                //mandar el dato del texbox en interfaz
                if (listCirc.BuscarListaCircular(nombre, contra) == true)
                {
                    MessageBox.Show("El usuario ya existe");
                }
                else
                {
                    listCirc.insertarNodoListaCircular(nombre, contra);
                }
                textBox2.Clear();
                textBox1.Clear();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // listCirc.RecorrerListaCircular();
           listCirc.graficarLista();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //String datobuscar=  textBox1.Text;
            // listCirc.BuscarListaCircular(datobuscar);
            // textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String nombre = textBox2.Text;
            String contrasena = textBox1.Text;
            listCirc.EliminarListaCircular(nombre, contrasena);
            textBox2.Clear();
            textBox1.Clear();
            listCirc.graficarLista();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //String ingresarcolar = textBox3.Text;
            //cola.insertarCola(ingresarcolar);
            //textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Matriz ma = new Matriz();
            ma.setLista(listCirc);
            String nombre = textBox2 .Text;
            String contra = textBox1.Text;
            if (listCirc.BuscarListaCircular(nombre, contra) == true)
            {
                ma.Show();
            }
            else
            {
                MessageBox.Show("Registrate primero! ;D");
            }
            textBox2 .Clear();
            textBox1.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Matriz ma = new Matriz();
            ma.setLista(listCirc);
            ma.Show();
        }
    }
}
