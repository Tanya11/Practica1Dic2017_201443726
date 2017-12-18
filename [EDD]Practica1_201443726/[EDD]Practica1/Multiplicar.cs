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

            int suma, i = 0, j = 0, k;
            if (ma1.columnas == ma2.filas)// m*n x n*b entonces verifica si n=m la resultante
                                          //sera de m*b
            {
                MatrizOrtogonal matrizResultante = new MatrizOrtogonal(ma2.columnas, ma1.filas);
                //como si seran iguales se puede multiplicar
                //la matriz resultante
                matrizResultante.CrearMatriz();
                // matrizResultante.setearValor(ma1.Inicio.x, ma2.Inicio.y); 
                while (i < ma1.filas)
                { //A(1i)+B(i1)
                    j = 0;
                    while (j < ma2.columnas)
                    {
                        suma = 0;
                        k = 0;
                        while (k < ma1.columnas)
                        {
                            suma += ma1.ObtenerNodo(i, k).Dato * ma2.ObtenerNodo(k, j).Dato;
                            k++;
                        }
                        matrizResultante.setearValor(suma, i, j);
                        j++;
                    }
                    i++;

                }
                matrizResultante.GraficarMatriz(matrizResultante.Inicio);//GRAFICAR RESULTANTE
            }

        }

        public void ObtenerMatrices()
        {
            MatrizOrtogonal matrizA, matrizB;
            if (Principal.UsuarioLogueado == null)
            {
                MessageBox.Show("Error");
                return;
            }
            Cola colita = Principal.logueado.colita;
            Pila pilita = Principal.logueado.pilita;

            NodoCola datocola = colita.desencolar();
            NodoPila datopila = pilita.pop();
            if (datocola != null && datopila != null)
            {
                matrizA = datocola.Dato;
                matrizB = datopila.Dato;
                multiplicarMatrices(matrizA, matrizB);
            }


        }

    }

}
