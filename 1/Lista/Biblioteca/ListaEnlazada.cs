﻿using System.Text;

namespace ListaEnlazada
{

    public class ListaEnlazada
    {
        private Nodo _head;
        public int NElements = 0;

        private Nodo Head { get { return _head; } set { _head = value; } }

        public ListaEnlazada()
        {
            _head = null;
            NElements = 0;
        }

        public bool Añadir(object valor)
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

            Nodo aux = Head;
            //Nodo a buscar es la raiz
            if (Head.Value.Equals(valor))
            {
                Head = Head.NextNode;
                NElements--;
                return true;
            }

            //Si el nodo no es la raiz
            while(aux.NextNode != null)
            {
                if (aux.NextNode.Value.Equals(valor)) //Si el siguiente tiene el valor
                {
                    aux.NextNode= aux.NextNode.NextNode; //Cortamos su referencia, saltandolo
                    NElements--;
                    return true;
                }
                aux = aux.NextNode; //Seguimos buscando
            }
            //No hay nodo con ese valor
            return false;
        }

        public bool Contiene(object valor)
        {
            //No hay raiz, no hay nodos
            if (Head == null)
                return false;

            Nodo nodo = Head;
            if(nodo.Value.Equals(valor))
                return true;

            while (nodo.NextNode != null)
            {
                if (nodo.NextNode.Value.Equals(valor))
                    return true;

                nodo = nodo.NextNode;
            }
            return false;
        }

        public object GetElement(int posicion)
        {
            //Comprobamos que existe esa posicion en la lista
            if (posicion > NElements)
                return -1;

            Nodo aux = Head;
            int contador = 0; //Contador de posicion

            while(posicion>contador && aux.NextNode != null)
            {
                aux = aux.NextNode;

                contador++;
            }

            return aux.Value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lista: ");

            if (NElements <= 0)
                return "No hay Nodos.";
            Nodo aux = Head;

            int contador = 0;
            while(contador < NElements)
            {
                sb.Append(aux.ToString());
                aux = aux.NextNode;
                contador++;
            }
            return sb.ToString();
        }

    }


    public class Nodo
    {
        private object _value;
        private Nodo _nextNode;

        public object Value { get { return _value; } set { _value = value; } }
        public Nodo NextNode { get { return _nextNode; } set{ _nextNode = value; } }

        public Nodo(object value, Nodo siguiente)
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