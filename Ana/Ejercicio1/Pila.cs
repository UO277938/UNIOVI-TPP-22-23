using System;
using System.Diagnostics;


namespace Ejercicio1
{
    public class Pila
    {
        private Lista _lista;

        private uint _numeroMaxElementos;

        public bool EstaVacia { get { return _lista.NumeroElementos == 0; } }

        public bool EstaLlena { get { return _lista.NumeroElementos == _numeroMaxElementos; } }

        public Pila(uint numeroMaxElementos)
        {
            if (numeroMaxElementos <= 0)
                throw new ArgumentOutOfRangeException("El numero de elementos que tiene que contener la pila tiene que ser superior a 0");

            _numeroMaxElementos = numeroMaxElementos;
            _lista = new();

#if DEBUG
            Invariante();
#endif
        }


        public void Push(object objeto)
        {
#if DEBUG
            Invariante();
            int cantidadPrevia = _lista.NumeroElementos;
#endif
            if (EstaLlena)
                throw new InvalidOperationException("La pila esta llena, no se pueden añadir mas elementos");

            _lista.Añadir(objeto);

#if DEBUG
            Debug.Assert(_lista.NumeroElementos == cantidadPrevia + 1, "Da fallo al añadir un nuevo elementos");
            Invariante();
#endif
        }

        public object Pop()
        {
#if DEBUG
            Invariante();
            int cantidadPrevia = _lista.NumeroElementos;
#endif
            if (EstaVacia)
                throw new InvalidOperationException("La pila esta vacia, no se pueden borrar elementos");

            object devolver = _lista.GetElemento(_lista.NumeroElementos - 1);
            _lista.BorrarPosicion(_lista.NumeroElementos - 1);

#if DEBUG
            Debug.Assert(_lista.NumeroElementos == cantidadPrevia - 1, "Da fallo al eleminar un elemento");
            Invariante();
#endif

            return devolver;
        }

        internal void Invariante()
        {
            Debug.Assert(!(EstaVacia && EstaLlena), "La pila no puede esta vacia y llena a la vez");

            // En el caso de que la pila este vacia, el numero de elementos tiene que ser 0
            if (EstaVacia)
                Debug.Assert(_lista.NumeroElementos == 0, "La lista esta vacia, pero tiene elementos en ella");

            // En el caso de que la pila NO vacia y NO llena, el numero de elementos tiene que ser > 0
            if (!EstaVacia)
                Debug.Assert(_lista.NumeroElementos > 0, "La lista esta vacia, pero NO contiene elementos");

            // No se puede superar el numero de elementos maximos
            Debug.Assert(_lista.NumeroElementos <= _numeroMaxElementos, "Hay mas elementos en la pila que la cnatidad maxiam indicada");

            if (EstaLlena)
                Debug.Assert(_lista.NumeroElementos == _numeroMaxElementos, "La pila esta llena, pero la cantidad de elementos no coincide con los que hay en la lista");

            if (!EstaLlena)
                Debug.Assert(_lista.NumeroElementos < _numeroMaxElementos, "La lista no esta llena, pero el numero de elemntoss no es menor que el maximo");
        }
    }
}
