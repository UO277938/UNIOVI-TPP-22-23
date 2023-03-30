using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListaEnlazada
{

    public class ListaEnlazada<T> : IEnumerable<T>
    {
        private Nodo _head;
        public uint NElements { get; private set; }

        private Nodo Head { get { return _head; } set { _head = value; } }


        public ListaEnlazada()
        {
            _head = null;
            NElements = 0;
        }
        public ListaEnlazada(Nodo nodo)
        {
            Head = nodo;
            NElements++;
        }

        public bool Añadir(T valor)
        {
            Nodo nuevoNodo = new Nodo(valor, null);

            //Si no tiene raiz
            if (Head == null)
            {
                Head = nuevoNodo;
                NElements++;
                return true;
            }
            //Si ya tenia algun nodo
            Nodo aux = Head;
            while (aux.NextNode != null)
            {
                aux = aux.NextNode;
            }
            aux.NextNode = nuevoNodo;
            NElements++;
            return true;
        }

        public bool Borrar(object valor)
        {
            //No hay raiz, no hay nodos
            if (Head == null)
                return false;

            if (valor == null)
                return BorrarNull();

            Nodo aux = Head;
            //Nodo a buscar es la raiz
            if (Head.Value != null)
            {
                if (Head.Value.Equals(valor))
                {
                    Head = Head.NextNode;
                    NElements--;
                    return true;
                }
            }

            //Si el nodo no es la raiz
            while (aux.NextNode != null)
            {
                if (aux.NextNode.Value != null)
                {
                    if (aux.NextNode.Value.Equals(valor)) //Si el siguiente tiene el valor
                    {
                        aux.NextNode = aux.NextNode.NextNode; //Cortamos su referencia, saltandolo
                        NElements--;
                        return true;
                    }
                }
                aux = aux.NextNode; //Seguimos buscando
            }
            //No hay nodo con ese valor
            return false;
        }

        private bool BorrarNull()
        {
            Nodo aux = Head;
            //Nodo a buscar es la raiz
            if (Head.Value == null)
            {
                Head = Head.NextNode;
                NElements--;
                return true;
            }

            //Si el nodo no es la raiz
            while (aux.NextNode != null)
            {
               if (aux.NextNode.Value == null) //Si el siguiente tiene el valor
                    {
                        aux.NextNode = aux.NextNode.NextNode; //Cortamos su referencia, saltandolo
                        NElements--;
                        return true;
                }
                aux = aux.NextNode; //Seguimos buscando
            }
            //No hay nodo con ese valor
            return false;
        }

        public bool Contiene(T valor)
        {
            //No hay raiz, no hay nodos
            if (Head == null)
                return false;

            if(valor == null)
                return ContineNull();

            Nodo nodo = Head;
            if(nodo.Value != null)
                if (nodo.Value.Equals(valor))
                    return true;

            while (nodo.NextNode != null)
            {
                if (nodo.NextNode.Value != null)
                    if (nodo.NextNode.Value.Equals(valor))
                        return true;

                nodo = nodo.NextNode;
            }
            return false;
        }

        private bool ContineNull()
        {
            Nodo nodo = Head;
            if (nodo.Value == null)
                return true;

            while (nodo.NextNode != null)
            {
                if (nodo.NextNode.Value == null)
                    return true;

                nodo = nodo.NextNode;
            }
            return false;
        }

        public object GetElement(uint posicion)
        {
            //Comprobamos que existe esa posicion en la lista
            if (posicion > NElements - 1)
                //throw new ArgumentException("Fuera de rango");
                return null;

            Nodo aux = Head;
            int contador = 0; //Contador de posicion

            while (posicion > contador && aux.NextNode != null)
            {
                aux = aux.NextNode;

                contador++;
            }

            return aux.Value;
        }

        public override string ToString()
        {
            if (NElements <= 0)
                return "No hay Nodos.";
            Nodo aux = Head;

            StringBuilder sb = new StringBuilder();
            sb.Append("Lista: ");

            int contador = 0;
            while (contador < NElements)
            {
                sb.Append(aux.ToString());
                aux = aux.NextNode;
                contador++;
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListaIEnumerator(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /*public Func<T> ClausuraIEnumerator(IEnumerable<T> lista, out Func<bool> moveNext, out Action reset, out Action dispose)
        {
            List<T> list = new List<T>();
            foreach(var item in lista)
            {
                list.Add(item);
            }

            T actual = list[0];
            int index = 0;

            moveNext = () =>
            {
                if(list[index] != null)
                {
                    actual = list[index];
                    index++;
                    return true;
                }
                return false;
            };

            reset = () =>
             {
                 index = 0;
             };

            dispose = () => { };

            return () =>
            {
                return actual;
            };
        }*/


        public class ListaIEnumerator : IEnumerator<T>
        {
            private Nodo _head;

            private Nodo _actual = null; //Iterador por asi decirlo

            private Nodo Head { get { return _head; } set { _head = value; } }

            public ListaIEnumerator(Nodo head)
            {
                this.Head = head;
            }

            public T Current
            {
                get { return _actual.Value; }
            }

            object IEnumerator.Current {
                get {
                    return _actual.Value; 
                }
            }            

            public bool MoveNext()
            {
                if (_actual == null)
                {
                    _actual = Head;
                    return true;
                }

                if(_actual.NextNode == null)
                    return false;
                _actual = _actual.NextNode;
                return true;
            }

            public void Reset()
            {
                this._actual = null;
            }

            public void Dispose()
            {
                
            }
        }


        public class Nodo
        {
            private T _value;
            private Nodo _nextNode;

            public T Value { get { return _value; } set { _value = value; } }
            public Nodo NextNode { get { return _nextNode; } set { _nextNode = value; } }

            public Nodo(T value, Nodo siguiente)
            {
                Value = value;
                NextNode = siguiente;
            }

            public override string ToString()
            {
                return "[" + Value + "] ";
            }
        }
    }


    
}