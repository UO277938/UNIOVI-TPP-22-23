﻿using System;

namespace ListaEnlazadaB
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

            Console.WriteLine(lista.GetElement(0));
            Console.WriteLine(lista.GetElement(1));
            Console.WriteLine(lista.GetElement(2));
            Console.WriteLine(lista.GetElement(3));

            Console.WriteLine(lista.Contiene(7));  //true
            Console.WriteLine(lista.Contiene("Hola"));  //true
            Console.WriteLine(lista.Contiene(7.55));  //true 

            Console.WriteLine(lista.Contiene("Lucas"));  //false
            Console.WriteLine(lista.Contiene(4));  //false
            Console.WriteLine(lista.Contiene(0.88));  //false

            lista.Borrar(7.55);
            Console.WriteLine(lista.ToString());

            lista.Borrar(7);
            Console.WriteLine(lista.ToString()); 

            lista.Borrar("Hola");
            Console.WriteLine(lista.ToString()); //No hay nodos

            Console.WriteLine(lista.Contiene("Hola"));  //false
            Console.WriteLine(lista.Contiene(7.55));  //false 

            Console.WriteLine("-----PILA");
            Pila pila = new Pila(5);
            pila.Push(7);
            pila.Push(null);
            pila.Push("Hola");


            Console.WriteLine(pila.ToString());

            Console.WriteLine(pila.Pop().ToString());

            Console.WriteLine(pila.ToString());

            Console.WriteLine(pila.Pop().ToString());

            Console.WriteLine(pila.ToString());

            Console.WriteLine(pila.Pop().ToString());

            Console.WriteLine(pila.ToString());

        }
    }
}
