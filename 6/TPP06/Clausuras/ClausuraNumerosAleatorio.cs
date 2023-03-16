
using System;

namespace Clausuras
{
    public static class ClausuraNumerosAleatorios
    {
        public static Func<int> CrearNumerosAleatorios(int rango, out Func<bool> reset, out Action<int> setInicial)
        {
            //Se define el estado
            int _rango = rango;
            int inicial = rango;

            //Funciones a definir
            Random rand = new Random();

            reset =() =>
             {
                 _rango = inicial;
                 Console.WriteLine("RESET");
                 return true;
             };

            setInicial = (valor) =>
            {
                inicial = valor;
                Console.WriteLine("NUEVO VALOR INICIAL: " + valor);
            };


            return () =>
            {
                if(_rango<=0)
                {
                    _rango = inicial;
                    Console.WriteLine("VOLVEMOS A INICIAL: " + _rango);
                }
                _rango = rand.Next(0, _rango);
                Console.WriteLine("NUEVO VALOR: " + _rango);
                return _rango;
            };

        }
    }
}
