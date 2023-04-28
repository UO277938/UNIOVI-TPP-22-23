using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using ListaEnlazada;
using ColaConcurrente;
using System.Collections.Generic;

namespace PruebaVerdadera
{
    [TestClass]
    public class PruebasColaConcurrente
    {
        
        [TestMethod]
        public void TestAñadir()
        {
            ColaConcurrente<object> cola = new ColaConcurrente<object>();

            Assert.IsTrue(cola.EstaVacia);
            Assert.IsTrue(cola.Añadir(88));
            Assert.IsFalse(cola.EstaVacia);

            Assert.IsTrue(cola.Añadir(null));
            Assert.IsTrue(cola.Añadir("Pepe"));

            Assert.AreEqual(88, cola.PrimerElemento());
            Assert.IsTrue(cola.Extraer());

            Assert.AreEqual(null, cola.PrimerElemento());
            Assert.IsTrue(cola.Extraer());

            Assert.AreEqual("Pepe", cola.PrimerElemento());
            Assert.IsTrue(cola.Extraer());

            Assert.IsTrue(cola.EstaVacia);
        }
    }
}
