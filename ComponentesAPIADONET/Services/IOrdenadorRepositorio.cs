using ComponentesAPIADONET.Models;

namespace ComponentesAPIADONET.Repositorios
{
	public interface IOrdenadorRepositorio
	{
		IEnumerable<Ordenador> GetOrdenador();

		Ordenador GetOrdenadorById(int id);

		void Create(Ordenador c);

		void Update(int id, Ordenador c);

		void Delete(int id);

		List<OrdenadorComponente> GetComponentes(int id);
	}
}
