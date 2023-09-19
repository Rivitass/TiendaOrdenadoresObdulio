
using System.Linq;
using ComponentesTiendaMVC.CrossCuting.Logging;
using ComponentesTiendaMVC.Models;
using ComponentesTiendaMVC.Services;


namespace ComponentesTiendaMVC.Services
{
    public class FakeRepositorioComponente : IRepositorioComponente
    {


        readonly List<Componente> misComponentes = new();
        public FakeRepositorioComponente()
        {
            misComponentes.Add(new Componente() {Id = 1, Descripcion = "Procesador Intel i7", NumeroSerie = "789_XCS", Precio = 134, Cores = 9, Grados = 10, Almacenamiento = "0", TipoComponente = (int)TipoComponente.Procesador, OrdenadorId = 2});
            misComponentes.Add(new Componente() {Id = 2, Descripcion = "Procesador Intel i7", NumeroSerie = "789_XCD", Precio = 138, Cores = 10, Grados = 12, Almacenamiento = "0", TipoComponente = (int)TipoComponente.Procesador, OrdenadorId = 3 });
        }

        public void ActualizaComponente(Componente componente)
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

                    
                }
            
        }

        public void AddComponente(Componente componente)
        {
            var ultimoNumero = misComponentes.Count;
            componente.Id = ultimoNumero;
            misComponentes.Add(componente);
        }

        public void BorraComponente(int Id)
        {
            misComponentes.RemoveAll(x => x.Id == Id);
        }

        public List<Componente> ListaComponentes()
        {
            return misComponentes;
        }

        public Componente TomaComponente(int Id)
        {
            return misComponentes.Find(x => x.Id == Id);

        }
    }
}
