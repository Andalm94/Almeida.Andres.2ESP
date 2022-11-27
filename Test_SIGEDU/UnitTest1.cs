using Biblioteca_de_clases;
using System.ComponentModel;

namespace Test_SIGEDU
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void prueba1()
        {
            int respuesta;

            respuesta = 1;

            Assert.AreEqual(1, respuesta);
        }
        
       
    }
}