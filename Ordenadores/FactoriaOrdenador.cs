using Ordenadores.Almacen;
using Ordenadores.Componentes;
using Ordenadores.Guardadores;
using Ordenadores.Memorizadores;
using Ordenadores.Ordenadores;
using Ordenadores.Procesadores;

namespace Ordenadores
{
    public class FactoriaOrdenador : IOrdenadorFactoriaMethod
    {
#pragma warning disable CS8766
        public IComponente? dameOrdenador(TipoOrdenador tipoOrdenador)
#pragma warning restore CS8766 
        {
            AlmacenComp miAlmacen = new();
            switch (tipoOrdenador)
            {
                case TipoOrdenador.OrdenadorMaria:
                    return new Ordenador((IProcesable)miAlmacen.GetCompAlma("789-XCS"),
                                (IMemorizable)miAlmacen.GetCompAlma("879FH"),
                        (IGuardable)miAlmacen.GetCompAlma("789-XX"));
                case TipoOrdenador.OrdenadorAndres:
                    return new Ordenador((IProcesable)miAlmacen.GetCompAlma("797-X3"),
                        (IMemorizable)miAlmacen.GetCompAlma("879FH-T"),
                        (IGuardable)miAlmacen.GetCompAlma("789-XX-3"));
                case TipoOrdenador.OrdenadorTiburcioII:
                    List<IGuardable> discosDurosTriburcio = new List<IGuardable>
                    {
                        (IGuardable) miAlmacen.GetCompAlma("1789-XCS"),
                        (IGuardable) miAlmacen.GetCompAlma("788-fg")
                    };

                    return new OrdenadorPlus((IProcesable)miAlmacen.GetCompAlma("789-XCS"),
                        (IMemorizable)miAlmacen.GetCompAlma("879FH"),
                        (IGuardable)miAlmacen.GetCompAlma("789-XX"),
                        discosDurosTriburcio);
                case TipoOrdenador.OrdenadorAndresCF:
                    List<IGuardable> discosDurosAndresCF = new List<IGuardable>
                    {
                        (IGuardable)miAlmacen.GetCompAlma("789-XX-3")
                    };

                    return new OrdenadorPlus((IProcesable)miAlmacen.GetCompAlma("797-X3"),
                        (IMemorizable)miAlmacen.GetCompAlma("879FH-T"),
                        (IGuardable)miAlmacen.GetCompAlma("788-fg"),
                        discosDurosAndresCF);
                default: return null;
            }
        }
    }
}
