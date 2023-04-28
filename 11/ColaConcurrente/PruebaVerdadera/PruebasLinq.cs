using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using ListaEnlazada;
using System.Collections.Generic;
using System.Linq;

namespace PruebaVerdadera
{
    [TestClass]
    public class PruebasLinq
    {

        Persona[] personas;
        Angulo[] angulos;


        [TestInitialize]
        public void Setup()
        {
            personas = Factoria.CrearPersonas();
            angulos = Factoria.CrearAngulos();
        }

        [TestMethod]
        public void TestFirstOrDefault()
        {
            //Buscar - firstordefault
            var jaun = personas.FirstOrDefault(p => p.Nombre.Equals("Juan"));
            Assert.AreEqual(personas[1], jaun);

            var r = personas.FirstOrDefault(p => p.Nif.EndsWith('R'));
            Assert.AreEqual(personas[2], r);

            var a = angulos.FirstOrDefault(a => a.Grados.Equals(90));
            Assert.AreEqual(angulos[90], a);

            var cuadrante = angulos.FirstOrDefault(a => a.Grados >= 90 && a.Grados < 180);
            Assert.AreEqual(angulos[90], cuadrante);

            //Select es map

        }

        [TestMethod]
        public void TestWhere()
        {
            //Filtrar - where
            IEnumerable<Persona> juanes = personas.Where(p => p.Nombre.Equals("Juan"));
            Assert.AreEqual(personas[1], juanes.First());
            Assert.AreEqual(personas.Last(), juanes.Last());


            IEnumerable<Persona> errres = personas.Where(p => p.Nif.EndsWith('R'));
            Assert.AreEqual(personas[2], errres.First());

            IEnumerable<Angulo> aff = angulos.Where(a => a.Grados.Equals(90));
            Assert.AreEqual(angulos[90], aff.First());

            IEnumerable<Angulo> cuadrantes = angulos.Where(a => a.Grados >= 90 && a.Grados < 180);
            Assert.AreEqual(angulos[90], cuadrantes.First());
            Assert.AreEqual(angulos[179], cuadrantes.Last());
        }

        [TestMethod]
        public void TestAggregate()
        {//Aggregate es reduce
            double sumaAngulos = angulos.Aggregate(0.0, (suma, angulo) => suma + angulo.Grados);
            Assert.AreEqual(64980.0, sumaAngulos);

            var senMaximo = angulos.Aggregate(0.0, (max, angulo) => angulo.Seno() > max ? angulo.Seno() : max);
            Assert.AreEqual(1.0, senMaximo);

            var numNombre = personas.Aggregate(0, (num, persona) => persona.Nombre.Equals("María") ? num + 1 : num);
            Assert.AreEqual(2, numNombre);
        }

        [TestMethod]
        public void TestMap()
        {
            //Select es map

            IEnumerable<string> apeNoms = personas.Map(persona => new string(persona.Apellido + ", " + persona.Nombre));
            Assert.AreEqual(apeNoms.First(), "Díaz, María");
            Assert.AreEqual(apeNoms.Last(), "Hevia, Juan");

            IEnumerable<int> cuadrante = angulos.Map(angulo => angulo.Grados < 90 ? 1 : angulo.Grados < 180 ? 2 : angulo.Grados < 270 ? 3 : 4);
            Assert.AreEqual(cuadrante.First(), 1);
            Assert.AreEqual(cuadrante.Last(), 4);
            Assert.AreEqual(cuadrante.ElementAt(120), 2);

        }
    }
}
