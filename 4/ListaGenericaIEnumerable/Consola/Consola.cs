using System;
using System.Collections.Generic;

namespace ListaEnlazada
{

    internal class Consola
    {
        static void Main(string[] args)
        {
            ListaEnlazada<object> lista = new ListaEnlazada<object>();

            lista.Añadir(null); //HEAD.
            lista.Añadir(null);
            lista.Añadir(9);
            lista.Añadir(10);

            Console.WriteLine(lista.ToString());

            Console.WriteLine(lista.GetElement(0));
            Console.WriteLine(lista.GetElement(1));
            Console.WriteLine(lista.GetElement(2));
            Console.WriteLine(lista.GetElement(3));
            
            Console.WriteLine(lista.Contiene(null));  //true
            
            Console.WriteLine(lista.Contiene(7));  //true
            Console.WriteLine(lista.Contiene(88)); //false
            Console.WriteLine(lista.Contiene(10));  //true

            lista.Borrar(8);
            Console.WriteLine(lista.ToString());

            lista.Borrar(null);
            Console.WriteLine(lista.ToString()); 

            lista.Borrar("Hola");
            Console.WriteLine(lista.ToString());

            Console.WriteLine(lista.Contiene(10));  //true
            Console.WriteLine(lista.Contiene(55));  //false 

            Console.WriteLine("ITERADOR");

            IEnumerator<object> listaE = lista.GetEnumerator();
            while (listaE.MoveNext())
            {
                Console.WriteLine(listaE.Current);
            }

            listaE.Reset();
            listaE.MoveNext();
            Console.WriteLine(listaE.Current);

        }
    }
}
