﻿using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;

namespace Linq
{
    class Program
    {
        
        private static Model modelo = new Model();

        static void Main()
        {
             /*SintaxisLinq();
             EjemploJoin();
             EjemploGroupBy();
             */
            
             Consulta1();
             Consulta2();
             Consulta3();
             Consulta4();
             Consulta5();
             Consulta6();
             Consulta7();
             

        }

        private static void SintaxisLinq()
        {
            //Obtener las llamadas de más de 15 segundos de duración


            //Sintaxis de consulta
            var c1 =
                from pc in modelo.PhoneCalls
                where pc.Seconds > 15
                select pc;
            Show(c1);

            Console.WriteLine();
            
            //Equivalente con sintaxis de métodos.
            //¡OJO! SE DEFINE LA CONSULTA. NO SE EJECUTA. ¿POR QUÉ?
            var c1_m = modelo.PhoneCalls.Where(ll => ll.Seconds > 15);
            //¿Qué ocurre si la consulta anterior la finalizamos con un .ToList()?

            Show(c1_m);
            Limpiar();
        }

        private static void EjemploJoin()
        {
            //Mostrar las llamadas de cada empleado con el formato: "<Nombre>;<Duración de la llamada>"

            //El método Join, une dos colecciones a partir de un atributo común:
            //Lo utilizamos sobre un IEnumerable (modelo.PhoneCalls)
            var result = modelo.PhoneCalls.Join(

                modelo.Employees, //para unir sus elementos con los de un segundo IEnumerable (modelo.Employees)

                llamada => llamada.SourceNumber, //Atributo clave del primer IEnumerable (PhoneCalls)

                emp => emp.TelephoneNumber, //Atributo clave del 2º IEnumerable (Employees)

                (llamada, emp) => $"{emp.Name};{llamada.Seconds}" // Función que recibe y trata cada par de llamada-empleado de claves coincidentes.
            );

            Show(result);
            Limpiar();
        }


        private static void EjemploGroupBy()
        {
            //GroupBy: Vamos a mostrar la duración de las llamadas agrupadas por número de teléfono (origen)

            var llamadas = modelo.PhoneCalls;
            var resultado = llamadas.GroupBy(ll => ll.SourceNumber);

            //resultado ahora mismo es un  IEnumerable<IGrouping>
            Console.WriteLine("Imprimiendo directamente:");
            Show(resultado);


            Console.WriteLine("\nImprimiendo mediante recorrido:");
            foreach (var grupo in resultado)
            {
                //Cada IGrouping tiene una Key:
                Console.Write("\nClave [" + grupo.Key + "] : ");
                //Y tenemos un listado. En este caso, de llamadas:
                foreach (var llamada in grupo)
                {
                    Console.Write(llamada.Seconds + " ");
                }
            }

            //Sin embargo GroupBy nos presenta otras opciones, vamos a combinar éstas
            //con los objetos anónimos:

            var opcion2 = llamadas.GroupBy(
                ll => ll.SourceNumber, //Agrupamos por número de origen

                //el primer parámetro es el número de origen (clave)
                //el segundo parámetro es un IEnumerable<PhoneCall> asociados a esa clave.
                (numero, llamadasEncontradas) =>
                new //Vamos emplear una función que cree objetos anónimos con la info que necesitamos
                {
                    Key = numero,
                    //Duraciones sigue siendo un IEnumerable.
                    Duraciones = llamadasEncontradas.Select(ll => ll.Seconds)
                }
                );

            Console.WriteLine("\n\nImprimiendo directamente:");
            Show(opcion2);
            Console.WriteLine("\nImprimiendo con el Aggregate:");
            var conAggregate = opcion2.Select( a => $"{a.Key} : { a.Duraciones.Aggregate("", (acumulado, actual) => $"{acumulado} {actual}") }" );
            //¿Podríamos hacer el Aggregate directamente en el objeto anónimo?
            Show(conAggregate);
            Limpiar();
        }

        //facil
        private static void Consulta1()
        {
            // Modificar la consulta para mostrar los empleados cuyo nombre empieza por F.
            var resultado = modelo.Employees.Where(e => e.Name.StartsWith('F'));

            Show(resultado);
            //El resultado esperado es: Felipe
        }

        //fac
        private static void Consulta2()
        {

            //Mostrar Nombre y fecha de nacimiento de los empleados de Cantabria con el formato:
            // Nombre=<Nombre>,Fecha=<Fecha>
            var resultado = modelo.Employees.Where(e => e.Province.Equals( "Cantabria")).Select(r => $"Nombre= {r.Name} , Fecha= {r.DateOfBirth}");
            
            Show(resultado);
            /*El resultado esperado es:
              Alvaro 19/10/1945 0:00:00
              Dario 16/12/1973 0:00:0066
            */
        }



