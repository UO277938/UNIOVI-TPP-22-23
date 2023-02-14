using System;
using Biblioteca;

namespace Consola
{
    internal class Cultivo
    {
        static void Main(string[] args)
        {
            SimuladorTiempo simulador = new SimuladorTiempo();
            Console.WriteLine("Hello World!");
        }

        private Estaciones _cosecha;

        private Estaciones Cosecha { get { return _cosecha; } }

        public int _ritmoCrecimiento;

        public int RitmoCrecimiento { get { return _ritmoCrecimiento; } }

        private int _crecimiento;
        private int Crecimiento { get { return _crecimiento; } }

        private int _cantidad;
        private int Cantidad { get { return _cantidad; } }

        public bool _muerto;
        public bool Muerto { get { return _crecimiento < 0; } }

        private string _identificador;
        private string Identificador { get { return _identificador; } }

        private void Regar(Estaciones actual)
        {
            if (_muerto)
                return;

            _crecimiento = _crecimiento + _ritmoCrecimiento;
        }

        private int Cosechar(Estaciones actual)
        {


            if (_muerto)
                return -1;

            Random r = new Random();
            int n = _crecimiento * 2;

            _crecimiento = _crecimiento - r.Next(0, n+1);

            if( actual == _cosecha)
            {
                int num1 = _cantidad * 2;
                int num2 = _cantidad * 5;

                return r.Next(n, num2);
            }
            else
            {
                return r.Next(_cantidad, n);
            }
        }
    }
}
