using System;

#if DEBUG
using System.Diagnostics;
#endif

namespace Modelo
{
    public class Exhibicion : Evento
    {
        
       public uint NumAtletas { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="autor"></param>
        /// <param name="título"></param>
        /// <param name="añoPublicacion"></param>
        /// <param name="puntuación">Opcional. null por defecto</param>
        public Exhibicion(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, uint numAtletas):base(nombre, descripcion, fechaInicio, fechaFin)
        {
            NumAtletas = numAtletas;
        }
    }
}
