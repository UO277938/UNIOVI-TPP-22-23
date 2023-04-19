using System;

using System.Threading;

namespace HilosFuncional
{
    class Program
    {
        static void Main(string[] args)
        {

            // En el ejemplo HilosPOO, el método Run de cada Expositor no recibía parámetros.
            // De hecho, utilizábamos el propio objeto Expositor para encapsular los datos (valor y nVeces).
            // El/Los parámetro/s lo encapsulábamos como atributo/s de una clase.

            // A continuación veremos los casos desde un enfoque más funcional.

            //Thread recibe en su constructor cualquier Action con 0 o 1 parámetros de tipo object.

            Thread hiloParametrizado = new Thread(ObtenerDatos);

            //En el método Start pasamos el parámetro (si es necesario).
            hiloParametrizado.Start("wwww.google.es");


            //También podríamos utilizar directamente una expresión lambda:
            Thread hiloSuelto = new Thread(
                     valor =>
                     {
                         Console.WriteLine("El hilo suelto recibe " + valor);
                     }
             );
            hiloSuelto.Start("Declarando el action directamente"); //parametro


            //¿Y si necesitamos más parámetros? Variables libres.

            //Vamos a crear 4 hilos.
            //Cada hilo debería imprimir un par de valores: 40 y 41, 41 y 42, 42 y 43, 43 y 44... En cualquier orden.

            //EJERCICIO: ¿Cómo arreglamos esto?
            
            Thread[] hilos = new Thread[4];
            //int numero = 40;
            string holi = "taluego";
            for (int i = 0; i < 4; i++)
            {
                int valorImprime = 40 + (2 * i);
                hilos[i] = new Thread(
                    () =>
                        {
                            Console.WriteLine($"{valorImprime} {valorImprime+1} {holi + valorImprime}");
                        }
                    );
                hilos[i].Start();
            }
            //Console.WriteLine($"{numero}");

            //EJERCICIO: Empleando un enfoque funcional, impleméntese la funcionalidad del ejercicio Expositor de HilosPOO.

            Thread[] hilos2 = new Thread[4];
            
            for (int i = 0; i < hilos2.Length; i++)
            {
                int nVeces = i + 1;
                int valor = i;
                int j = 0;
                
                hilos2[i] = new Thread(
                    () =>
                    {
                        Console.WriteLine("Comienza el hilo ID={0} que escribirá {1} veces cada 2000ms. (mínimo)", Thread.CurrentThread.ManagedThreadId, nVeces);
                        while (j < nVeces)
                        {
                            Thread.Sleep(2000);
                            Console.WriteLine("Ejecución {0} del hilo [ID={1}; NOMBRE={2}; PRIORIDAD={3}] con valor {4}",
                                j, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name, Thread.CurrentThread.Priority, valor);
                            j++;
                        }
                        Console.WriteLine($"Fin del hilo ID = {Thread.CurrentThread.ManagedThreadId}.");
                    }
                    );
                //Parámetros opcionales.
                hilos2[i].Name = "Hilo número: " + i; //Nombre del hilo.
                hilos2[i].Priority = ThreadPriority.Normal; //Prioridad
                hilos2[i].Start();
            }
        }
        // 0 o 1 parametro, si hay es de object
        public static void ObtenerDatos(object valor)
        {
            Console.WriteLine("Obteniendo datos del destino {0}", valor);
            //Simulamos carga de trabajo, fines demostrativos.
            Thread.Sleep(2000);
            Console.WriteLine("Datos obtenidos y almacenados");

        }
    }
}
