using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ListaEnlazada
{
    public class TestDiccionario
    {
        

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()

        {
            IDictionary<int,int> dic = new Dictionary<int,int>();
            dic.Add(1,1);
            dic.Add(2,2);
            dic.Add(3,3);
            dic.Add(4,1);

            Assert.IsTrue(dic.Count == 4);
            Assert.IsTrue(dic.TryGetValue(1, out int val));

            dic.Remove(4);

            foreach (KeyValuePair<int, int> custKeyVal in dic)
            {
                //
            }


        }
    }
}