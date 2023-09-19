using ComponentesAPIADONET.Models;

namespace ComponentesAPIADONET.Repositorios
{
	public interface IComponenteRepositorio
	{
		IEnumerable<Componente> GetComponentes();

		Componente GetComponenteById(int id);

		void Create(Componente c);

		void Update(int id, Componente c);

		void Delete(int id);
	}
}
