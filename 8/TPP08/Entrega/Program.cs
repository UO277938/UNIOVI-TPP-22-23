using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;

namespace Linq
{
    class Program
    {

        private static ModelEntrega modelo = new ModelEntrega();

        static void Main()
        {
            /*SintaxisLinq();
            EjemploJoin();
            EjemploGroupBy();
            */

            Consulta1();
            Consulta2();
            Consulta3();
            Consulta3a();
            Consulta4();
            Consulta5();


        }

        //facil
        private static void Consulta1()
        {
            Console.WriteLine("/////// 1 ///////");
            /*Mostrar, ordenados por edad, los nombres de los empleados pertenecientes al
                departamento de “Computer Science” que tienen un despacho en la “Faculty of Science” y
                que han hecho llamadas con duración superior a 1 minuto. 
             */
            var resultado = modelo.Employees.Where(e => e.Department.Name.Equals("Computer Science") && e.Office.Building.Equals("Faculty of Science"))
                .Join(modelo.PhoneCalls,
                emp => emp.TelephoneNumber,
                llamada => llamada.SourceNumber,
                (emp, llamada) =>
                new
                {
                    emp = emp,
                    llamada = llamada
                }
                ).Where(o => o.llamada.Seconds > 60).OrderByDescending(o => o.emp.Age).Select(o => "" + o.emp.Name);

            Show(resultado);

        }

        //fac
        private static void Consulta2()
        {
            Console.WriteLine("/////// 2 ///////");
            //Mostrar la suma en segundos de las llamadas hechas por los empleados del departamento
            //de “Computer Science”
            var resultado = modelo.Employees.Where(e => e.Department.Name.Equals("Computer Science")).Join(
                modelo.PhoneCalls,
                emp => emp.TelephoneNumber,
                llamada => llamada.SourceNumber,
                (emp, llamada) => new
                {
                    emp = emp,
                    llamada = llamada
                }
                ).Aggregate(0, (acc, o) => acc = acc + o.llamada.Seconds 
                );
            Console.WriteLine("Suma segundos: "+ resultado);
        }

        private static void Consulta3()
        {
            Console.WriteLine("/////// 3 ///////");
            /*Mostrar las llamadas de teléfono hechas por cada departamento, ordenadas por el nombre
            del departamento. Cada línea debe tener la siguiente estructura:
            “Departamento =< Nombre >, Duración =< Segundos >”*/

            var resultado = modelo.Employees.Join(
                modelo.PhoneCalls,
                emp => emp.TelephoneNumber,
                ll => ll.SourceNumber,
                (emp, ll) => new
                {
                    empleado = emp,
                    llamada = ll
                }).GroupBy(o => o.empleado.Department.Name);
            foreach(var g in resultado)
            {
                var resultGrupo = g.Aggregate(0, (acc, g) => g.llamada.Seconds + acc);
                Console.WriteLine($"Departamento = {g.Key}, Duración = {resultGrupo}");
            }


        }

        private static void Consulta3a()
        {
            Console.WriteLine("/////// 3a ///////");
            /*Mostrar las llamadas de teléfono hechas por cada departamento, ordenadas por el nombre
            del departamento. Cada línea debe tener la siguiente estructura:
            “Departamento =< Nombre >, Duración =< Segundos >”*/

            var resultado = modelo.Employees.Join(
                modelo.PhoneCalls,
                emp => emp.TelephoneNumber,
                ll => ll.SourceNumber,
                (emp, ll) => new
                {
                    empleado = emp,
                    llamada = ll
                }).OrderBy(o => o.empleado.Department.Name).Select(o => $"Departamento = {o.empleado.Department}, Duración = {o.llamada.Seconds}");

            Show(resultado);
        }

        private static void Consulta4()
        {
            Console.WriteLine("/////// 4 ///////");
            //Mostrar los departamentos con el empleado más joven, además del nombre dicho
            //empleado más joven y su edad.Tened en cuenta que puede existir más de un empleado más
            //joven.
            var edad = modelo.Employees.OrderBy(o => o.Age).Select(e => e.Age).First();
            var result = modelo.Employees.OrderBy(o => o.Age).Where(o=> o.Age == edad ).Select(e=> $"Departamento = {e.Department.Name}, Empleado = {e.Name}, {e.Age}");
            Show(result);
        }
        //fac
        private static void Consulta5()
        {

            Console.WriteLine("/////// 5 ///////");
            /*Mostrar el departamento que tenga la mayor duración de llamadas telefónicas(en
            segundos), sumando la duración de las llamadas de todos los empleados que pertenecen al
            mismo.Mostrar también el nombre de dicho departamento(puede suponerse que solo hay
            un departamento que cumplirá esta condición*/
            var resultado = modelo.Employees.Join(
                modelo.PhoneCalls,
                emp => emp.TelephoneNumber,
                ll => ll.SourceNumber,
                (emp, ll) => new
                {
                    empleado = emp,
                    llamada = ll
                }).GroupBy(o => o.empleado.Department.Name);
            string llave = ""; var resultGrup = 0;
            foreach (var g in resultado)
            {
                
                var resultGrupo = g.Aggregate(0, (acc, g) => g.llamada.Seconds + acc);
                if (resultGrupo > resultGrup)
                {
                    resultGrup = resultGrupo;
                    llave = g.Key;
                }
                
            }
            Console.WriteLine($"Departamento = {llave}, Duración = {resultGrup}");

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
