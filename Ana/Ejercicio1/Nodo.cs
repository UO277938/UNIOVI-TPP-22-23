using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Nodo
    {
        public object Valor { get; } // Valor que se le asigna al nod

        public Nodo Siguiente { get; set; }

        public Nodo(object valor, Nodo next)
        {
            Valor = valor;
            Siguiente = next;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}
