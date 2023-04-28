using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using ListaEnlazada;
using System.Collections.Generic;

namespace PruebaVerdadera
{
    [TestClass]
    public class PruebasLista
    {
        
        Persona[] personas;
        Angulo[] angulos;
        ListaEnlazada<Persona> listaP;
        ListaEnlazada<Angulo> listaA;

        [TestInitialize]
        public void Setup()
        {
            personas = Factoria.CrearPersonas();
            angulos = Factoria.CrearAngulos();

            listaP = new ListaEnlazada<Persona>();
            foreach (Persona persona in personas)
            {
                listaP.Añadir(persona);
            }

            listaA = new ListaEnlazada<Angulo>();
            foreach (Angulo a in angulos)
            {
                listaA.Añadir(a);
            }
        }

        [TestMethod]
        public void TestNull()
        {
            ListaEnlazada<object> lista = new ListaEnlazada<object>();
            Assert.IsTrue(lista.Añadir(null));
            Assert.IsTrue(lista.Añadir(7));
            Assert.IsTrue(lista.Añadir("JUAN"));

            Assert.IsTrue(lista.Borrar(null));
        }

            [TestMethod]
        public void TestBuscar()
        {

            Persona juan = listaP.Buscar(p => p.Nombre.Equals("Juan"));
            Assert.AreEqual(personas[1], juan);

            Persona r = listaP.Buscar(p => p.Nif.EndsWith('R'));
            Assert.AreEqual(personas[2], r);

            Angulo a = listaA.Buscar(a => a.Grados.Equals(90));
            Assert.AreEqual(angulos[90], a);

            Angulo cuadrante = angulos.Buscar(a => a.Grados >= 90 && a.Grados < 180);
            Assert.AreEqual(angulos[90], cuadrante);
        }

        [TestMethod]
        public void TestFiltrar()
        {
            IEnumerable<Persona> juanes = listaP.Filtrar(p => p.Nombre.Equals("Juan"));
            Assert.AreEqual(personas[1], juanes.Buscar(j => j.Apellido.Equals("Pérez")));
            Assert.AreEqual(personas[8], juanes.Buscar(j => j.Apellido.Equals("Hevia")));


            IEnumerable<Persona> errres = listaP.Filtrar(p => p.Nif.EndsWith('R'));
            Assert.AreEqual(personas[2], errres.Buscar(p => p.Nombre.Equals("Pepe")));

            IEnumerable<Angulo> aff = listaA.Filtrar(a => a.Grados.Equals(90));
            Assert.AreEqual(angulos[90], aff.Buscar(a => a.Grados.Equals(90)));

            IEnumerable<Angulo> cuadrantes = angulos.Filtrar(a => a.Grados >= 90 && a.Grados < 180);
            Assert.AreEqual(angulos[90], cuadrantes.Buscar(a => a.Grados.Equals(90)));
            Assert.AreEqual(angulos[179], cuadrantes.Buscar(a => a.Grados.Equals(179)));


        }

        [TestMethod]
        public void TestReducir()
        {//Aggregate es reduce
            double sumaAngulos = listaA.Reducir((suma, angulo) => suma + angulo.Grados, 0.0);
            Assert.AreEqual(64980.0, sumaAngulos);

            var senMaximo = listaA.Reducir((max, angulo) => angulo.Seno() > max ? angulo.Seno() : max, 0.0);
            Assert.AreEqual(1.0, senMaximo);

            var numNombre = listaP.Reducir((num, persona) => persona.Nombre.Equals("María") ? num + 1 : num, 0);
            Assert.AreEqual(2, numNombre);

            IEnumerable<Persona> listaInvertidaP = listaP.Invertir();
        }

        [TestMethod]
        public void TestMap()
        {
            //Select es map

            IEnumerable<string> apeNoms = listaP.Map(persona => new string(persona.Apellido + ", " + persona.Nombre));
            Assert.AreEqual(apeNoms.Buscar(s => s.Equals("Díaz, María")), "Díaz, María");
            Assert.AreEqual(apeNoms.Buscar(s => s.Equals("Hevia, Juan")), "Hevia, Juan");

            IEnumerable<int> cuadrante = listaA.Map(angulo => angulo.Grados < 90 ? 1 : angulo.Grados < 180 ? 2 : angulo.Grados < 270 ? 3 : 4);

        }
    }
}
