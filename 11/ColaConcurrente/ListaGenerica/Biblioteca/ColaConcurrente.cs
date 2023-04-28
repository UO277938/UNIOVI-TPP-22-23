using ListaEnlazada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaConcurrente
{
    public class ColaConcurrente<T>
    {
        private ListaEnlazada<T> lista;

        public uint NumeroElementos;

        public bool EstaVacia { get { return lista.NElements == 0; } }

        public ColaConcurrente()
        {
            lista = new ListaEnlazada<T>();
        }

        public bool Añadir(T elemento)
        {
            lock(lista){
                bool ret = lista.Añadir(elemento);
                if (ret) NumeroElementos++;
                return ret;
            }
            
        }

        public bool Extraer()
        {
            lock (lista)
            {
                bool ret = lista.Borrar(lista.GetElement(0));
                if (ret) NumeroElementos--;
                return ret;
            }
        }

        public object PrimerElemento()
        {
            lock(lista)
                return lista.GetElement(0);
        }
    }
}
