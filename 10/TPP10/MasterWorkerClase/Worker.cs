using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterWorkerClase
{
    internal class Worker
    {

        /// <summary>
        /// Vector del que vamos a obtener el módulo
        /// </summary>
        private short[] vector;

        //Vector que buscamos
        private short[] vectorSearch; 

        /// <summary>
        /// Índices que indican el rango de elementos del vector 
        /// con el que vamos a trabajar.
        /// En el intervalo se incluyen ambos índices.
        /// </summary>
        private int indiceDesde, indiceHasta;

        /// <summary>
        /// Resultado del cálculo
        /// </summary>
        private int resultado;

        internal int Resultado
        {
            get { return this.resultado; }
        }

        internal Worker(short[] vector, short[] vectorSearch, int indiceDesde, int indiceHasta)
        {
            this.vector = vector;
            this.indiceDesde = indiceDesde;
            this.indiceHasta = indiceHasta;
            this.vectorSearch = vectorSearch;
        }

        /// <summary>
        /// Método que realiza el cálculo
        /// </summary>
        internal void Calcular()
        {
            this.resultado = 0;
            int longitud = vectorSearch.Length;
            for (int i = this.indiceDesde; i <= this.indiceHasta; i++)
            {
                //inicializamos vector del tañado del que comparamos
                short[] vectorS = new short[longitud];
                //obtenemos los desde el que estamos hasta el tamaño de la busqueda
                try
                {
                    vectorS = vector.Skip(i).Take(longitud).ToArray();
                } catch (ArgumentNullException)
                {
                    Console.WriteLine("Llegamos final array, no se puede buscar del tamaño.");
                }

                if (vectorS.SequenceEqual(vectorSearch))
                {
                    this.resultado++;
                }

            }
            
        }

    }
}
