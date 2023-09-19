using Microsoft.AspNetCore.Mvc;
using ComponentesTiendaMVC.Models;
using ComponentesTiendaMVC.Services;
using ComponentesTiendaMVC.CrossCuting.Logging;
using Humanizer;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComponentesTiendaMVC.Controllers
{
    public class ComponenteController : Controller
    {
        private readonly IRepositorioComponente _repositorioComponente;
        private readonly ILoggerManager _loggerManager;

        public ComponenteController(IRepositorioComponente repositorioComponente, ILoggerManager loggerManager)
        { 
            _repositorioComponente = repositorioComponente;
            _loggerManager = loggerManager;
        }


        public ActionResult Home()
        {
            _loggerManager.LogInfo("Se va a mostrar la lista de componentes");
            return View("Home", _repositorioComponente.ListaComponentes());
        }

        // GET: HomeController
        public ActionResult Index()
        {
            _loggerManager.LogInfo("Se va a mostrar la lista de componentes");
            return View("Index", _repositorioComponente.ListaComponentes());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            var componente = _repositorioComponente.TomaComponente(id);

            if (componente == null)
            {
                return NotFound();
            }

            return View("Details", componente);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            var tiposComponente = Enum.GetValues(typeof(TipoComponente))
                .Cast<TipoComponente>()
                .Select(tc => new SelectListItem
                {
                    Value = ((int)tc).ToString(),
                    Text = tc.ToString()
                })
                .ToList();

            ViewBag.TiposComponente = tiposComponente;

            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Componente componente)
        {
            if (ModelState.IsValid)
            {
                
                _repositorioComponente.AddComponente(componente);
                return RedirectToAction(nameof(Index));
            }

            
            var tiposComponente = Enum.GetValues(typeof(TipoComponente))
                .Cast<TipoComponente>()
                .Select(tc => new SelectListItem
                {
                    Value = ((int)tc).ToString(),
                    Text = tc.ToString()
                })
                .ToList();

            ViewBag.TiposComponente = tiposComponente;

            return View(componente);
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
			var componente = _repositorioComponente.TomaComponente(id);
			if (componente == null)
			{
				return NotFound();
			}

			return View("Edit", componente);
		}

		// POST: HomeController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Componente componente)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_repositorioComponente.ActualizaComponente(componente);
					return RedirectToAction("Index");
				}

				return View("Edit", componente); 
			}
			catch (Exception ex)
			{
				_loggerManager.LogError($"Error al editar componente: {ex.Message}");
				return View("Edit", componente);
			}
		}

		// GET: HomeController/Delete/5
		public ActionResult Delete(int id)
        {
            var componente = _repositorioComponente.TomaComponente(id);

            if (componente == null)
            {
                _loggerManager.LogWarn("Se va a mostrar Delete not found");
                return NotFound();
            }

            return View("Delete", componente);
        }

        // POST: HomeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repositorioComponente.BorraComponente(id);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Index);
            }
        }
    }
}
