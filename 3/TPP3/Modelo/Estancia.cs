using System;

#if DEBUG
using System.Diagnostics;
#endif

namespace Modelo
{
    public class Estancia : Evento
    {
        
        public uint NumParticipantes { get; set; }
        public bool IncluyeComida { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="autor"></param>
        /// <param name="título"></param>
        /// <param name="añoPublicacion"></param>
        /// <param name="puntuación">Opcional. null por defecto</param>
        public Estancia(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, uint numParticipantes, bool incluyeComida):base(nombre, descripcion, fechaInicio, fechaFin)
        {
            NumParticipantes = NumParticipantes;
            IncluyeComida = incluyeComida;
        }
    }
}
