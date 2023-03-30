using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Lista
    {
        private int _numeroElementos;

        public int NumeroElementos { get { return _numeroElementos; } }

        // Cabeza de la lista
        private Nodo _head;

        public Lista()
        {
            _head = null;
            _numeroElementos = 0;
        }

        public void Añadir(object valor)
        {
            if (_numeroElementos == 0)
            {
                AñadirPrimero(valor);
            }
            else
            {
                Nodo ultimo = GetNodo(NumeroElementos - 1);
                ultimo.Siguiente = new Nodo(valor, null);
                _numeroElementos++;
            }
        }

        public void AñadirPrimero(object valor)
        {
            if (_head == null)
            {
                _head = new Nodo(valor, null);
                _numeroElementos++;
            }
            else
            {
                _head = new Nodo(valor, GetNodo(0));
                _numeroElementos++;
            }
        }

        public void AñadirPosicion(object valor, int posicion)
        {
            if (posicion < 0 || posicion >= NumeroElementos)
            {
                throw new IndexOutOfRangeException("No se puede borrar en una posicion ilegal, " +
                    "el valor tiene que estar entre 0 y " + (NumeroElementos - 1));
            }
            if (posicion == 0 || _head == null)
            {
                AñadirPrimero(valor);
            }
            else
            {
                Nodo anterior = GetNodo(posicion - 1);
                Nodo actual = GetNodo(posicion);
                anterior.Siguiente = new Nodo(valor, actual);
                _numeroElementos++;
            }
        }

        public bool BorrarPosicion(int posicion)
        {
            if (posicion < 0 || posicion >= NumeroElementos)
            {
                throw new IndexOutOfRangeException("No se puede borrar en una posicion ilegal, " +
                    "el valor tiene que estar entre 0 y " + (NumeroElementos - 1));
            }

            if (posicion == 0)
            {
                return BorrarPrimero();
            }
            else
            {
                Nodo aBorrar = GetNodo(posicion - 1);
                aBorrar.Siguiente = aBorrar.Siguiente.Siguiente;
                _numeroElementos--;
                return true;
            }
        }

        public bool Borrar(object valor)
        {
            for (int i = 0; i < NumeroElementos; i++)
            {

                if (GetNodo(i).Valor == null && valor == null)
                {
                    BorrarPosicion(i);
                    return true;
                }
                else if (GetNodo(i).Valor != null && GetNodo(i).Valor.Equals(valor))
                {
                    BorrarPosicion(i);
                    return true;
                }
            }
            return false;
        }

        public bool BorrarPrimero()
        {
            if (_head != null)
            {
                _head = _head.Siguiente;
                _numeroElementos--;
                return true;
            }
            else
            {
                throw new InvalidOperationException("No hay elementos en la lista");
            }

        }

        public override string ToString()
        {
            string cadena = "";
            for (int i = 0; i < NumeroElementos; i++)
            {
                if (GetNodo(i) != null)
                {
                    if (GetNodo(i).Siguiente != null)
                    {
                        if (GetNodo(i).Valor == null)
                        {
                            cadena += "null, ";
                        }
                        else
                        {
                            cadena += GetNodo(i).ToString() + ", ";
                        }
                    }
                    else
                    {
                        if (GetNodo(i).Valor == null)
                        {
                            cadena += "null";
                        }
                        else
                        {
                            cadena += GetNodo(i).ToString();
                        }
                    }
                }
            }

            return cadena;
        }

        private Nodo GetNodo(int posicion)
        {
            if (posicion < 0 || posicion > NumeroElementos)
            {
                throw new IndexOutOfRangeException("La posicion a la que se esta intentando acceder es invalida");
            }

            Nodo nodo = _head;
            for (int i = 0; i < posicion; i++)
            {
                nodo = nodo.Siguiente;
            }
            return nodo;
        }

        public object GetElemento(int posicion)
        {
            return GetNodo(posicion).Valor;
        }

        public bool Contiene(object valor)
        {
            for (int i = 0; i < NumeroElementos; i++)
            {
                if (valor == null && GetNodo(i).Valor == null)
                {
                    return true;
                }
                else if (GetNodo(i).Valor != null && GetNodo(i).Valor.Equals(valor))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
