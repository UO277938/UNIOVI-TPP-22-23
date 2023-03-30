using System;
using System.Text;

#if DEBUG
using System.Diagnostics;
#endif

namespace ListaEnlazadaB
{

    public class Pila
    {
        private ListaEnlazada lista; //compposicion , creo 

        private uint NumeroMaxElementos;

        public bool EstaVacia { get { return lista.NElements == 0; } }
        public bool EstaLlena { get { return lista.NElements == NumeroMaxElementos; } }

        public Pila(uint NumeroMaxElementos)
        {
            if (NumeroMaxElementos == 0)
                throw new ArgumentException("Capacidad minima de la pila es 1.");

            this.NumeroMaxElementos=NumeroMaxElementos;
            lista = new ListaEnlazada();

#if DEBUG
            Invariante();
#endif

        }

        public bool Push(Object o)
        {
#if DEBUG
            Invariante();
#endif

            //PreCondicion
            if (lista.NElements == NumeroMaxElementos)
                throw new InvalidOperationException("La lista ya esta llena.");

            uint elementosAntes = lista.NElements;

            bool result = lista.Añadir(o);

#if DEBUG
            //PostCondicion
            Debug.Assert(lista.NElements == elementosAntes + 1, "Fallo en postcondición de Pila.Push");

            Invariante();
#endif

            return result;
        }

        public Object Pop(Func<bool> predicado)
        {
            Console.WriteLine("POP");
#if DEBUG
            Invariante();
#endif
            //Precondicion
            uint elementosAntes = lista.NElements;
            Console.WriteLine("NUMEROS ELEMENTOS: " + elementosAntes);
            if (elementosAntes == 0)
                throw new InvalidOperationException("No hay elementos para borrar.");
            object valorPop = lista.GetElement(elementosAntes-1);
            bool result;
            if (valorPop == null)
            {
                Console.WriteLine("ES NULO");
                result = lista.Borrar(null);
            }
            else
                result = lista.Borrar(valorPop);

#if DEBUG
            //PostCondicion
            Debug.Assert(lista.NElements == elementosAntes - 1, "Fallo en postcondición de Pila.Push");

            Invariante();
#endif

            return result;
        }

        public override string ToString()
        {
            return lista.ToString();
        }

#if DEBUG
        private void Invariante()
        {
            Debug.Assert(!(EstaVacia && EstaLlena), "Fallo en invariante de Pila.");
            //elementos mayor al maximo  / esta llena pero en realidad no maximo / esta vacia pero no son cero
            Debug.Assert(lista.NElements > NumeroMaxElementos, "Fallo invariante, intento de numero de elementos mayor que el maximo");

            if (EstaLlena) Debug.Assert(lista.NElements < NumeroMaxElementos, "Fallo invariante, en realidad no esta llena");

            if (EstaVacia) Debug.Assert(lista.NElements > 0, "Fallo invariante, en realidad no esta vacia");
        }
#endif


    }
}