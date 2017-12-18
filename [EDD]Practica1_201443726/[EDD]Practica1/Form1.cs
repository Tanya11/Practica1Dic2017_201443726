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
        
        Cola cola = new Cola();
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//REGISTRAR
        {
            if (string.IsNullOrEmpty(textBox1.Text)|| string.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("Llene los dos campos");

                return;

            }
            else {
                String nombre = null;
                nombre = textBox2.Text;
                String contra = textBox1.Text;
                //mandar el dato del texbox en interfaz
                if (Principal.listCirc.BuscarListaCircular(nombre, contra) == true)
                {
                    MessageBox.Show("El usuario ya existe");
                }
                else
                {
                    Principal.listCirc.insertarNodoListaCircular(nombre, contra);
                }
                textBox2.Clear();
                textBox1.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Principal.listCirc.RecorrerListaCircular();
            Principal.listCirc.graficarLista();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            String nombre = textBox2.Text;
            String contrasena = textBox1.Text;
            Principal.listCirc.EliminarListaCircular(nombre, contrasena);
            textBox2.Clear();
            textBox1.Clear();
            Principal.listCirc.graficarLista();
        }



        private void button6_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            Matriz ma;
            String nombre = textBox2.Text;
            String contra = textBox1.Text;
            if (Principal.listCirc.BuscarListaCircular(nombre, contra) == true)
            {
                Usuario log = Principal.listCirc.ObtenerListaCircular(nombre, contra);
                if (log.colita == null)
                {
                    log.colita = new Cola();
                }
                if (log.pilita == null)
                {
                    log.pilita = new Pila();
                }
                Principal.logueado = log;
                Principal.UsuarioLogueado = log.nombre;
                Principal.contrasenaLogueado = log.contraseña;
                ma = new Matriz();
                ma.Show();
            }
            else
            {
                MessageBox.Show("Registrate primero! ;D");
            }
            textBox2.Clear();
            textBox1.Clear();
        }




        private void button5_Click_1(object sender, EventArgs e)
        {
            Matriz ma = new Matriz();
            ma.Show();
        }
    }
}
