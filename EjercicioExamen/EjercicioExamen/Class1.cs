using System;
using System.Collections;
using System.Collections.Generic;

namespace EjercicioExamen
{
    public static class Class1
    {

        public static IEnumerable<(T,int)> ContarIguales<T>(this IEnumerable<T> cadena)
        {
            var ret = new Dictionary<T, int>();
            var iterator = cadena.GetEnumerator();
            while (iterator.MoveNext())
            {
                T key = iterator.Current;
                try
                {
                    ret[key] = ret[key] + 1;
                } catch (Exception ex)
                {
                    ret[key] = 1;
                }
            }

            List<(T, int)> list = new List<(T, int)>();
            var iteradorDiccionario = ret.GetEnumerator();
            while (iteradorDiccionario.MoveNext())
            {
                KeyValuePair<T,int> claveValor = iteradorDiccionario.Current;
                list.Add((claveValor.Key, claveValor.Value));
            }
            return list;

        }
    }
}
