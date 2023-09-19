using System;
using System.Collections.Generic;
using System.Linq;
using ComponentesAPIADONET.Models;
using ComponentesAPIADONET.Repositorios;

namespace ComponentesAPIADONET.Services
{
	public class FakeRepositorioOrdenador : IOrdenadorRepositorio
	{
		private List<Ordenador> _ordenadores;
		private List<OrdenadorComponente> _ordenadorComponentes;

		public FakeRepositorioOrdenador()
		{
			_ordenadores = new List<Ordenador>
			{
				new Ordenador
				{
					IdOrdenador = 1,
					DescripcionOrdenador = "Ordenador 1",

				},
				new Ordenador
				{
					IdOrdenador = 2,
					DescripcionOrdenador = "Ordenador 2",

				}
			};
			_ordenadorComponentes = new List<OrdenadorComponente>
			{
				new OrdenadorComponente
				{
					Ordenador = _ordenadores[0], 
					Componente = new Componente
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
					}
				},
				new OrdenadorComponente
				{
					Ordenador = _ordenadores[0], 
					Componente = new Componente
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
				},
				
			};
		}

		public IEnumerable<Ordenador> GetOrdenador()
		{
			return _ordenadores.ToList();
		}

		public Ordenador GetOrdenadorById(int id)
		{
			return _ordenadores.FirstOrDefault(o => o.IdOrdenador == id);
		}

		public void Create(Ordenador ordenador)
		{
			if (ordenador == null)
			{
				throw new ArgumentNullException(nameof(ordenador));
			}

			ordenador.IdOrdenador = _ordenadores.Max(o => o.IdOrdenador) + 1; 
			_ordenadores.Add(ordenador);
		}

		public void Update(int id, Ordenador ordenador)
		{
			if (ordenador == null)
			{
				throw new ArgumentNullException(nameof(ordenador));
			}

			var existingOrdenador = _ordenadores.FirstOrDefault(o => o.IdOrdenador == id);
			if (existingOrdenador != null)
			{
				
				existingOrdenador.DescripcionOrdenador = ordenador.DescripcionOrdenador;

			}
		}

		public void Delete(int id)
		{
			var ordenadorToRemove = _ordenadores.FirstOrDefault(o => o.IdOrdenador == id);
			if (ordenadorToRemove != null)
			{
				_ordenadores.Remove(ordenadorToRemove);
			}
		}
		public List<OrdenadorComponente> GetComponentes(int id)
		{
			return _ordenadorComponentes.Where(oc => oc.Ordenador.IdOrdenador == id).ToList();
		}
	}
}


