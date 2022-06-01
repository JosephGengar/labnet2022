using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Excepciones.ExceptionModels
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base ("Sobrecargando la CustomException / " + message)
        {

        }
    }
}
