using System;
using System.Diagnostics;
using System.IO;

namespace ObligatoriaSesion10
{
    class Program
    {
        /*
         * This program processes Bitcoin value information obtained from the
         * url https://api.kraken.com/0/public/OHLC?pair=xbteur&interval=5.
         */
        static void Main(string[] args)
        {

            const int maximoHilos = 50; //numero maximo de hilos

            var data = Utils.GetBitcoinData();
            double[] vector = new double[data.Length];
            for(int i = 0; i < data.Length; i++)
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
                double resultado = master.CalculaValoresSuperioresA(valorLimite);
                stopWatch.Stop();

                MostrarLinea(Console.Out, numeroHilos, stopWatch.ElapsedTicks, resultado);

                //Entre ejecuciones, limpiamos y esperamos.
                GC.Collect();
                GC.WaitForFullGCComplete();
            }
        }

        static void MostrarLinea(TextWriter stream, string numHilosCabecera, string ticksCabecera, string resultadoCabecera)
        {
            stream.WriteLine("{0};{1};{2}", numHilosCabecera, ticksCabecera, resultadoCabecera);
        }

        static void MostrarLinea(TextWriter stream, int numHilos, long ticks, double resultado)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numHilos, ticks, resultado);
        }
        }
}
