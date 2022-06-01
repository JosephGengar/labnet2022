using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Excepciones.Exceptions;
using TP2Excepciones.ExtensionMethods;

namespace TP2Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ejericio 1: Intente dividir por cero");
                CalculoException Calculo = new CalculoException();
                Calculo.DivisionExtension();
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error: " + ex.Message  + "\n");
            }
            finally
            {
                Console.WriteLine("Concluyo la operacion \n");
                Console.WriteLine("Ingrese cualquier tecla para continuar con el siguiente ejercicio \n");
            }
            try
            {
                Console.WriteLine("Ejercicio 2: Diviendo dos numeros obtendra su resultado o no.... \n");
                CalculoException Calculo2 = new CalculoException();
                Calculo2.DivisionExtension2();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "\n");
            }
            finally
            {
                Console.WriteLine("Concluyo la operacion \n");
                Console.WriteLine("Ingrese cualquier tecla para continuar con el siguiente ejercicio \n");
            }
            Console.ReadKey();
        }
    }
}
