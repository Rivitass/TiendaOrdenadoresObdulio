using ComponentesTiendaMVC.CrossCuting.Logging;
using ComponentesTiendaMVC.Models;
using ComponentesTiendaMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComponentesTiendaMVC.Controllers
{
	public class OrdenadoresController : Controller
	{
		private readonly IRepositorioOrdenadores _ordenadoresRepository;
		private readonly IRepositorioComponente _componenteRepository;
		private readonly ILoggerManager _loggerManager;


		public OrdenadoresController(IRepositorioOrdenadores ordenadoresRepository, IRepositorioComponente componenteRepository, ILoggerManager loggerManager)
		{
			_ordenadoresRepository = ordenadoresRepository;
			_componenteRepository = componenteRepository;
			_loggerManager = loggerManager;
		}

		public ActionResult OrdenadorIndex()
		{
			_loggerManager.LogInfo("Se va a mostrar la lista de ordenadores");
			_loggerManager.LogDebug("Se va a mostrar la lista de ordenadores");


			return View("OrdenadorIndex", _ordenadoresRepository.ListaOrdenadores());
		}
		public ActionResult Create()
		{
			ViewBag.Componentes = _ordenadoresRepository.ObtenerComponentesPorOrdenador(1);
			return View("Create");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Ordenador ordenador, List<int> Componentes)
		{
			if (ModelState.IsValid)
			{
				_ordenadoresRepository.AddOrdenador(ordenador);


				if (Componentes != null)
				{
					foreach (var componenteId in Componentes)
					{
						var componente = _ordenadoresRepository.TomaComponente(componenteId);
						if (componente != null)
						{

							componente.OrdenadorId = ordenador.IdOrdenador;
							_componenteRepository.ActualizaComponente(componente);
						}
					}
				}


				return RedirectToAction("OrdenadorIndex");
			}


			ViewBag.Componentes = _ordenadoresRepository.ObtenerComponentesPorOrdenador(1);
			return View("Create", ordenador);
		}



        public ActionResult Edit(int id)
        {
            Ordenador pc = _ordenadoresRepository.TomaOrdenador(id);
            if (pc == null)
            {
                _loggerManager.LogError("Se va a mostrar error en edit null");
                return null;

            }
            return View("Edit", pc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdOrdenador,DescripcionOrdenador")] Ordenador ordenador)
        {
            if (ModelState.IsValid)
            {
                ordenador.IdOrdenador = id;
                _ordenadoresRepository.EditOrdenador(ordenador);
                return RedirectToAction("OrdenadorIndex");
            }
            return View(ordenador);
        }

        public ActionResult Delete(int id)
		{

			var ordenador = _ordenadoresRepository.TomaOrdenador(id);

			if (ordenador == null)
			{
				_loggerManager.LogWarn("Se va a mostrar Delete not found");
				return NotFound();
			}

			return View("Delete", ordenador);
		}

		// POST: Componentes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var componente = _ordenadoresRepository.TomaOrdenador(id);
			if (componente != null)
			{
				_ordenadoresRepository.BorraOrdenador(id);
			}

			return RedirectToAction(nameof(OrdenadorIndex));
		}




		public ActionResult Details(int id)
		{


			var ordenador = _ordenadoresRepository.TomaOrdenador(id);
			if (ordenador == null)
			{
				return NotFound();
			}

			return View("Details", ordenador);
		}

		public ActionResult OrdenadorComponentes()
		{
			var ordenadores = _ordenadoresRepository.ListaOrdenadores();
			ViewBag.Ordenadores = new SelectList(ordenadores, "IdOrdenador", "DescripcionOrdenador");

			var model = new List<Componente>();
			return View(model);
		}

		[HttpPost]
		public ActionResult CargarComponentes(int ordenadorId)
		{
			var componentes = _ordenadoresRepository.ObtenerComponentesPorOrdenador(ordenadorId);
			return PartialView("_ComponentesPartial", componentes);
		}


	}
}