        // A partir de aquí, necesitaréis métodos presentes en: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-5.0

        private static void Consulta3()
        {

            //Mostrar los nombres de los departamentos que tengan más de un empleado mayor de edad.
            var resultado = modelo.Departments.Where(d => d.Employees.Where(e => e.Age >= 18).Count() > 1).Select(d => "" + d.Name);
            Show(resultado);
            /*El resultado esperado es:
                Computer Science
                Medicine
            */


            //Posteriormente, modifica la consulta para que:
            //Muestre los nombres de los departamentos que tengan más de un empleado mayor de edad
            //y
            //que el despacho (Office.Number) COMIENCE por "2.1"
            var resultado2 = modelo.Departments.Where(d => d.Employees.Where(e => (e.Age >= 18 && e.Office.Number.StartsWith("2.1"))).Count() > 1).Select(d => "" + d.Name);
            Show(resultado2);
            //El resultado esperado es: Medicine
        }

        private static void Consulta4()
        {

            //El nombre de los departamentos donde ningún empleado tenga despacho en el Building "Faculty of Science".
            //Resultado esperado: [Department: Mathematics]
            var resultado = modelo.Departments.Where(d => d.Employees.Where(e => e.Office.Building == "Faculty of Science").Count() < 1);
            Show(resultado);
        }
        //fac
        private static void Consulta5()
        {


            // Mostrar las llamadas de teléfono de más de 5 segundos de duración para cada empleado que tenga más de 50 años
            //Cada línea debería mostrar el nombre del empleado y la duración de la llamada en segundos.
            //El resultado debe estar ordenado por duración de las llamadas (de más a menos).
            var resultado = modelo.PhoneCalls.Join(
                modelo.Employees,
                llamada => llamada.SourceNumber,
                emp => emp.TelephoneNumber,
                (llamada, emp) =>
                new
                {
                    emp = emp,

                    llamada = llamada.Seconds
                }
            ).Where(j => j.llamada > 5 && j.emp.Age > 50)
            .OrderByDescending(r => r.llamada)
            .Select(r => $"Nombre = {r.emp.Name}, Duracion = {r.llamada}");

            Show(resultado);

            /*
                { Nombre = Eduardo, Duracion = 23 }
                { Nombre = Eduardo, Duracion = 22 }
                { Nombre = Alvaro, Duracion = 15 }
                { Nombre = Alvaro, Duracion = 10 }
                { Nombre = Felipe, Duracion = 7 }
            */

        }



        private static void Consulta6()
        {
            //Mostrar la llamada realizada más larga para cada profesor, mostrando por pantalla: Nombre_profesor : duracion_llamada_mas_larga
            var resultado = modelo.Employees.Join(
                modelo.PhoneCalls,
                emp => emp.TelephoneNumber,
                llamada => llamada.SourceNumber,
                (emp, llamada) =>
                new
                {
                    emp = emp,
                    llamada = llamada
                }
            ).GroupBy(r => r.emp);
            foreach(var grupo in resultado)
            {
                var grupoOrdenado = grupo.OrderByDescending(o => o.llamada.Seconds).Select(o => o.emp.Name + " : " + o.llamada.Seconds).First();
                Console.WriteLine(grupoOrdenado);
            }
            //.OrderByDescending(o => o.llamada.Seconds).Select(o => "" + o.emp.Name + " : " + o.llamada.Seconds);
            //Show(resultado);

            /* ¡OJO NO ESTÁ APLICADO EL FORMATO 
                { Nombre = Alvaro, Maxima = 15 }
                { Nombre = Bernardo, Maxima = 63 }
                { Nombre = Eduardo, Maxima = 23 }
                { Nombre = Felipe, Maxima = 7 }
             */

        }


        //fac
        private static void Consulta7()
        {
            // Mostrar, agrupados por provincia, el nombre de los empleados
            //Tanto la provincia como los empleados deben estar ordenados alfabéticamente
            var resultado = modelo.Employees.GroupBy(e => e.Province);
            
            foreach (var grupo in resultado)
            {
                //Cada IGrouping tiene una Key:
                Console.Write(grupo.Key + " : ");
                //Y tenemos un listado. En este caso, de llamadas:
                foreach (var provincia in grupo)
                {
                    Console.Write(provincia.Name + " ");
                }
                Console.WriteLine("");
            }
            /*Resultado esperado:
                Alicante : Carlos
                Asturias : Bernardo Felipe
                Cantabria : Alvaro Dario               
                Granada : Eduardo

            */
        }



        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
        }
        private static void Limpiar()
        {
            Console.WriteLine("Pulse una tecla para continuar la ejecución...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
