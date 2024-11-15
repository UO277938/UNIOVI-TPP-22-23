﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriaSesion10
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

        /// <summary>
        /// Resultado del cálculo
        /// </summary>
        private long resultado;

        internal long Resultado
        {
            get { return this.resultado; }
        }

        internal Worker(double[] vector, double valorPrefijado, int indiceDesde, int indiceHasta)
        {
            this.vector = vector;
            this.indiceDesde = indiceDesde;
            this.indiceHasta = indiceHasta;
            this.valorPrefijado = valorPrefijado;
        }

        /// <summary>
        /// Método que realiza el cálculo
        /// </summary>
        internal void Calcular()
        {
            this.resultado = 0;
            for (int i = this.indiceDesde; i <= this.indiceHasta; i++)
                if(vector[i] > valorPrefijado)
                {
                    resultado++;
                }
        }

    }
}
