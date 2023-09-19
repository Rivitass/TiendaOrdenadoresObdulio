namespace Ordenadores.Memorizadores
{
    public interface IMemorizable : ICalor, ICostable
    {
        string? dameNumeroSerie();
    }
}
