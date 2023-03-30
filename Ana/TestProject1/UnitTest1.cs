using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio1;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private PilaSerie pila;

        [TestInitialize]
        public void Iniciar()
        {
            pila = new(5);
        }



        [TestMethod]
        public void TestMethod1()
        {
            pila = new(5);
            Lista añadir = new Lista();
            añadir.Añadir(1);
            añadir.Añadir(8);
            añadir.Añadir(1);

            añadir.Añadir("Ana");
            añadir.Añadir("Hola");

            Assert.AreEqual(0, pila.PushSerie(añadir));

            // Comprobamos que se quedan añadir
            Lista extra = new Lista();
            extra.Añadir(5);
            Assert.AreEqual(1, pila.PushSerie(extra));

            // Eliminamos los 1 y el nombre Ana
            Lista a = pila.PopSerie(p => p.Equals(1) || p.Equals("Ana"));
            Assert.AreEqual(a.GetElemento(0).ToString(), 1);
            Assert.AreEqual(a.GetElemento(1).ToString(), "Ana");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ComprobarExcepciones()
        {
            pila.PopSerie(null);
            pila.PushSerie(null);
        }

    }
}
