using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMasterWorker
{
    internal class Worker
    {

        /// <summary>
        /// Vector del que vamos a obtener el módulo
        /// </summary>
        private double[] vector;

        /// <summary>
        /// Índices que indican el rango de elementos del vector 
        /// con el que vamos a trabajar.
        /// En el intervalo se incluyen ambos índices.
        /// </summary>
        private int indiceDesde, indiceHasta;
        private double valorPrefijado;

        private static readonly object objeto = new object();

        private List<double> resultado;

        internal List<double> Resultado
        {
            get { return this.resultado; }
        }

        internal Worker(double[] vector, double valorPrefijado, List<double> resultado, int indiceDesde, int indiceHasta)
        {
            this.vector = vector;
            this.indiceDesde = indiceDesde;
            this.indiceHasta = indiceHasta;
            this.valorPrefijado = valorPrefijado;
            this.resultado = resultado;
        }

        /// <summary>
        /// Método que realiza el cálculo
        /// </summary>
        internal void Calcular()
        {
            for (int i = this.indiceDesde; i <= this.indiceHasta; i++)
                if(vector[i] > valorPrefijado)
                {
                    lock (objeto)
                    {
                        if (!resultado.Contains(vector[i]))
                            resultado.Add(vector[i]);
                    }
                }
        }

    }
}
