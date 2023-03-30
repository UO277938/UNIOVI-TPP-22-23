using System;

namespace Ejercicio1
{

    public class Program
    {
        static void Main(string[] args)
        {

            Pila pila = new PilaSerie(3);

            Lista añadir = new Lista();
            añadir.Añadir(1);
            añadir.Añadir(8);
            añadir.Añadir(1);

            añadir.Añadir(8);

            Console.WriteLine("Han quedado " + pila.PushSerie(añadir));

            Console.WriteLine(pila.PopSerie(n => n.Equals(1)).ToString());

            pila.PopSerie(null);

        }
    }  
}
