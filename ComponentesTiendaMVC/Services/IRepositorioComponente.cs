using ComponentesTiendaMVC.Models;

namespace ComponentesTiendaMVC.Services
{
    public interface IRepositorioComponente
    {
        Componente? TomaComponente(int Id);
        void BorraComponente(int Id);

        void ActualizaComponente(Componente componente);
        void AddComponente(Componente componente);
        List<Componente>? ListaComponentes();
    }
}
