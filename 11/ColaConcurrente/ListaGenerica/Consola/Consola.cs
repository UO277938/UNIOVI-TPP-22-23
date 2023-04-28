using System;
using System.Collections.Generic;
using Modelo;

namespace ListaEnlazada
{

    internal class Consola
    {
        static void Main(string[] args)
        {
            ListaEnlazada<int> lista = new ListaEnlazada<int>();

            lista.Añadir(7); //HEAD.
            lista.Añadir(8);
            lista.Añadir(9);
            lista.Añadir(10);

            Console.WriteLine(lista.ToString());

            Console.WriteLine(lista.GetElement(0));
            Console.WriteLine(lista.GetElement(1));
            Console.WriteLine(lista.GetElement(2));
            Console.WriteLine(lista.GetElement(3));

            Console.WriteLine(lista.Contiene(7));  //true
            Console.WriteLine(lista.Contiene(88)); //false

            lista.Borrar(8);
            Console.WriteLine(lista.ToString());

            lista.Borrar(7);
            Console.WriteLine(lista.ToString()); 

            lista.Borrar("Hola");
            Console.WriteLine(lista.ToString());

            Console.WriteLine(lista.Contiene(10));  //true
            Console.WriteLine(lista.Contiene(55));  //false 

            Console.WriteLine("ITERADOR");

            IEnumerator<int> listaE = lista.GetEnumerator();
            while (listaE.MoveNext())
            {
                Console.WriteLine((int)listaE.Current);
            }

            listaE.Reset();
            listaE.MoveNext();
            Console.WriteLine(listaE.Current);


            Console.WriteLine("INVERTIR");
            IEnumerable<int> listaInvertida = lista.Invertir();
            var iter = listaInvertida.GetEnumerator();
            while(iter.MoveNext())
                Console.WriteLine(iter.Current);
        }
    }
}
