using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1POO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una Cantidad de Pasajeros para Omnibus comprendida entre 0 y 100: ");
            Console.WriteLine("\n");
            List<int> ListaOmnibus = new List<int>();
            /*ListaOmnibus.Add("Ingrese cantidad de pasajeros para el Omnibus 1: ");
            ListaOmnibus.Add("Ingrese cantidad de pasajeros para el Omnibus 2: ");
            ListaOmnibus.Add("Ingrese cantidad de pasajeros para el Omnibus 3: ");
            ListaOmnibus.Add("Ingrese cantidad de pasajeros para el Omnibus 4: ");
            ListaOmnibus.Add("Ingrese cantidad de pasajeros para el Omnibus 5: ");
            Console.WriteLine("\n");
            Console.WriteLine("Ahora vamos a ingresar una cantidad de pasajeros para Taxis comprendida entre 0 y 4: ");
            Console.WriteLine("\n");*/
            List<int> ListaTaxis = new List<int>();
            /*ListaTaxis.Add("Ingrese cantidad de pasajeros para el Taxi 1: ");
            ListaTaxis.Add("Ingrese cantidad de pasajeros para el Taxi 2: ");
            ListaTaxis.Add("Ingrese cantidad de pasajeros para el Taxi 3: ");
            ListaTaxis.Add("Ingrese cantidad de pasajeros para el Taxi 4: ");
            ListaTaxis.Add("Ingrese cantidad de pasajeros para el Taxi 5: ");*/

            List<TransportePublico> ListaTransportePublico = new List<TransportePublico>();
            for (int i = 0; i < ListaOmnibus.Count; i++)
            {
                ListaTransportePublico.Add(new Omnibus($"Omnibus {i + 1}", ListaOmnibus[i]));
            }
            for (int i = 0; i < ListaTaxis.Count; i++)
            {
                ListaTransportePublico.Add(new Taxi($"Taxi {i + 1}", ListaTaxis[i]));
            }
        }
     
       
    }
}
