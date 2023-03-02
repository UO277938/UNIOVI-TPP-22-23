using System;

#if DEBUG
using System.Diagnostics;
#endif

namespace Modelo
{
    public class Evento
    {
        
        public string Nombre { get; set; }

        public string Description { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="autor"></param>
        /// <param name="título"></param>
        /// <param name="añoPublicacion"></param>
        /// <param name="puntuación">Opcional. null por defecto</param>
        public Evento(string nombre, string description, DateTime fechaInicio, DateTime fechaFin)
        {
            Nombre = nombre;
            Description = description;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}
