using ComponentesTiendaMVC.Services;
using ComponentesTiendaMVC.Models;

namespace ComponentesMVC.Tests.Services
{
    [TestClass]
    public class TestFakeRepositorioComponente
    {
        readonly IRepositorioComponente repositorioComponente = new FakeRepositorioComponente();



        [TestMethod]
        public void TestTomaComponenteExiste()
        {
            var componente = repositorioComponente.TomaComponente(1);
            Assert.IsNotNull(componente);

        }
        [TestMethod]
        public void TestDameComponenteNoExiste()
        {
            var componente = repositorioComponente.TomaComponente(200);
            Assert.IsNull(componente);

        }

        [TestMethod]
        public void TestActualizaComponente()
        {
            var componente = repositorioComponente.TomaComponente(1);

            Assert.IsNotNull(componente);
            Assert.AreEqual("Procesador Intel i7", componente.Descripcion);
            Assert.AreEqual(134, componente.Precio);

            repositorioComponente.ActualizaComponente(new Componente()
            {
                Id = 1,
                Precio = 500,

            });
            componente = repositorioComponente.TomaComponente(1);

            Assert.IsNotNull(componente);
            Assert.AreEqual(500, componente.Precio);

        }

        [TestMethod]
        public void TestBorrarComponente()
        {
            var misComponentes = repositorioComponente.ListaComponentes();
            var numeroComponentesAntes = misComponentes.Count();
            repositorioComponente.BorraComponente(1);
            var numeroComponentesDespues = misComponentes.Count();

            Assert.IsNull(repositorioComponente.TomaComponente(1));
            Assert.AreEqual(numeroComponentesDespues, numeroComponentesAntes - 1);
        }
    }


}
