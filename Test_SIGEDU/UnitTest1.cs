using Biblioteca_de_clases;
using System.ComponentModel;

namespace Test_SIGEDU
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearUsuario_DebeRetornarUnaFilaAfectada()
        {
            int respuesta;
            
            respuesta = ConnectionDao.CrearNuevoUsuario(-1, "test", "test", "test", "test", "test");

            Assert.AreEqual(1, respuesta);
        }
        
        
        [TestMethod]
        public void ObtenerNombresProfesores_RetornaNotNull()
        {
            BindingList<string> respuesta;
            
            respuesta = ConnectionDao.ObtenerNombresProfesores();

            Assert.IsNotNull(respuesta);
        }

        [TestMethod]
        public void ObtenerNombresProfesores_EsDistintoANombresAlumnos()
        {
            BindingList<string> listaProfesores;
            BindingList<string> listaAlumnos;

            listaProfesores = ConnectionDao.ObtenerNombresProfesores();
            listaAlumnos = ConnectionDao.ObtenerNombresAlumnos();

            Assert.AreNotSame(listaProfesores, listaAlumnos);
        }

    }
}