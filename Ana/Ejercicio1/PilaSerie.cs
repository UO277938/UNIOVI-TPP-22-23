using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class PilaSerie : Pila
    {

        public PilaSerie(uint numeroElementos):base(numeroElementos)
        {
            

#if DEBUG
            Invariante();
#endif
        }

        public Lista PopSerie(Predicate<object> condicion)
        {
            if(condicion == null)
            {
                throw new InvalidOperationException("No se puede pasar una condicion null");
            }

#if DEBUG
            Invariante();
            int contadorEliminar = 0;
#endif

            Lista devolver = new Lista();
            Lista añdir = new Lista();
            object aux = null;
            if (EstaVacia)
            {
                return devolver;
            } else
            {
                while(!EstaVacia)
                {
                    aux = Pop();

                    if (condicion(aux))
                    {
                        devolver.Añadir(aux);
#if DEBUG
                        contadorEliminar++;
#endif
                    }
                    else
                    {
                        añdir.Añadir(aux);
                    }
                }
            }

            if (EstaVacia)
            {
                PushSerie(añdir);
            }
#if DEBUG
            Invariante();
            Debug.Assert(devolver.NumeroElementos == _numero, "Hay una inconsistencia con la cantiada de elementos");
            Debug.Assert(devolver == null, "Hay una inconsistencia con la creacion del elemento");
#endif
            return devolver;
        }

        public int PushSerie(Lista elementos)
        {
            if (elementos == null)
            {
                throw new InvalidOperationException("No se puede pasar una condicion null");
            }

#if DEBUG
            Invariante();
#endif

            int cont = 0;
            if (EstaLlena)
            {
                return elementos.NumeroElementos;
            } else
            {
                
                for(int i = 0; i < elementos.NumeroElementos; i++)
                {
                    if (EstaLlena)
                    {
                        Push(elementos.GetElemento(i));
                        cont++;
                        _numero++;
                    }
                }
            }

#if DEBUG
            Invariante();
            
#endif

            return elementos.NumeroElementos - cont;
        }
    }
}
