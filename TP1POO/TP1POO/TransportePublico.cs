using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1POO
{
    public abstract class TransportePublico
    {
        public int Pasajeros { get; set; }
        public string Nombre { get; set; }             
        public TransportePublico(string nombre, int pasajeros)
        {
            this.Nombre = nombre;
            this.Pasajeros = pasajeros;
        }
        public abstract int Devolver();
        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
