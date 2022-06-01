using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Excepciones.Exceptions
{
    public class CalculoException
    {
        public int Dividir(int number)
        {
            return (number / 0);
        }

        public int Dividir2(int number1, int number2)
        {
            return (number1 / number2);
        }
    }
}
