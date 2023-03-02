using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ListaEnlazada
{
    public class TestVector
    {
        

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()

        {
            IList<int> lista = new List<int>();
            lista.Insert(0, 1);
            lista.Insert(1, 2);
            lista.Insert(2, 3);
            lista.Insert(3, 1);

            Assert.IsTrue(lista.Count == 4);

            Assert.IsTrue(lista.IndexOf(2)==1);

            lista.Insert(lista.Count, lista[1]);

            lista.Remove(1);

            foreach(int i in lista)
            {
                //ALGO
            }
            

        }
    }
}