using ComponentesTiendaMVC.Controllers;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using ComponentesTiendaMVC.Models;
using ComponentesTiendaMVC.CrossCuting.Logging;
using ComponentesTiendaMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComponentesMVC.Tests.Controllers
{
    [TestClass]
    public class UnitTestComponente
    {
        public FakeRepositorioComponente _fakeRepository;
        public Componente _fakeComponente;
        readonly ComponenteController controlador = new(new FakeRepositorioComponente(), new LoggerManager());


        [TestInitialize]
        public void TestSetup()
        {
            _fakeRepository = new FakeRepositorioComponente();
            _fakeComponente = _fakeRepository.TomaComponente(1);


        }

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

        public void PruebaComponentesDetallesVistaNoEncontrado()
        {
            var result = controlador.Details(200) as ViewResult;

            Assert.IsNull(result);
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

        [TestMethod]
        public void TestComponentesCrearVistaEncontrada()
        {
            var result = controlador.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PruebaComponentesCreateOk()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);

            var componente = new Componente
            {
                Descripcion = "Prueba1",
                NumeroSerie = "ABCDE12345",
                Precio = 100.0,
                Cores = 4,
                Grados = 70,
                Almacenamiento = "256 GB",
                TipoComponente = (int)TipoComponente.Procesador,
                OrdenadorId = 1
            };

            controlador.Create(componente);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }



        //[TestMethod]
        //public void PruebaComponentesCreateInvalido()
        //{
        //    var result = controlador.Index() as ViewResult;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("Index", result.ViewName);
        //    Assert.IsNotNull(result.ViewData.Model);

        //    var listaModulos = result.ViewData.Model as List<Componente>;

        //    Assert.IsNotNull(listaModulos);
        //    Assert.AreEqual(2, listaModulos.Count);

        //    var componenteInvalido = new Componente
        //    {
        //        OrdenadorId = 255
        //    };

        //    controlador.Create(componenteInvalido);


        //    result = controlador.Index() as ViewResult;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("Index", result.ViewName);
        //    Assert.IsNotNull(result.ViewData.Model);

        //    listaModulos = result.ViewData.Model as List<Componente>;


        //    Assert.IsNotNull(listaModulos);
        //    Assert.AreEqual(2, listaModulos.Count);
        //}

        [TestMethod]
        public void PruebaComponentesBorrarOk()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);

            controlador.DeleteConfirmed(1);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(1, listaModulos.Count);
        }

        [TestMethod]
        public void PruebaComponentesBorrarInvalido()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);

            controlador.DeleteConfirmed(155555);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }
        [TestMethod]
        public void PruebaControladorDeleteporID()
        {
            var listaComponentesPreBorrado = controlador.Index();
            var result = controlador.Delete(2) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);



            var listaComponentes = controlador.Index();
            Assert.IsNotNull(listaComponentes);
            Assert.AreNotEqual(listaComponentesPreBorrado, listaComponentes);

        }

        [TestMethod]


        public void PruebaControladorDeleteNull()
        {

            var result = controlador.Delete(7) as ViewResult;
            Assert.IsNull(result);
        }

        [TestMethod]
        public void PruebaComponenteEditOk()
        {
            Componente componenteNuevo = new()
            {
                Id = 3,
                Descripcion = "Prueba1",
                NumeroSerie = "ABCDE12345",
                Precio = 100.0,
                Cores = 4,
                Grados = 70,
                Almacenamiento = "256 GB",
                TipoComponente = (int)TipoComponente.Procesador,
                OrdenadorId = 1
            };
            controlador.Edit(3, componenteNuevo);

            Assert.AreEqual("Prueba1", componenteNuevo.Descripcion);
            Assert.AreEqual("ABCDE12345", componenteNuevo.NumeroSerie);
            Assert.AreEqual(100, componenteNuevo.Precio);
            Assert.AreEqual(4, componenteNuevo.Cores);
            Assert.AreEqual("256 GB", componenteNuevo.Almacenamiento);
            Assert.AreEqual(70, componenteNuevo.Grados);
            Assert.AreEqual(1, componenteNuevo.TipoComponente);
            Assert.AreEqual(1, componenteNuevo.OrdenadorId);
        }

        [TestMethod]
        public void PruebaComponentesEditVistaEncontrada()
        {
            var result = controlador.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var componente = result.ViewData.Model as Componente;

            Assert.IsNotNull(componente);
        }


        [TestMethod]
        public void TestComponentesEditVistaNoEncontrada()
        {
            var result = controlador.Edit(200) as ViewResult;

            Assert.IsNull(result);

        }

        [TestMethod]
        public void TestComponentesEditVistaNoEncontradaComponente()
        {
            var result = controlador.Edit(200, _fakeComponente) as ViewResult;

            Assert.IsNull(result);

        }

    }
}