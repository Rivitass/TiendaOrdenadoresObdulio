using ComponentesTiendaMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using ComponentesTiendaMVC.Models;
using ComponentesTiendaMVC.CrossCuting.Logging;
using ComponentesTiendaMVC.Services;

namespace ComponentesMVC.Tests
{
    [TestClass]
    public class UnitTestComponente
    {
        readonly ComponenteController controlador = new(new FakeRepositorioComponente(), new LoggerManager());

        [TestMethod]
        public void PruebaComponentesDetallesVistaEncontrado()
        {
     
            var result = controlador.Details(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var componente = result.ViewData.Model as Componente;
            Assert.IsNotNull(componente);
            Assert.AreEqual("789_XCS", componente.NumeroSerie);
        }
        [TestMethod]
        public void PruebaComponentesIndexVistaOk()
        {
            var result = controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listacomponente = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listacomponente);
            Assert.AreEqual(2, listacomponente.Count);
        }
    }
}