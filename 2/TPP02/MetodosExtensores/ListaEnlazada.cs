using System.Text;

namespace MetodosExtensores
{

    public class ListaEnlazada
    {
        private Nodo _head;
        public int NElements = 0;

        public Nodo Head { get { return _head; } set { _head = value; } }

        public ListaEnlazada()
        {
            _head = null;
            NElements = 0;
        }

        public void Añadir(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor, null);

            //Si no tiene raiz
            if (Head == null)
            {
                Head = nuevoNodo;
                NElements++;
                return;
            }
            //Si ya tenia algun nodo
            Nodo aux = Head;
            while (aux.NextNode != null)
            {
                aux = aux.NextNode;
            }
            aux.NextNode = nuevoNodo;   
            NElements++;
        }

        public bool Borrar(int valor)
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

        public int GetElement(int posicion)
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
        private int _value;
        private Nodo? _nextNode;

        public int Value { get { return _value; } set { _value = value; } }
        public Nodo NextNode { get { return _nextNode; } set{ _nextNode = value; } }

        public Nodo(int value, Nodo siguiente)
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