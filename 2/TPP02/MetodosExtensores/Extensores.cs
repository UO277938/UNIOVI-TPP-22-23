
using System;

namespace MetodosExtensores
{
    public enum Estaciones { Invierno = 0, Primavera = 1, Verano = 2, Otoño = 3 };

    /// <summary>
    /// Los métodos extensores están contenidos en clases estáticas.
    /// </summary>
    public static class Extensores
    {
        /// <summary>
        /// Los métodos extensores son métodos estáticos.
        /// Afectan a la clase que se establece después del this
        /// En este caso, extendemos string con el método ContarVocalesSinTilde
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Número de vocales sin tilde</returns>
        public static int ContarVocalesSinTilde(this string texto) //prueba.ContarVo..
        {
            int resultado = 0;
            foreach (char letra in texto)
                if ("aeiouAEIOU".Contains(letra))
                    resultado++;
            return resultado;

        }


        public static int ContarNumeroVecesLetra(this string texto, char letraBuscar)
        {
            int contador = 0;
            foreach (char letra in texto)
                if (letraBuscar == letra)
                    contador++;
            return contador;
        }

        public static string Estacion(this DateTime estacion)
        {
            int mes = DateTime.Today.Month;
            if (mes >= 12 && mes < 3)
            {
                return "Invierno";
            }
            else if (mes >= 4 && mes < 6)
                return "Primavera";
            else if (mes >= 6 && mes < 9)
                return "Verano";
            return "Otoño";
        }

        public static int Sum(this ListaEnlazada lista)
        {
            int ret = 0;
            int n = lista.NElements;
            for(int i = 0; i < n; i++)
            {
                ret += lista.GetElement(i);
            }
            return ret;
        }
    }
}
