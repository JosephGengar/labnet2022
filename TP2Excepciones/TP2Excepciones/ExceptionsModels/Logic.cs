using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Excepciones.ExceptionModels;

namespace TP2Excepciones.Exceptions
{
    public class Logic
    {
        public static void DevolverSumaNull(int? number1, int number2)
        {
            try
            {
                Console.WriteLine("EJERCICIO 3: Disparando una Excepcion.. \n");
                int resultado = number1.Value + number2;
                Console.WriteLine($"El resultado es {resultado}");
                //No hace falta, siempre arroja excepcion, esta hardcodeado un null como en el video
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DevolviendoExcepcionPersonalizada()
        {
            Console.WriteLine("EJERCICIO 4: Disparando una Excepcion Personalizada.. \n");
            throw new CustomException("Mensaje de excepcion personalizado");
        }      
    }
}
