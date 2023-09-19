namespace Ordenadores.Guardadores
{
    public interface IGuardable : ICalor, ICostable
    {
        string? dameNumeroSerie();
    }
}
