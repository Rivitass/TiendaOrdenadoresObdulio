using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentesAPIADONET.Controllers;
using ComponentesAPIADONET.Models;
using ComponentesAPIADONET.Repositorios;
using ComponentesAPIADONET.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComponentesADOTest.Controllers
{
	[TestClass]
	public class TestOrdenadoresController
	{

		private readonly IOrdenadorRepositorio _fakeRepository;

		public TestOrdenadoresController()
		{
			_fakeRepository = new FakeRepositorioOrdenador();
		}

		[TestMethod]
		public void ObtenerTodosLosOrdenadores()
		{
			
			var repository = new FakeRepositorioOrdenador(); 
			var controller = new OrdenadoresController(repository);

			
			var result = controller.Get() as IEnumerable<Ordenador>;

			
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count());
		}

		[TestMethod]
		public void ObtenerOrdenadorPorId()
		{
			
			var repository = new FakeRepositorioOrdenador();
			var controller = new OrdenadoresController(repository);

			
			var result = controller.Get(1) as OkObjectResult;
			var ordenador = result.Value as Ordenador;

			
			Assert.IsNotNull(result);
			Assert.IsNotNull(ordenador);
			Assert.AreEqual(1, ordenador.IdOrdenador);
		}

		[TestMethod]
		public void ObtenerOrdenadorPorIdNotFound()
		{
			
			var repository = new FakeRepositorioOrdenador();
			var controller = new OrdenadoresController(repository);

			
			var result = controller.Get(999) as NotFoundResult;

			
			Assert.IsNotNull(result);
		}
		[TestMethod]
		public void ObtenerComponentesPorOrdenadorId()
		{

			var controller = new OrdenadoresController(_fakeRepository);


			var result = controller.Get(1) as OkObjectResult;
			var componente = result.Value as Ordenador;


			Assert.IsNotNull(result);
			Assert.IsNotNull(componente);
		}

        [TestMethod]
        public void ObtenerComponentesPorOrdenadorIdComponentesNotFound()
        {
            var controller = new OrdenadoresController(_fakeRepository);

            var result = controller.GetComponentes(200) as NotFoundObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("No se encontraron componentes para el ID especificado.", result.Value);
        }

        [TestMethod]
		public void ObtenerComponentesPorOrdenadorIdNotFound()
		{
			var controller = new OrdenadoresController(_fakeRepository);


			var result = controller.Get(200) as NotFoundResult;


			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void CrearOrdenador()
		{
			
			var repository = new FakeRepositorioOrdenador();
			var controller = new OrdenadoresController(repository);
			var nuevoOrdenador = new Ordenador
			{
				IdOrdenador = 3,
				DescripcionOrdenador = "Nuevo Ordenador"
			};

			
			controller.Post(nuevoOrdenador);

			
			var result = controller.Get(3) as OkObjectResult;
			var ordenadorCreado = result.Value as Ordenador;

			Assert.IsNotNull(result);
			Assert.IsNotNull(ordenadorCreado);
			Assert.AreEqual(3, ordenadorCreado.IdOrdenador);
		}

		[TestMethod]
		public void ActualizarOrdenador()
		{
			
			var repository = new FakeRepositorioOrdenador();
			var controller = new OrdenadoresController(repository);
			var ordenadorModificado = new Ordenador
			{
				IdOrdenador = 1,
				DescripcionOrdenador = "Ordenador Modificado"
			};

			
			var result = controller.Put(1, ordenadorModificado) as OkResult;

			
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void BorrarOrdenador_Existente_DebeRetornarOk()
		{
			var controller = new OrdenadoresController(_fakeRepository);


			controller.Delete(1);
			var result = controller.Get(1) as NotFoundResult;


			Assert.IsNotNull(result);
		}
	}
}
