using ComponentesTiendaMVC.Data;
using ComponentesTiendaMVC.Models;
using ComponentesTiendaMVC.CrossCuting.Logging;

namespace ComponentesTiendaMVC.Services
{
    public class EFRepositorioComponente : IRepositorioComponente
    {
        
        readonly OrdenadoresContext contexto;
        private readonly ILoggerManager LoggerManager;

        public EFRepositorioComponente(ILoggerManager loggerManager, OrdenadoresContext contexto)
        {
            this.LoggerManager = loggerManager;
            this.LoggerManager.LogInfo("holaaaaa");
            this.contexto = contexto;
        }
        public void AddComponente(Componente componente)
        {
            if (contexto.Componente is not null)
            {
                contexto.Componente.Add(componente);
                contexto.SaveChanges();
            }
        }

        public void BorraComponente(int Id)
        {
            if (contexto.Componente is not null)
            {
                var componenteABorrar = TomaComponente(Id);
                if (componenteABorrar is not null)
                {
                    contexto.Componente.Remove(componenteABorrar);
                    contexto.SaveChanges();
                }
            }
        }

        public void ActualizaComponente(Componente componente)
        {
            if (contexto.Componente is not null)
            {
                var componenteAActualizar = TomaComponente(componente.Id);
                if (componenteAActualizar is not null)
                {
                    componenteAActualizar.Descripcion = componente.Descripcion;
                    componenteAActualizar.NumeroSerie = componente.NumeroSerie;
                    componenteAActualizar.Precio = componente.Precio;
                    componenteAActualizar.Cores = componente.Cores;
                    componenteAActualizar.Grados = componente.Grados;
                    componenteAActualizar.Almacenamiento = componente.Almacenamiento;
                    componenteAActualizar.TipoComponente = componente.TipoComponente;
                    componenteAActualizar.OrdenadorId = componente.OrdenadorId;

                    LoggerManager.LogInfo($"Componente {componenteAActualizar.Id} editado");

                    contexto.SaveChanges();
                }
            }
        }

        public List<Componente>? ListaComponentes()
        {
            if (contexto.Componente is not null)
            {
                contexto.SaveChanges();
                return contexto.Componente.ToList();

            }
            return null;
        }

        public Componente? TomaComponente(int Id)
        {
            if (contexto.Componente is not null)
            {
                var componenteEncontrado = contexto.Componente.Find(Id);
                contexto.SaveChanges();
                return componenteEncontrado;
            }
            return null;
        }
    }
}
