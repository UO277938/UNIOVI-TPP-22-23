using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelo
{
    static public class FindFilterReduce
    {

        public static T Buscar<T>(this IEnumerable<T> collection, Predicate<T> func)
        {
            //collection.Select es el Map

            foreach (T d in collection)
            {
                if (func(d))
                    return d;
            }
            return default;
        }

        public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> collection, Predicate<T> func)
        {
            T[] result = new T[collection.Count()];
            uint i = 0;
            foreach (T d in collection)
            {
                if (func(d))
                    result[i] = d;
            }
            return result;
        }

        public static Q Reducir<T, Q>(this IEnumerable<T> collection, Func<Q, T, Q> func, Q start = default(Q))
        {
            Q acc = start;
            foreach (T e in collection)
            {
                acc = func(acc, e);
            }

            return acc;
        }

        public static IEnumerable<Q> Map<T, Q>(this IEnumerable<T> coleccion, Func<T, Q> func)
        {
            IList<Q> lista = new List<Q>();
            foreach (T actual in coleccion)
                lista.Add(func(actual));
            return lista;

        }


        static public void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }


    }

}

