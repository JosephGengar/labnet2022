using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Excepciones.Exceptions;
using TP2Excepciones.ExtensionMethods;
using TP2Excepciones.PrimaryClass;
using TP2Excepciones.ExceptionModels;
using System.Windows.Forms;
using System.Threading;

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
                Console.ForegroundColor = ConsoleColor.Green;             
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
                Console.WriteLine("Presione cualquier tecla para continuar\n");
                Console.ReadKey();              
            }
            //Ejercicio 3
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;               
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
                Console.WriteLine("Presione cualquier tecla para continuar\n");
                Console.ReadKey();
            }
            //Ejercicio 4
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ejercicio 4: Disparando una Excepcion Personalizada.. \n");
                Logic.DevolviendoExcepcionPersonalizada();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Mensaje en Caja de Texto: {ex.Message}", "Ocurrio una Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Console.WriteLine("Concluyo la operacion \n");              
            }
            Console.ReadKey();
        }

     
    }
}
