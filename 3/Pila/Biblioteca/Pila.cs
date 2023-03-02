using System;
using System.Text;

#if DEBUG
using System.Diagnostics;
#endif

namespace ListaEnlazada
{

    public class Pila
    {
        public ListaEnlazada lista;

        public uint NumeroMaxElementos;

        public bool EstaVacía;
        public bool EstaLlena;

        public Pila(uint NumeroMaxElementos)
        {
            if (NumeroMaxElementos == 0)
                throw new ArgumentException("Capacidad minima de la pila es 1.");

            this.NumeroMaxElementos=NumeroMaxElementos;
            lista = new ListaEnlazada();
            EstaLlena = false;
            EstaVacía = true;

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

            if(result) EstaVacía = false;
            if(lista.NElements==NumeroMaxElementos) EstaLlena=true;
#if DEBUG
            //PostCondicion
            Debug.Assert(lista.NElements == elementosAntes + 1, "Fallo en postcondición de Pila.Push");

            Invariante();
#endif

            return result;
        }

        public Object Pop()
        {

#if DEBUG
            Invariante();
#endif
            //Precondicion
            uint elementosAntes = lista.NElements;
            if (elementosAntes == 0)
                throw new InvalidOperationException("No hay elementos para borrar.");

            bool result = lista.Borrar(lista.NElements - 1);

            if (result) EstaLlena = false;
            if(lista.NElements==0) EstaVacía=true;
            
#if DEBUG
            //PostCondicion
            Debug.Assert(lista.NElements == elementosAntes - 1, "Fallo en postcondición de Pila.Push");

            Invariante();
#endif

            return result;
        }

#if DEBUG
        private void Invariante()
        {
            if (lista.NElements == 0)
            {
                Debug.Assert(EstaVacía == true, "Error en la invariante.");
                Debug.Assert(EstaLlena == false, "Error en la invariante.");
            }

            if (lista.NElements>0)
                Debug.Assert(EstaVacía==false , "Error en la invariante.");

            
            if(lista.NElements == NumeroMaxElementos)
            {
                Debug.Assert( EstaLlena == true, "Error en la invariante.");
            }

        }
#endif


    }
}