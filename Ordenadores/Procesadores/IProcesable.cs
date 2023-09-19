namespace Ordenadores.Procesadores
{
    public interface IProcesable : ICalor, ICostable
    {
        string? dameNumeroSerie();

    }
}
