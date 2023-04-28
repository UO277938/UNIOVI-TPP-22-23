using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EjercicioProductorConsumidor
{
    class Consumidor
    {

        private Queue<Producto> cola;

        private static readonly object objeto = new object();

        public Consumidor(Queue<Producto> cola)
        {
            this.cola = cola;
        }

        public void Run()
        {
            Random random = new Random();
            while (true)
            {
                lock (objeto)
                {
                    Console.WriteLine("- Sacando producto...");
                    //while (cola.Count == 0)
                    //    Thread.Sleep(100);
                    Producto producto = null;
                    if (cola.Count > 0)
                    {
                        producto = cola.Dequeue();
                        Console.WriteLine("- Producto sacado: {0}.", producto);
                    }
                }
                Thread.Sleep(random.Next(300, 700));
            }
        }

    }
}
