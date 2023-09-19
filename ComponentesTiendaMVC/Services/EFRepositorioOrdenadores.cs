using ComponentesTiendaMVC.CrossCuting.Logging;
using ComponentesTiendaMVC.Data;
using ComponentesTiendaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ComponentesTiendaMVC.Services
{
    public class EFRepositorioOrdenadores : IRepositorioOrdenadores
    {
        private readonly OrdenadoresContext contexto;
        private readonly ILoggerManager LoggerManager;
        public EFRepositorioOrdenadores(ILoggerManager loggerManager, OrdenadoresContext contexto)
        {
            this.LoggerManager = loggerManager;
            this.LoggerManager.LogInfo("hola");
            this.contexto = contexto;

        }
        public Componente TomaComponente(int componenteId)
        {
            return contexto.Componente.Find(componenteId);
        }
        //public List<Componente> ListaComponentes()
        //{
        //    return contexto.Componente.ToList();
        //}
        public void EditOrdenador(Ordenador ordenador)
        {
            var OrdenadorAEditar = TomaOrdenador(ordenador.IdOrdenador);
            if (OrdenadorAEditar != null)
            {
                OrdenadorAEditar.DescripcionOrdenador = ordenador.DescripcionOrdenador;


                LoggerManager.LogInfo($"Ordenador  {OrdenadorAEditar.IdOrdenador} editado");

                contexto.SaveChanges();
            }
        }



        public void AddOrdenador(Ordenador ordenador)
        {
            if (contexto.Ordenadores is not null)
            {
                contexto.Ordenadores.Add(ordenador);
                LoggerManager.LogInfo($"Ordenador {ordenador.IdOrdenador} añadido");
                contexto.SaveChanges();
            }
        }

        public void BorraOrdenador(int Id)
        {
            if (contexto.Ordenadores is not null)
            {
                var ordenadorABorrar = TomaOrdenador(Id);
                if (ordenadorABorrar is not null)
                {
                    contexto.Ordenadores.Remove(ordenadorABorrar);
                    contexto.SaveChanges();
                }
            }
        }


        public List<Ordenador> ListaOrdenadores()
        {
            if (contexto.Ordenadores is not null)
            {
                return contexto.Ordenadores.ToList();
            }
            return null;
        }

        public Ordenador TomaOrdenador(int Id)
        {
            if (contexto.Ordenadores is not null)
            {
                var ordenadorEncontrado = contexto.Ordenadores.Find(Id);
                return ordenadorEncontrado;
            }
            return null;
        }

        public List<Componente> ObtenerComponentesPorOrdenador(int ordenadorId)
        {
            return contexto.Componente.Where(c => c.OrdenadorId == ordenadorId).ToList();
        }

        //public Ordenador CrearNuevoOrdenador()
        //{
        //    var nuevoOrdenador = new Ordenador
        //    {
        //        DescripcionOrdenador = "Nuevo Ordenador Personalizado" ,
        //        Pedidos = new List<Pedido>()
        //    };

        //    contexto.Ordenadores.Add(nuevoOrdenador);
        //    contexto.SaveChanges();

        //    return nuevoOrdenador;
        //}

        //public void AgregarPedido(Pedido pedido)
        //{
        //    contexto.Pedidos.Add(pedido);
        //    contexto.SaveChanges();
        //}


        //public List<Pedido> ListaPedidos()
        //{
        //    if (contexto.Pedidos != null)
        //    {
        //        return contexto.Pedidos.ToList();
        //    }
        //    return null;
        //}


    }

        

    
}
