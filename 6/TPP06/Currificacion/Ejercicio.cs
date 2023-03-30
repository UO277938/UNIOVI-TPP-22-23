
using System;
using System.Collections.Generic;

namespace Currificacion
{
    public static class Ejercicio
    {
        //Ejercicio 1..

        //Implementar de forma currificada el método Buscar entregado en la sesión anterior.
        //Demostrar el uso de su invocación y de la aplicación parcial.
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

        // Predictate<T> func
        static Func<Predicate<T>, T> BuscarC<T> (this IEnumerable<T> collection){
            return (func) =>
            {
                foreach (T d in collection)
                {
                    if (func(d))
                        return d;
                }
                return default;
            };
        }

        //Ejercicio 2.

        // Si - > 5 / 3 = 1 ; Resto = 2

        // Entonces -> 3 * 1 + 2 = 5;

        //Currifíquese la función y compruébese mediante el uso de la aplicación parcial el siguiente ejemplo:

        // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
        // Partiendo del valor 0, e incrementalmente, obténgase el resto.

        public static bool ComprobarDivision(int divisor, int dividendo, int cociente, int resto)
        {
            return dividendo == cociente * divisor + resto;
        }


        public static Func<int,Func<int,Func< int, bool>>> ComprobarDivisionCurry(int dividendo)
        {
            return (divisor) =>
            {
                return (cociente) =>
                {
                    return (resto) =>
                    {
                        return dividendo == cociente * divisor + resto;
                    };
                };
                    
            };
        }

    }
}
