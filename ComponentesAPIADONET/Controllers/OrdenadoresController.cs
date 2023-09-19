using ComponentesAPIADONET.Models;
using ComponentesAPIADONET.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ComponentesAPIADONET.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrdenadoresController : Controller
	{
		private readonly IOrdenadorRepositorio _repository;

		public OrdenadoresController(IOrdenadorRepositorio repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IEnumerable<Ordenador> Get()
		{
			return _repository.GetOrdenador();
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var ordeanador = _repository.GetOrdenadorById(id);
			if (ordeanador == null)
			{
				return NotFound();
			}
			return Ok(ordeanador);
		}



		[HttpGet("componentes/{id}")]
		public IActionResult GetComponentes(int id)
		{
			var componentes = _repository.GetComponentes(id);

			if (componentes == null || componentes.Count == 0)
			{
				return NotFound("No se encontraron componentes para el ID especificado.");
			}

			return Ok(componentes);
		}




		[HttpPost]
		public void Post([FromBody] Ordenador c)
		{
			_repository.Create(c);

		}
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Ordenador c)
		{
			_repository.Update(id, c);
			return Ok();
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{

			_repository.Delete(id);
		}
	}
}
