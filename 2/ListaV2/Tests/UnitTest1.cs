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
            Assert.IsTrue(lista.Añadir(7));
            Assert.IsTrue(lista.Añadir(7));
            Assert.IsTrue(lista.Añadir(888.44));
            Assert.IsTrue(lista.Añadir("Hola"));
            Assert.IsTrue(lista.Añadir("Macarrones"));
            Assert.IsTrue(lista.Añadir(4.55));
            Assert.IsTrue(lista.Añadir(7));

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