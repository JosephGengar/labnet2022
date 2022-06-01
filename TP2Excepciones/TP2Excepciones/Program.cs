using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Excepciones.Exceptions;
using TP2Excepciones.ExtensionMethods;
using TP2Excepciones.PrimaryClass;
using TP2Excepciones.ExceptionModels;

namespace TP2Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            try
            {
                Console.WriteLine("Ejericio 1: Si se la Banca Intente dividir un numero por cero \n");
                Calculos Calculo = new Calculos();
                Calculo.DivisionExtension();
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error: " + ex.Message  + "\n");
            }
            finally
            {
                Console.WriteLine("Concluyo la operacion \n");              
            }
            //Ejercicio 2
            try
            {
                Console.WriteLine("Ejercicio 2: Diviendo dos numeros obtendra su resultado o no.... \n");
                Calculos Calculo2 = new Calculos();
                Calculo2.DivisionExtension2();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "\n");
            }
            finally
            {
                Console.WriteLine("Concluyo la operacion \n");               
            }
            //Ejercicio 3
            try
            {
                Console.WriteLine("Ejercicio 3: Disparando una Excepcion.. \n");
                Logic.DevolverSumaNull(null, 5);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Mensaje de Error: {ex.Message}");
                Console.WriteLine($"Tipo de Error: {ex.GetType()}");
            }
            finally
            {
                Console.WriteLine("Concluyo la operacion \n");
            }
            //Ejercicio 4
            try
            {
                Logic.DevolviendoExcepcionPersonalizada();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Mensaje de Excepcion: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Concluyo la operacion");
            }
            Console.ReadKey();
        }

     
    }
}
