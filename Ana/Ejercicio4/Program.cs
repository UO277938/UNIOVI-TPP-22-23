using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;

namespace Ejercicio4
{
    internal class Program
    {
        private static Model modelo = new Model();
        static void Main()
        {
            ConsultaAFer();
            ConsultaBFer();
        }

        private static void ConsultaA()
        {


            var res = modelo.Employees.GroupBy(p => p.Office.Building, (o, b) => new
            {
                Oficina = b.Select(i => i.Office.Number),
                NombreOficina = o,
                MediaEdad = b.Average(b => b.Age)
            });


            var e = res.Select(p => p.Oficina + ":" + p.NombreOficina + ":" + p.MediaEdad);

            Show(e);
        }

        private static void ConsultaB()
        {

        }

        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
        }


        //Nombre de oficina, numero de oficina, edad media de sus empleados

        private static void ConsultaAFer()
        {
            var result = modelo.Employees.GroupBy(e =>
                e.Office.Building,
                (o, b) => new
                {
                    NumeroOficina = b.Select( b => b.Office.Number),
                    NombreOficina = o,
                    EdadMedia = b.Average(b => b.Age)
                }
                );

            var e = result.Select(p => p.NumeroOficina + ":" + p.NombreOficina + ":" + p.EdadMedia);
            Show(e);

        }

        //Nombre de la oficina q no tenga ningun empleado que haya realizado llamadas de menos de 12 segundos
        private static void ConsultaBFer()
        {
            var result = modelo.Employees.Join(
                modelo.PhoneCalls,
                emp => emp.TelephoneNumber,
                llamada => llamada.SourceNumber,
                (emp, llamada) => new
                {
                    emp = emp,
                    llamada = llamada
                }
                ).Where(e => e.llamada.Seconds < 12).Select(e => $"Oficina: {e.emp.Office.Building}, empleado: {e.emp.Name}, llamada: {e.llamada.Seconds}");

            Show(result);
        }

    }


}
