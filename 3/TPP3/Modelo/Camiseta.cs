using System;

#if DEBUG
using System.Diagnostics;
#endif

namespace Modelo
{
    public class Camiseta : Producto, IFacturable
    {
        
       public string Talla { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="autor"></param>
        /// <param name="título"></param>
        /// <param name="añoPublicacion"></param>
        /// <param name="puntuación">Opcional. null por defecto</param>
        public Camiseta(string nombre, string descripcion, uint stock, bool disponibilidad, string talla, string color):base(nombre, descripcion, stock, disponibilidad)
        {
            Talla = talla;
            Color = color;
        }

        public double GetBase()
        {
            throw new NotImplementedException();
        }

        public double DetTipoIva()
        {
            throw new NotImplementedException();
        }

        public double GetIva()
        {
            throw new NotImplementedException();
        }

        public double GetPrecio()
        {
            throw new NotImplementedException();
        }

        public string GetConcepto()
        {
            throw new NotImplementedException();
        }

        public string ToTicket()
        {
            throw new NotImplementedException();
        }
    }
}
