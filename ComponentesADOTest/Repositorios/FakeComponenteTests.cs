using ComponentesAPIADONET.Controllers;
using ComponentesAPIADONET.Models;
using ComponentesAPIADONET.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ComponentesADOTest.Repositorios
{
    [TestClass]
    public class FakeComponenteTests
    {
        private readonly IComponenteRepositorio _fakeRepository;

        public FakeComponenteTests()
        {
            _fakeRepository = new FakeRepositorioComponente();
        }

        [TestMethod]
        public void TomaComponenteExiste()
        {
            
            var controller = new ComponenteController(_fakeRepository);

            
            var result = controller.Get(1) as OkObjectResult;
            var componente = result.Value as Componente;

            
            Assert.IsNotNull(result);
            Assert.IsNotNull(componente);
        }


		[TestMethod]
        public void TomaComponenteNoExiste()
        {
           
            var controller = new ComponenteController(_fakeRepository);

         
            var result = controller.Get(200) as NotFoundResult;

            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ActualizaComponente()
        {
          
            var controller = new ComponenteController(_fakeRepository);
            var updatedComponente = new Componente
            {
                Id = 1,
                Precio = 500
            };

            
            controller.Put(1, updatedComponente);
            var result = controller.Get(1) as OkObjectResult;
            var componente = result.Value as Componente;

          
            Assert.IsNotNull(result);
            Assert.IsNotNull(componente);
            Assert.AreEqual(500, componente.Precio);
        }

        [TestMethod]
        public void BorraComponente()
        {
            
            var controller = new ComponenteController(_fakeRepository);

       
            controller.Delete(1);
            var result = controller.Get(1) as NotFoundResult;

           
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PruebaGet()
        {

	        var controller = new ComponenteController(_fakeRepository);

	       
	        var componentes = controller.Get();

	    
	        Assert.IsNotNull(componentes);

		}

		[TestMethod]
		public void Create()
		{
		
			var controller = new ComponenteController(_fakeRepository);
			var nuevoComponente = new Componente
			{
				Descripcion = "Componente de prueba",
				NumeroSerie = "12345",
				Precio = 100.0,
				Cores = 4,
				Grados = 75,
				Almacenamiento = "512GB SSD",
				TipoComponente = (int)TipoComponente.Procesador,
				OrdenadorId = 1 
			};

	
			controller.Post(nuevoComponente); 


			var componenteCreado = _fakeRepository.GetComponenteById(nuevoComponente.Id);
			Assert.IsNotNull(componenteCreado);
			Assert.AreEqual("Componente de prueba", componenteCreado.Descripcion);
			Assert.AreEqual("12345", componenteCreado.NumeroSerie);
			Assert.AreEqual(100.0, componenteCreado.Precio);
			Assert.AreEqual(4, componenteCreado.Cores);
			Assert.AreEqual(75, componenteCreado.Grados);
			Assert.AreEqual("512GB SSD", componenteCreado.Almacenamiento);
			Assert.AreEqual((int)TipoComponente.Procesador, componenteCreado.TipoComponente);
			Assert.AreEqual(1, componenteCreado.OrdenadorId);


		}



	}
}