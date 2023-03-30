using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ListaEnlazada
{
    [TestClass]
    public class Tests
    {
        ListaEnlazada<object> lista = new ListaEnlazada<object>();

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void Test1()

        {
            Assert.IsTrue(lista.Añadir(7));
            Assert.IsTrue(lista.Añadir(7));
            Assert.IsTrue(lista.Añadir(8));
            Assert.IsTrue(lista.Añadir(null));
            Assert.IsTrue(lista.Añadir(12));
            Console.WriteLine(lista.ToString());


            Assert.IsTrue(lista.Borrar(7));


            Assert.IsTrue(lista.Contiene(7));

            Assert.IsTrue(lista.GetElement(0).Equals(7));


        }
    }
}