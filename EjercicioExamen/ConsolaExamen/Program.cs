using System;
using System.Collections.Generic;

namespace EjercicioExamen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("A");
            list.Add("A");
            list.Add("A");
            list.Add("D");
            list.Add("D");
            list.Add("B");
            IEnumerable<string> cadena = list;

            var salida = cadena.ContarIguales();
            var iterador =salida.GetEnumerator();
            while (iterador.MoveNext())
            {
                Console.WriteLine(iterador.Current);
            }
        }
    }
}
