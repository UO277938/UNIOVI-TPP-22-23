using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriaSesion10;

namespace TestProject1
{
    [TestClass]
    public class Test
    {
        [TestClass]
        public class Prueba
        {
            BitcoinValueData[] data;
            double[] vector;

            [TestInitialize]
            public void Setup()
            {
                data = Utils.GetBitcoinData();
                vector = new double[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    vector[i] = data[i].Value;
                }
            }


            [TestMethod]
            public void TestMethod1()
            {

                int nHilos = 1;
                double valorLimite = 7000;

                Master master = new Master(vector, nHilos);

                double retorno = master.CalculaValoresSuperioresA(valorLimite);

                Assert.AreEqual(retorno, 2826);
            }

            [TestMethod]
            public void TestMethod2()
            {

                int nHilos = 2;
                double valorLimite = 7000;

                Master master = new Master(vector, nHilos);

                double retorno = master.CalculaValoresSuperioresA(valorLimite);

                Assert.AreEqual(retorno, 2826);
            }


            [TestMethod]
            public void TestMethod3()
            {

                int nHilos = 50;
                double valorLimite = 7000;

                Master master = new Master(vector, nHilos);

                double retorno = master.CalculaValoresSuperioresA(valorLimite);

                Assert.AreEqual(retorno, 2826);
            }
        }
    }
}
