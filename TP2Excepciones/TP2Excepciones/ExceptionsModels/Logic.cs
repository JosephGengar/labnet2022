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
                int resultado = number1.Value + number2;
                Console.WriteLine($"El resultado es {resultado}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DevolviendoExcepcionPersonalizada()
        {
            throw new CustomException("Mensaje de excepcion personalizado");
        }      
    }
}
