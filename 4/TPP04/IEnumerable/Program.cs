using System;
//Colecciones Genéricas
using System.Collections.Generic;

//Colecciones NO genéricas
//using System.Collections;

namespace IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            string palabra = "palabra";
            Console.WriteLine("Recorriendo palabra con foreach - IEnumerable");
            //Podemos usar el foreach porque String implementa IEnumerable
            foreach (var letra in palabra)
            {
                Console.Write(letra + " ");
            }

            Console.WriteLine("\nRecorriendo palabra con IEnumerator");
            //Realmente lo que se está haciendo es lo siguiente
            //IEnumerable tiene un único método y lo que hace éste es
            //Es devolver un IEnumerator (iterador)

            IEnumerator<char> iterador = palabra.GetEnumerator();
            while (iterador.MoveNext())
                Console.Write(iterador.Current + " ");


            //Nota: La tabla de multiplicar empieza multiplicando por 1.

            TablaMultiplicar tablaDel7 = new TablaMultiplicar(7, 10);
            Console.WriteLine("\nImplementación propia de IEnumerable e IEnumerator en una clase:");
            foreach (int elemento in tablaDel7)
                Console.WriteLine(elemento);
                      
        }

        /*
         * Crear un método que reciba dos colecciones que implementen IEnumerable<T>
         * Y devuelva como resultado un IEnumerable<T> con los valores que coincidan en la misma posición.
         * Resolver el ejercicio utilizando ITERADORES (IEnumerator).
         * Probar enviando:
         * Un array de caracteres y un string.
         * Una lista de caracteres y un string.
         * Vuestra lista con caracteres y otra lista vuestra con caracteres.
         * El resultado se recorre en un foreach y se imprime elemento a elemento.
        */
    }
}
