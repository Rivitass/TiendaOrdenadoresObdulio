using ComponentesAPIADONET.Models;
using ComponentesAPIADONET.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ComponentesAPIADONET.Controllers
{

	public enum CommandType
	{
		Text = 1,

		StoredProcedure = 4,

		TableDirect = 512
	}

	[ApiController]
	[Route("api/[controller]")]
	public class ComponenteController : Controller
	{
		private readonly IComponenteRepositorio _repository;

		public ComponenteController(IComponenteRepositorio repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IEnumerable<Componente> Get()
		{
			return _repository.GetComponentes();
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var componente = _repository.GetComponenteById(id);
			if (componente == null)
			{
				return NotFound();
			}
			return Ok(componente);
		}

		[HttpPost]
		public void Post([FromBody] Componente c)
		{
			_repository.Create(c);
		}


		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Componente c)
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

