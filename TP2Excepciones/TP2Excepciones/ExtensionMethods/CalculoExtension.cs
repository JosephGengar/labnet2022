using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Excepciones.Exceptions;
using TP2Excepciones.PrimaryClass;

namespace TP2Excepciones.ExtensionMethods
{
    public static class CalculoExtension
    {
        public static void DivisionExtension(this Calculos Calculin)
        {
            try
            {           
                //Harcodeo la division por cero en el metodo Dividir, dado que solo quiere ver un error simple no asi el ejercicio siguiente.
                Console.WriteLine("Ingrese un numero a dividir sobre Cero: ");
                int dividendo = int.Parse(Console.ReadLine());
                int resultado = Calculin.Dividir(dividendo);
                //Console.WriteLine($"El resultado de la division es: {resultado}");
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }
        public static void DivisionExtension2(this Calculos Calculin)
        {
            try
            {
                Console.WriteLine("Ingrese un numero a dividir: ");
                int dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el divisor: ");
                int divisor = int.Parse(Console.ReadLine());
                int resultado = Calculin.Dividir2(dividendo, divisor);
                Console.WriteLine($"El resultado de la division es: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("No sea Manco!!!!, Solo el Diegote puede dividir por cero...");
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
            }
        }
    }
}
