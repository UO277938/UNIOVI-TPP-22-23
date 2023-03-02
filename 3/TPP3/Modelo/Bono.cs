using System;

#if DEBUG
using System.Diagnostics;
#endif

namespace Modelo
{
    public class Bono : Producto
    {
        
       public uint Minutos { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="autor"></param>
        /// <param name="título"></param>
        /// <param name="añoPublicacion"></param>
        /// <param name="puntuación">Opcional. null por defecto</param>
        public Bono(string nombre, string descripcion, uint stock, bool disponibilidad, uint minutos):base(nombre, descripcion, stock, disponibilidad)
        {
            Minutos = minutos;
        }
    }
}
