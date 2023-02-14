using System;

namespace Biblioteca
{

    public enum Estaciones { Invierno = 0, Primavera = 1, Otoño = 2, Verano = 3 };

    public class SimuladorTiempo
    {
        DateTime _fecha;
        Estaciones _estacion;

        public DateTime Fecha { get { return _fecha; } }

        public Estaciones Estacion { get { return _estacion; } }

        public void AvanzarDias()
        {
            Random r = new Random();
            int aleatorio = r.Next(1, 12);

            DateTime f = _fecha;
            f = f.AddDays(aleatorio);
        }
        public void AvanzarMeses()
        {
            Random r = new Random();
            int aleatorio = r.Next(0, 4);

            DateTime f = _fecha;
            f = f.AddMonths(aleatorio);
        }

        void CalcularEstacion()
        {
            DateTime f = _fecha;
            if(f.Month >= 2 && f.Month <= 4)
            {
                _estacion = Estaciones.Primavera;
            }
            else if(f.Month >=5 && f.Month <= 7)
            {
                _estacion = Estaciones.Verano;
            }
            else if (f.Month >= 8 && f.Month <= 10)
            {
                _estacion = Estaciones.Otoño;
            }
            else
            {
                _estacion = Estaciones.Invierno;
            }
        }

        public override string ToString()
        {
            return $"{_fecha} {_estacion}";
        }

    }



}
