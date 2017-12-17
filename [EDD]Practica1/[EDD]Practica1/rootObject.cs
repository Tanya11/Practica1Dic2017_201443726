using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EDD_Practica1
{
    class rootObject
    {
        public ArchivoJson  archivo { get; set; }
    }
    class ArchivoJson
    {
       public ColaJson cola {get;set;}
        public PilaJson pila { get; set; }
    }
   
    class PilaJson
    {
       public MatricesJson matrices { get; set; }
}
    class ColaJson
    {
    public MatricesJson matrices { get; set; }
    }
    class MatricesJson
    {
        public List<MatrizJson> matriz { get; set; }
    }
    class MatrizJson
    {
        public int   size_x { get; set; }
        public int   size_y { get; set; }
        public ValoresJson valores { get; set; }
    }
    class ValoresJson
    {
      public List<ValorJson> valor { get; set; }
    }
    class ValorJson
    {
        public int dato { get; set; }
        public int pos_x { get; set; }
        public int pos_y { get; set; }
    }
}
