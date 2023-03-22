using System;
using System.Collections.Generic;

namespace TPP07
{
    public static class Extensores
    {
        /// <summary>
        /// Método extensor de IEnumerable
        /// Transforma una colección de tipo T en una colección de tipo Q
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Q"></typeparam>
        /// <param name="coleccion"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<Q> Map<T, Q>(this IEnumerable<T> coleccion, Func<T, Q> func)
        {
            IList<Q> lista = new List<Q>();
            foreach (T actual in coleccion)
                lista.Add(func(actual));
            return lista;

        }


        static internal void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }

    }
}
