using Ordenadores.Componentes;

namespace Ordenadores.Ordenadores
{
    public interface IListaOrdenadores : IComponente
    {
        void add(IComponente componente);
    }
}
