using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComponentesAPIADONET.Models;
using ComponentesAPIADONET.Repositorios;
using ComponentesAPIADONET.Services;

namespace ComponentesAPIADONET.Tests.Repositorios
{
	[TestClass]
	public class FakeOrdenadorTests
	{
		private readonly IOrdenadorRepositorio _fakeRepository = new FakeRepositorioOrdenador();

		[TestMethod]
		public void TestGetOrdenadorById_Exists()
		{
			var ordenador = _fakeRepository.GetOrdenadorById(1);
			Assert.IsNotNull(ordenador);
			Assert.AreEqual("Ordenador 1", ordenador.DescripcionOrdenador);
		}

		[TestMethod]
		public void TestGetOrdenadorById_NotExists()
		{
			var ordenador = _fakeRepository.GetOrdenadorById(100);
			Assert.IsNull(ordenador);
		}

		[TestMethod]
		public void TestCreateOrdenador()
		{
			var newOrdenador = new Ordenador
			{
				DescripcionOrdenador = "Nuevo Ordenador",

			};

			_fakeRepository.Create(newOrdenador);

			var retrievedOrdenador = _fakeRepository.GetOrdenadorById(newOrdenador.IdOrdenador);
			Assert.IsNotNull(retrievedOrdenador);
			Assert.AreEqual(newOrdenador.DescripcionOrdenador, retrievedOrdenador.DescripcionOrdenador);
		}

		[TestMethod]
		public void TestUpdateOrdenador()
		{
			var ordenador = _fakeRepository.GetOrdenadorById(1);

			Assert.IsNotNull(ordenador);
			Assert.AreEqual("Ordenador 1", ordenador.DescripcionOrdenador);


			_fakeRepository.Update(1, new Ordenador
			{
				DescripcionOrdenador = "Nuevo Ordenador 1",

			});

			ordenador = _fakeRepository.GetOrdenadorById(1);

			Assert.IsNotNull(ordenador);
			Assert.AreEqual("Nuevo Ordenador 1", ordenador.DescripcionOrdenador);

		}

		[TestMethod]
		public void TestDeleteOrdenador()
		{
			var ordenadoresBeforeDelete = _fakeRepository.GetOrdenador().ToList();
			var numeroOrdenadoresAntes = ordenadoresBeforeDelete.Count;

			_fakeRepository.Delete(1);

			var ordenadoresAfterDelete = _fakeRepository.GetOrdenador().ToList();
			var numeroOrdenadoresDespues = ordenadoresAfterDelete.Count;

			Assert.IsNull(_fakeRepository.GetOrdenadorById(1));
			Assert.AreEqual(numeroOrdenadoresDespues, numeroOrdenadoresAntes - 1);
		}

		[TestMethod]
		public void TestGetComponentes()
		{
			var ordenadorId = 1;

			var componentes = _fakeRepository.GetComponentes(ordenadorId);

			Assert.IsNotNull(componentes);
			Assert.AreEqual(2, componentes.Count);
		}
	}
}
