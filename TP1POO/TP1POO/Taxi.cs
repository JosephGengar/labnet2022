using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1POO
{
    public class Taxi : TransportePublico
    {
        public Taxi(string nombre, int pasajeros) : base (nombre, pasajeros)
        {

        }
        public override string Avanzar()
        {
            return $"Soy un {Nombre} que Avanza";
        }

        public override string Detenerse()
        {
            return $"Soy un {Nombre} que se Detiene";
        }

        public override int Devolver()
        {
            return this.Pasajeros;
        }
    }
}
