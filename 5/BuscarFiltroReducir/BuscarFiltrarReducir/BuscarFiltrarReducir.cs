using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelo
{
    static public class FindFilterReduce
    {

        static T Buscar<T>(this IEnumerable<T> collection, Predicate<T> func)
        {
            //collection.Select es el Map

            foreach (T d in collection)
            {
                if (func(d))
                    return d;
            }
            return default;
        }

        static IEnumerable<T> Filtrar<T>(this IEnumerable<T> collection, Predicate<T> func)
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

        static Q Reducir<T, Q>(this IEnumerable<T> collection, Func<Q, T, Q> func, Q start = default(Q))
        {
            Q acc = start;
            foreach (T e in collection)
            {
                acc = func(acc, e);
            }

            return acc;
        }


    }

}

