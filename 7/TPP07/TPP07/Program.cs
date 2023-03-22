using System;
using Modelo;

using System.Collections.Generic;
using System.Linq;

namespace TPP07
{
    class Program
    {
        static void Main(string[] args)
        {
             
            IEnumerable<int> valores = Enumerable.Range(1, 9); // 1 2 3 4 5 6 7 8 9   comienzo 1  -- nueve elementos

            //Uso del método Map : Colección de T a colección de Q.

            Console.WriteLine("Colecciones de enteros.");
            
            //Uso de métodos extensores
            //Map transforma una colección (T) en otra (Q).
            valores.Map(n => n * n).ForEach(Console.WriteLine);
            Console.WriteLine();

            valores.Map(n => n * n).Map(n => n / 2.0).ForEach(Console.WriteLine);
            Console.WriteLine();

            var doubles = Enumerable.Range(1, 9).Map(n => new Double()); //crear lista de double de forma funcional
                       
            valores.Map(n => new Angulo(n)).Map(a => a.Grados).ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("\nColecciones de Personas.");

            var personas = Factoria.CrearPersonas();

            var nombres = personas.Map(p => p.Nombre);
            nombres.ForEach(Console.WriteLine);
            Console.WriteLine();

            var iniciales = personas.Map(p => p.Nombre).Map(cadena => cadena[0]);
            iniciales.ForEach(Console.WriteLine);
            Console.WriteLine();
            personas.Map(p => p.Nif + "\t" + p.Nombre + "\t" + p.Apellido).ForEach(Console.WriteLine);


            //¿Qué estamos haciendo aquí?
            // Objeto anonimo, no tiene tipo
            var info = personas.Map(p => new
                {
                    Nombre = p.Nombre,
                    Dni = p.Nif
                }
            );

            info.ForEach(Console.WriteLine);

            /* EJERCICIO:
            * - Añade el método Map a tu lista.
            * - A partir de una lista de enteros: Calcula la suma de los cuadrados de la colección.
            * - A partir de una lista de Personas: Calcula la longitud media de los nombres de la colección.
            */


            //Método ZIP de Linq: Combina dos colecciones:

            var combinación = valores.Zip( personas.Map(p => p.Nombre) ); //IEnumerable de tuplas
            combinación.Map(c => c.First + " : " + c.Second).ForEach(Console.WriteLine);
        }
    }
}
