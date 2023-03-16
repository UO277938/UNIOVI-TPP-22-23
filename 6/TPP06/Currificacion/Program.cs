﻿using System;

namespace Currificacion
{
    public static class Program
    {
        static void Main()
        {
            //La currificación es una técnica que consiste en transformar
            //una función que recibe N parámetros en una que recibe un ÚNICO parametro.

            //La función recibe un parámetro
            //y devuelve una clausura que pide el siguiente parámetro
            //y devuelve una clausura... Así hasta completar la operación (devolviendo un valor).

            Suma(3, 5); // No es una función currificada.

            //SumaCurrificada me devuelve la cláusula SumaTres ¿Guarda estado?

            Func<int, int> SumaTres = SumaCurrificada(3);

            //SumaTres(4) ya devuelve el valor buscado. Si hubiera un tercer valor...
            //Tendríamos otra clausura y así sucesivamente.

            int resultado = SumaTres(4); //3 + 4

            //o directamente:
            resultado = SumaCurrificada(3)(4);
            Console.WriteLine("Invocación currificada: {0}", resultado);


            //La currificación permite hacer uso de la aplicación parcial:
            //Paso de menor número de parámetros en la invocación 

            Console.WriteLine("Aplicación parcial: {0}", SumaTres(20));
            Console.WriteLine("Aplicación parcial: {0}", SumaTres(100));

            //¿Qué ventajas presenta la aplicación parcial?


            System.Console.WriteLine(Ejercicio.ComprobarDivision(3, 5, 1, 2));
            System.Console.WriteLine(Ejercicio.ComprobarDivisionCurry(5)(3)(1)(2));

            Func<int, bool> buscarResto = Ejercicio.ComprobarDivisionCurry(20)(6)(3);

            int resto = 0;
            while (!buscarResto(resto))
            {
                resto++;
            } Console.WriteLine("El resto es: " + resto);

        }

        static int Suma(int a, int b)
        {
            return a + b;
        }

        // int b
        static Func<int,int> SumaC(int a)
        {
           return b => a + b;
        }


        /// <summary>
        /// En esta función establecemos TODA la currificación
        /// </summary>
        /// <param name="a">Primer parámetro</param>
        /// <returns>Devuelve la clausura que solicita el siguiente valor</returns>
        static Func<int, int> SumaCurrificada(int a)
        {
            //Clausura: Func que nos pide el parámetro b y guarda la referencia de a.
            return b => a + b;
        }
    }
}
