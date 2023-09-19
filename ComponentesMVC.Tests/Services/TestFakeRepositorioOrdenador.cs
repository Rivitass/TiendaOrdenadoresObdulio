using ComponentesTiendaMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentesTiendaMVC.Models;

namespace ComponentesMVC.Tests.Services
{
    [TestClass]
    public class TestFakeRepositorioOrdenador
    {

        readonly IRepositorioOrdenadores repositorioOrdenador = new FakeRepositorioOrdenadores();


        [TestMethod]
        public void TestTomaOrdenadorExiste()
        {
            var componente = repositorioOrdenador.TomaOrdenador(1);
            Assert.IsNotNull(componente);

        }
        [TestMethod]
        public void TestDameOrdenadorNoExiste()
        {
            var componente = repositorioOrdenador.TomaOrdenador(200);
            Assert.IsNull(componente);

        }

        [TestMethod]
        public void TestActualizaOrdenador()
        {
            var componente = repositorioOrdenador.TomaOrdenador(1);

            Assert.IsNotNull(componente);
            Assert.AreEqual("Ordenador Fake 1", componente.DescripcionOrdenador);

            repositorioOrdenador.EditOrdenador(new Ordenador()
            {
                IdOrdenador = 1,
                DescripcionOrdenador = "Juliano",

            });
            componente = repositorioOrdenador.TomaOrdenador(1);

            Assert.IsNotNull(componente);
            Assert.AreEqual("Juliano", componente.DescripcionOrdenador);

        }

        [TestMethod]
        public void TestBorrarOrdenador()
        {
            var misComponentes = repositorioOrdenador.ListaOrdenadores();
            var numeroComponentesAntes = misComponentes.Count();
            repositorioOrdenador.BorraOrdenador(1);
            var numeroComponentesDespues = misComponentes.Count();

            Assert.IsNull(repositorioOrdenador.TomaOrdenador(1));
            Assert.AreEqual(numeroComponentesDespues, numeroComponentesAntes - 1);
        }
    }

}
