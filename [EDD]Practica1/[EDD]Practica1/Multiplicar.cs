using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    class Multiplicar
    {
        

        public void multiplicarMatrices(MatrizOrtogonal ma1, MatrizOrtogonal ma2)
        {

            int suma = 0, i = 0, j = 0, k = 0;
            if (ma1.columnas == ma2.filas)// m*n x n*b entonces verifica si n=m la resultante
                                          //sera de m*b
            {
                MatrizOrtogonal matrizResultante = new MatrizOrtogonal(ma1.filas, ma2.columnas);
                //como si seran iguales se puede multiplicar
                //la matriz resultante
                matrizResultante.CrearMatriz();
                // matrizResultante.setearValor(ma1.Inicio.x, ma2.Inicio.y); 
                while (i < ma1.filas)
                { //A(1i)+B(i1)
                    while (j < ma2.columnas)
                    {
                        suma = 0;
                        while (k < ma1.columnas)
                        {
                            suma += ma1.ObtenerNodo(i, k).Dato * ma2.ObtenerNodo(k, j).Dato;
                        }
                        matrizResultante.setearValor(suma, i, j);
                    }

                }
                matrizResultante.GraficarMatriz(matrizResultante.Inicio);//GRAFICAR RESULTANTE
            }

        }

        public void ObtenerMatrices()
        {
            MatrizOrtogonal matrizA, matrizB;
            

            Usuario user = Principal.listCirc.ObtenerUsuario(Principal.UsuarioLogueado, Principal.contrasenaLogueado);
            if (Principal.UsuarioLogueado == null)
            {
                MessageBox.Show("Error");
                return;
            }
            Cola colita = user.colita;
            Pila pilita = user.pilita;

            NodoCola cola = colita.desencolar();
            NodoPila pila = pilita.pop();
            if (cola != null && pila != null)
            {
                matrizA = colita.desencolar().Dato;
                matrizB = pilita.pop().Dato;
                multiplicarMatrices(matrizA, matrizB);
            }


        }

    }

}
