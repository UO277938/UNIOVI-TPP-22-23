using System;

#if DEBUG
using System.Diagnostics;
#endif

namespace Modelo
{
    public class Producto
    {
        
        public string Nombre { get;  }

        public string Description { get; set; }

        public uint Stock { get; set; }

        public bool Disponibilidad { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="autor"></param>
        /// <param name="título"></param>
        /// <param name="añoPublicacion"></param>
        /// <param name="puntuación">Opcional. null por defecto</param>
        public Producto(string nombre, string description, uint stock, bool disponibilidad)
        {
            Nombre = nombre;
            Description = description;
            Stock = stock;
            Disponibilidad = disponibilidad;
        }

        public void Reponer(uint unidades)
        {

            Stock += unidades;
            Invariante();
        }

        public void Comprar(uint unidades)
        {
            if(Stock<unidades)
                throw new ArgumentException("No hay suficiente stock.");

            Stock -= unidades;
            Invariante();
        }

#if DEBUG
        private void Invariante()
        {
            Debug.Assert(Stock>0 && !Disponibilidad, "Error en la invariante.");

        }
#endif
    }
}
