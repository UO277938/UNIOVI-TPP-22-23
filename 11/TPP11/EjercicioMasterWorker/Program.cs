using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EjercicioMasterWorker
{
    class Program
    {
        /// <summary>
        /// A partir del Master Worker de la entrega obligatoria, prueba las siguientes modificaciones:
        /// -Los workers almacenarán en una lista "Resultado", los valores que sean superiores a la cantidad buscada.
        ///     - No admitirá duplicados.
        ///     - La lista Resultado la pasa el Master a los workers y DEBE SER LA MISMA PARA TODOS LOS WORKERS.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const int maximoHilos = 50; //numero maximo de hilos

            var data = Utils.GetBitcoinData();
            double[] vector = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i].Value;  //vector
                //Console.WriteLine(vector[i]);
            }
            double valorLimite = 7000; //valor limite para el calculo
            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");

            //Toma de tiempos.
            Stopwatch stopWatch = new Stopwatch();

            for (int numeroHilos = 1; numeroHilos <= maximoHilos; numeroHilos++)
            {
                Master master = new Master(vector, numeroHilos);
                stopWatch.Restart();
                List<double> resultado = master.CalculaValoresSuperioresA(valorLimite);
                stopWatch.Stop();

                MostrarLinea(Console.Out, numeroHilos, stopWatch.ElapsedTicks, resultado.Count);

                //Entre ejecuciones, limpiamos y esperamos.
                GC.Collect();
                GC.WaitForFullGCComplete();

            }
        }

        static void MostrarLinea(TextWriter stream, string numHilosCabecera, string ticksCabecera, string resultadoCabecera)
        {
            stream.WriteLine("{0};{1};{2}", numHilosCabecera, ticksCabecera, resultadoCabecera);
        }

        static void MostrarLinea(TextWriter stream, int numHilos, long ticks, int resultado)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numHilos, ticks, resultado);
        }
    }
}
