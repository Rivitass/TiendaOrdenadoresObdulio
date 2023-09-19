using ComponentesTiendaMVC.Controllers;
using ComponentesTiendaMVC.CrossCuting.Logging;
using ComponentesTiendaMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentesTiendaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComponentesMVC.Tests.Controllers
{
    [TestClass]
    public class UnitTestOrdenadores
    {
        public FakeRepositorioOrdenadores _fakeRepository;
        public Ordenador _FakeOrdenador;
        readonly OrdenadoresController controlador = new(new FakeRepositorioOrdenadores(), new FakeRepositorioComponente(), new LoggerManager());

        [TestInitialize]
        public void TestSetup()
        {
            _fakeRepository = new FakeRepositorioOrdenadores();
            _FakeOrdenador = _fakeRepository.TomaOrdenador(1);


        }

        [TestMethod]
        public void PruebaOrdenadoresDetallesVistaEncontrado()
        {
            var result = controlador.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var ordenador = result.ViewData.Model as Ordenador;
            Assert.IsNotNull(ordenador);
            Assert.AreEqual("Ordenador Fake 1", ordenador.DescripcionOrdenador);
        }
        [TestMethod]

        public void PruebaOrdenadoresDetallesVistaNoEncontrado()
        {
            var result = controlador.Details(200) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void PruebaOrdenadoresIndexVistaOk()
        {
            var result = controlador.OrdenadorIndex() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("OrdenadorIndex", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaordenador = result.ViewData.Model as List<Ordenador>;
            Assert.IsNotNull(listaordenador);
            Assert.AreEqual(3, listaordenador.Count);
        }

        //[TestMethod]
        //public void PruebaComponentesCreateOk()
        //{
        //    var result = controlador.OrdenadorIndex() as ViewResult;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("OrdenadorIndex", result.ViewName);
        //    Assert.IsNotNull(result.ViewData.Model);

        //    var listaModulos = result.ViewData.Model as List<Ordenador>;

        //    Assert.IsNotNull(listaModulos);
        //    Assert.AreEqual(3, listaModulos.Count);

        //    var ordenador = new Ordenador()
        //    {
        //        DescripcionOrdenador = "Prueba1",

        //    };

        //    controlador.Create(ordenador);
        //    result = controlador.OrdenadorIndex() as ViewResult;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("OrdenadorIndex", result.ViewName);
        //    Assert.IsNotNull(result.ViewData.Model);

        //    listaModulos = result.ViewData.Model as List<Ordenador>;

        //    Assert.IsNotNull(listaModulos);
        //    Assert.AreEqual(4, listaModulos.Count);
        //}


        [TestMethod]
        public void PruebaOrdenadoresBorrarOk()
        {
            var result = controlador.OrdenadorIndex() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("OrdenadorIndex", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteConfirmed(1);
            result = controlador.OrdenadorIndex() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("OrdenadorIndex", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }



        [TestMethod]
        public void PruebaOrdenadoresBorrarInvalido()
        {
            var result = controlador.OrdenadorIndex() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("OrdenadorIndex", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteConfirmed(155555);
            result = controlador.OrdenadorIndex() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("OrdenadorIndex", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }


        [TestMethod]
        public void PruebaControladorDeleteporID()
        {
            var listaComponentesPreBorrado = controlador.OrdenadorIndex();
            var result = controlador.Delete(2) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);



            var listaComponentes = controlador.OrdenadorIndex();
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
        public void PruebaOrdenadorEditOk()
        {
            Ordenador ordenadorNuevo = new()
            {
                IdOrdenador = 3,
                DescripcionOrdenador = "Prueba1",

            };
            controlador.Edit(3, ordenadorNuevo);

            Assert.AreEqual("Prueba1", ordenadorNuevo.DescripcionOrdenador);

        }

        [TestMethod]
        public void PruebaOrdenadorEditVistaEncontrada()
        {
            var result = controlador.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var ordenador = result.ViewData.Model as Ordenador;

            Assert.IsNotNull(ordenador);
        }


        [TestMethod]
        public void TestOrdenadorEditVistaNoEncontrada()
        {
            var result = controlador.Edit(200) as ViewResult;

            Assert.IsNull(result);

        }

        [TestMethod]
        public void TestOrdenadorEditVistaNoEncontradaOrdenador()
        {
            var result = controlador.Edit(200, _FakeOrdenador) as ViewResult;

            Assert.IsNull(result);

        }
    }
}
