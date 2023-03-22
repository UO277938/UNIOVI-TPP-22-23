using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Modelo;
using System;

namespace Pruebas
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Persona[] personas = Factoria.CrearPersonas();
            Angulo[] angulos = Factoria.CrearAngulos();

            //Buscar firstordefault
            var jaun = personas.FirstOrDefault(p => p.Nombre == "Juan");
            Assert.AreEqual(personas[1], jaun);

            var r = personas.FirstOrDefault(p => p.Nif.EndsWith('R'));
            Assert.AreEqual(personas[2], r);

            var a = angulos.FirstOrDefault(a => a.Grados == 90);
            Assert.AreEqual(angulos[90], a);

            var cuadrante = angulos.FirstOrDefault(a => a.Grados >= 90 && a.Grados < 180);
            Assert.AreEqual(angulos[90], cuadrante);

            //Filtrar

            IEnumerable<Persona> juanes= personas.Where(p => p.Nombre == "Juan");
            Assert.AreEqual(personas[1], juanes.First());
            Assert.AreEqual(personas.Last(), juanes.Last());

            IEnumerable<Persona> errres = personas.Where(p => p.Nif.EndsWith('R'));
            Assert.AreEqual(personas[2], r);

            IEnumerable<Angulo> aff = angulos.Where(a => a.Grados == 90);
            Assert.AreEqual(angulos[90], aff);

            IEnumerable<Angulo> cuadrantes = angulos.Where(a => a.Grados >= 90 && a.Grados < 180);
            Assert.AreEqual(angulos[200], cuadrantes);

            //Where filtrar
            //Aggregate
            //Select es map

        }
    }
}