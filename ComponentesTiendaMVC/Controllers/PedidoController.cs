using Microsoft.AspNetCore.Mvc;
using ComponentesTiendaMVC.Models;
using ComponentesTiendaMVC.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ComponentesTiendaMVC.CrossCuting.Logging;

namespace ComponentesTiendaMVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IRepositorioOrdenadores _ordenadoresRepository;
        private readonly IRepositorioComponente _componenteRepository;
        private readonly ILoggerManager _loggerManager;

        public PedidoController(IRepositorioOrdenadores ordenadoresRepository, IRepositorioComponente componenteRepository, ILoggerManager loggerManager)
        {
            _ordenadoresRepository = ordenadoresRepository;
            _componenteRepository = componenteRepository;
            _loggerManager = loggerManager;
        }

        //public ActionResult PedidoPersonalizado()
        //{

        //    var componentes = _componenteRepository.ListaComponentes();
        //    return View(componentes);
        //}
        //[HttpPost]
        //public ActionResult ConfirmarPedidoPersonalizado(List<int> componentesSeleccionados)
        //{
        //    var componentes = new List<Componente>();
        //    foreach (var componenteId in componentesSeleccionados)
        //    {
        //        var componente = _componenteRepository.TomaComponente(componenteId);
        //        if (componente != null)
        //        {
        //            componentes.Add(componente);
        //        }
        //    }

        //    var nuevoOrdenador = _ordenadoresRepository.CrearNuevoOrdenador();

        //    var nuevoPedido = new Pedido
        //    {
        //        FechaPedido = DateTime.Now,
        //        OrdenadorId = nuevoOrdenador.IdOrdenador
        //    };
        //    _ordenadoresRepository.AgregarPedido(nuevoPedido);

        //    foreach (var componente in componentes)
        //    {
        //        componente.OrdenadorId = nuevoOrdenador.IdOrdenador;
        //        _componenteRepository.ActualizaComponente(componente);
        //        nuevoPedido.Componentes.Add(componente);
        //    }

        //    _componenteRepository.ActualizaComponente(nuevoPedido);

        //    return RedirectToAction("Home", "Componente");
        //}




    }
}
