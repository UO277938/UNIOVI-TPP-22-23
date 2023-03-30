using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ListaEnlazada
{
    [TestClass]
    public class Tests
    {
        ListaEnlazada<int> lista = new ListaEnlazada<int>();

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
            Assert.IsTrue(lista.Añadir(9));
            Assert.IsTrue(lista.Añadir(12));
            Console.WriteLine(lista.ToString());


            Assert.IsTrue(lista.Borrar(7));


            Assert.IsTrue(lista.Contiene(7));

            Assert.IsTrue(lista.GetElement(0).Equals(7));

            int[] results = new int[3];
            results[0] = 7;
            results[1] = 8;
            results[2] = 9;

            IEnumerator<int> iterador = lista.GetEnumerator();

            Assert.IsTrue(iterador.MoveNext());
            Assert.IsTrue(iterador.Current == 7);
            Assert.IsTrue(iterador.MoveNext());
            Assert.IsTrue(iterador.Current == 8);
            Assert.IsTrue(iterador.MoveNext());
            Assert.IsTrue(iterador.Current == 9);

            iterador.Reset();

            Assert.IsTrue(iterador.MoveNext());
            Assert.IsTrue(iterador.Current == 7);
            Assert.IsTrue(iterador.MoveNext());
            Assert.IsTrue(iterador.Current == 8);
            Assert.IsTrue(iterador.MoveNext());
            Assert.IsTrue(iterador.Current == 9);

        }
    }
}