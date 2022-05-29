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
            ListaOmnibus.Add(VerificarOmnibus("Ingrese cantidad de pasajeros para el Omnibus 1: "));
            ListaOmnibus.Add(VerificarOmnibus("Ingrese cantidad de pasajeros para el Omnibus 2: "));
            ListaOmnibus.Add(VerificarOmnibus("Ingrese cantidad de pasajeros para el Omnibus 3: "));
            ListaOmnibus.Add(VerificarOmnibus("Ingrese cantidad de pasajeros para el Omnibus 4: "));
            ListaOmnibus.Add(VerificarOmnibus("Ingrese cantidad de pasajeros para el Omnibus 5: "));
            Console.WriteLine("\n");
            Console.WriteLine("Ahora vamos a ingresar una cantidad de pasajeros para Taxis comprendida entre 0 y 4: ");
            Console.WriteLine("\n");
            List<int> ListaTaxis = new List<int>();
            ListaTaxis.Add(VerificarTaxis("Ingrese cantidad de pasajeros para el Taxi 1: "));
            ListaTaxis.Add(VerificarTaxis("Ingrese cantidad de pasajeros para el Taxi 2: "));
            ListaTaxis.Add(VerificarTaxis("Ingrese cantidad de pasajeros para el Taxi 3: "));
            ListaTaxis.Add(VerificarTaxis("Ingrese cantidad de pasajeros para el Taxi 4: "));
            ListaTaxis.Add(VerificarTaxis("Ingrese cantidad de pasajeros para el Taxi 5: "));

            List<TransportePublico> ListaTransportePublico = new List<TransportePublico>();
            for (int i = 0; i < ListaOmnibus.Count; i++)
            {
                ListaTransportePublico.Add(new Omnibus($"Omnibus {i + 1}", ListaOmnibus[i]));
            }
            for (int i = 0; i < ListaTaxis.Count; i++)
            {
                ListaTransportePublico.Add(new Taxi($"Taxi {i + 1}", ListaTaxis[i]));
            }
            Console.WriteLine("\n");
            Console.WriteLine("Lista final de Transporte:");
            Console.WriteLine("\n");
            foreach (var item in ListaTransportePublico)
            {
                Console.WriteLine(item.Nombre + " contiene: " + item.Devolver() + " pasajeros.");
                Console.WriteLine("----------------------------------");
            }
            Console.ReadKey();
        }
        //Validacion para omnibus de solo numeros enteros (sin coma, punto, negativos, cadenas) comprendidos entre 0 y 100
        public static int VerificarOmnibus(string comando)
        {
            int valor;
            Console.WriteLine(comando);
            var numero = Console.ReadLine();
            while (!int.TryParse(numero, out valor) || int.Parse(numero) > 100 || int.Parse(numero) < 0)
            {
                Console.WriteLine("Error!!! Configure correctamente los datos de entrada, intente de nuevo");
                Console.WriteLine(comando);
                numero = Console.ReadLine();
            }
            return Int16.Parse(numero);
        }
        //idem comentario anterior, no permitir ingreso de datos erroneos para los taxis, datos entre 0 y 4
        public static int VerificarTaxis(string comando)
        {
            int valor;
            Console.WriteLine(comando);
            var numero = Console.ReadLine();
            while (!int.TryParse(numero, out valor) || int.Parse(numero) > 4 || int.Parse(numero) < 0 )
            {
                Console.WriteLine("Error!!! Configure correctamente los datos de entrada, intente de nuevo");
                Console.WriteLine(comando);
                numero = Console.ReadLine();
            }
            return Int16.Parse(numero);
        }
    }
}
