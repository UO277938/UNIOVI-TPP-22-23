using System;

namespace ListaEnlazada
{

    internal class Consola
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            lista.Añadir(7); //HEAD
            lista.Añadir("Hola"); 
            lista.Añadir(7.55);

            Console.WriteLine(lista.ToString());

            Console.WriteLine(lista.GetElement(1));
            Console.WriteLine(lista.GetElement(2));
            Console.WriteLine(lista.GetElement(3));

            Console.WriteLine(lista.Contiene("Hola"));  //true
            Console.WriteLine(lista.Contiene(7.55));  //true 

            lista.Borrar(7.55);
            Console.WriteLine(lista.ToString());

            lista.Borrar(7);
            Console.WriteLine(lista.ToString());

            lista.Borrar("Hola");
            Console.WriteLine(lista.ToString());

            Console.WriteLine(lista.Contiene("Hola"));  //false
            Console.WriteLine(lista.Contiene(7.55));  //false 

        }
    }


}
