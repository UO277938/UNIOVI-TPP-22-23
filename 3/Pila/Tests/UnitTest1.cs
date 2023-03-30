using NUnit.Framework;

namespace ListaEnlazada
{
    public class Tests
    {
        ListaEnlazada lista = new ListaEnlazada();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()

        {
            Assert.IsTrue(lista.A�adir(7));
            Assert.IsTrue(lista.A�adir(7));
            Assert.IsTrue(lista.A�adir(888.44));
            Assert.IsTrue(lista.A�adir("Hola"));
            Assert.IsTrue(lista.A�adir("Macarrones"));
            Assert.IsTrue(lista.A�adir(4.55));
            Assert.IsTrue(lista.A�adir(7));

            Assert.IsTrue(lista.Borrar("Hola"));
            Assert.IsTrue(lista.Borrar(7));

            Assert.IsTrue(lista.Contiene(888.44));
            Assert.IsTrue(lista.Contiene("Macarrones"));
            Assert.IsTrue(lista.Contiene(7));

            Assert.IsFalse(lista.Contiene("Hola"));
            Assert.IsFalse(lista.Contiene("Lengua"));

            Assert.IsTrue(lista.GetElement(0).Equals(7));
            Assert.IsTrue(lista.GetElement(2).Equals("Macarrones"));
        }
    }
}