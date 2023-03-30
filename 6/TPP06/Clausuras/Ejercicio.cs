
using System;

namespace Clausuras
{
    public static class Ejercicio
    {
        /* Examen 21/22
        
        Ejercicio 1 (A – 1,50 puntos).

            Dado un valor inicial, impleméntese una clausura que, en cada invocación,
            devuelva un número aleatorio inferior al anterior devuelto.Una vez llegue al valor
            cero y lo devuelva, el generador se reiniciará al valor inicial de forma automática.

            (B – 1,00 punto).

            Cree una versión del anterior que permita tanto reiniciar el generador de forma manual
            como modificar el valor inicial.
        
        
            Añádase código en el método Main para probar ambas versiones.
        
         */
        public static Func<int> CrearNumerosAleatorios(int rango, out Func<bool> reset, out Action<int> setInicial)
        {
            //Se define el estado
            int _rango = rango;
            int inicial = rango;

            //Funciones a definir
            Random rand = new Random();

            reset = () =>
            {
                _rango = inicial;
                Console.WriteLine("RESET");
                return true;
            };

            setInicial = (valor) =>
            {
                inicial = valor;
                Console.WriteLine("NUEVO VALOR INICIAL: " + valor);
            };


            return () =>
            {
                if (_rango <= 0)
                {
                    _rango = inicial;
                    Console.WriteLine("VOLVEMOS A INICIAL: " + _rango);
                }
                _rango = rand.Next(0, _rango);
                Console.WriteLine("NUEVO VALOR: " + _rango);
                return _rango;
            };

        }


        private static void NumerosAleatorios(int inicial)
        {

            //Func<int> numerosClausura = ClausuraNumerosAleatorios.CrearNumerosAleatorios(inicial);


        }

            /* Ejercicio Clase 1


            Implementar una clausura que devuelva el siguiente término de la sucesión de Fibonacci
            cada vez que se invoque la clausura:

                    1,1,2,3,5,8…

            Utilícese como base/idea el ejemplo del contador.

            NOTA: No es necesario usar la clase Fibonacci PARA NADA, simplemente para
                  aprender a calcular términos de Fibonnaci si no se sabe calcularlos.

            */

        public static Func<int> ClausuraFibonacci()
        {
            int a = 0;
            int b = 1;

            int result;

            return () =>
            {
                result = a + b;
                a = b;
                b = result;
                return result;
            };
        }



            /* Ejercicio Clase 2

               Impleméntese mediante un enfoque funcional el bucle While
               Pruébese la implementación para el ejemplo propuesto.

             */

        public static void ClausuraWhile(Func<bool> condition, Action accion, Action cont)
        {
            cont();
            if (condition())
            {
                accion();
                ClausuraWhile(condition, accion, cont);
            }
            
        }


            public static void BucleWhileObjetos()
        {
            int j = 0;

            while(j < 10) //Condición
            { 
                //Cuerpo
                j++;
                Console.WriteLine($"El valor de contador es {j}");
            }
        }

    }
}
