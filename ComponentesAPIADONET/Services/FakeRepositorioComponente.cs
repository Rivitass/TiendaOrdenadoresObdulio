using System;
using System.Collections.Generic;
using System.Linq;
using ComponentesAPIADONET.Models;

namespace ComponentesAPIADONET.Repositorios
{
	public class FakeRepositorioComponente : IComponenteRepositorio
	{
		private List<Componente> _componentes;

		public FakeRepositorioComponente()
		{
			_componentes = new List<Componente>
			{
				new Componente
				{
					Id = 1,
					Descripcion = "Componente 1",
					NumeroSerie = "12345",
					Precio = 100.0,
					Cores = 4,
					Grados = 60,
					Almacenamiento = "256 GB SSD",
					TipoComponente = 1,
					OrdenadorId = 1
				},
				new Componente
				{
					Id = 2,
					Descripcion = "Componente 2",
					NumeroSerie = "67890",
					Precio = 75.0,
					Cores = 2,
					Grados = 45,
					Almacenamiento = "1 TB HDD",
					TipoComponente = 2,
					OrdenadorId = 1
				}
			};
		}

		public IEnumerable<Componente> GetComponentes()
		{
			return _componentes.ToList();
		}

		public Componente GetComponenteById(int id)
		{
			return _componentes.FirstOrDefault(c => c.Id == id);
		}

		public void Create(Componente c)
		{
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}

			c.Id = _componentes.Max(componente => componente.Id) + 1; 
			_componentes.Add(c);
		}

		public void Update(int id, Componente c)
		{
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}

			var existingComponente = _componentes.FirstOrDefault(componente => componente.Id == id);
			if (existingComponente != null)
			{
				
				existingComponente.Descripcion = c.Descripcion;
				existingComponente.NumeroSerie = c.NumeroSerie;
				existingComponente.Precio = c.Precio;
				existingComponente.Cores = c.Cores;
				existingComponente.Grados = c.Grados;
				existingComponente.Almacenamiento = c.Almacenamiento;
				existingComponente.TipoComponente = c.TipoComponente;
				existingComponente.OrdenadorId = c.OrdenadorId;
			}
		}

		public void Delete(int id)
		{
			var componenteToRemove = _componentes.FirstOrDefault(c => c.Id == id);
			if (componenteToRemove != null)
			{
				_componentes.Remove(componenteToRemove);
			}
		}
	}
}
