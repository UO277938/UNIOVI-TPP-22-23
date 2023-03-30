using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio2
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> valores = Enumerable.Range(1, 9);

            valores.Select(i => i + 1);

        }

    }

}
