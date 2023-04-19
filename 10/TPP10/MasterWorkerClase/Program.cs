using System;
using System.Diagnostics;
using System.IO;

namespace MasterWorkerClase
{
    class Program
    {
        // A través de 2 arrays de enteros (el tamaño del 2º es <= al del 1º)
        // Calcular el número de veces que ses repite el 2º array en el primero.
        // Suponer que tendrá un máximo de longitudV1/longitudV2 hilos
        // Ejemplo:
        // { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 } y { 2, 2, 1}
        // Resultado: 3
        static void Main(string[] args)
        {
            const int maximoHilos = 50;//para tiempos
            int nHilos = 2;

            //short[] v1 = new short[] { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 };
            //short[] v2 = new short[] { 2, 2, 1 };

            //Probarlo posteriormente con el RandomVector.
            short[] v1 = CreateRandomVector(1000, 0, 4);
            short[] v2 = CreateRandomVector(2, 0, 4);

            Master master = new Master(v1, v2, nHilos);

            Console.WriteLine($"Numero de veces que se repite v2 en v1 con {nHilos} hilos: " + master.CalcularNumeroRepetidos());

            //Toma de tiempos dependiendo del numero de hilos
            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");

            Stopwatch stopWatch = new Stopwatch();

            for (int numeroHilos = 1; numeroHilos <= maximoHilos; numeroHilos++)
            {
                Master master3 = new Master(v1,v2, numeroHilos);
                stopWatch.Restart();
                double resultado = master3.CalcularNumeroRepetidos();
                stopWatch.Stop();

                MostrarLinea(Console.Out, numeroHilos, stopWatch.ElapsedTicks, resultado);

                //Entre ejecuciones, limpiamos y esperamos.
                GC.Collect();
                GC.WaitForFullGCComplete();
            }

            //Calculo de media de resultados con dos vectores aleatorios
            int nRepeticiones2 = 500;
            int nRepeticiones3 = nRepeticiones2;
            int accumulator = 0;
            while(nRepeticiones2 > 0)
            {
                short[] v3 = CreateRandomVector(1000, 0, 4);
                short[] v4 = CreateRandomVector(2, 0, 4);
                Master master2 = new Master(v1, v2, nHilos);
                accumulator += master.CalcularNumeroRepetidos();
                Console.WriteLine($"Ejecucion {nRepeticiones2}: {accumulator}");
                nRepeticiones2--;
                //Entre ejecuciones, limpiamos y esperamos.
                GC.Collect();
                GC.WaitForFullGCComplete();
            }
            double media = accumulator / nRepeticiones3;
            Console.WriteLine($"La media de {nRepeticiones3} ejecuciones fue: {media}");

        }

        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest)
        {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
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
