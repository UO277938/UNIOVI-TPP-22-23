
using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    public static class Extensor
    {

        public static IDictionary<T1, List<T>> ToFilteredDict<T, T1>(this IEnumerable<T> coleccion, Func<T, T1> clave, Predicate<T> predicate)
        {

            IDictionary<T1, List<T>> diccionario = new Dictionary<T1, List<T>>();


            foreach (var e in coleccion)
            {
                if (predicate(e))
                {
                    if (diccionario.ContainsKey(clave(e)))
                    {
                        diccionario[clave(e)].Add(e);
                    } else
                    {
                        List<T> lista = new List<T>();
                        diccionario.Add(clave(e), lista );
                        diccionario[clave(e)].Add(e);
                    }
                }
            }

            return diccionario;
        }
    }
}
