using ComponentesTiendaMVC.Models;

namespace ComponentesTiendaMVC.Services
{
    public interface IRepositorioOrdenadores
    {

        Componente TomaComponente(int id);

        Ordenador TomaOrdenador(int Id);
        void BorraOrdenador(int Id);

        void EditOrdenador(Ordenador ordenador);
        void AddOrdenador(Ordenador ordenador);
        List<Ordenador> ListaOrdenadores();

        //List<Componente> ListaComponentes();

        List<Componente> ObtenerComponentesPorOrdenador(int ordenadorId);

        //void AgregarPedido(Pedido pedido);

        //Ordenador CrearNuevoOrdenador();

    }
}
