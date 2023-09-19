using Ordenadores.Almacen;
using Ordenadores.Componentes;
using Ordenadores.Guardadores;
using Ordenadores.Memorizadores;
using Ordenadores.Procesadores;

namespace Ordenadores.Ordenadores
{
    public class Ordenador : IComponente, IAlmacenable
    {
        private readonly IProcesable _procesable;
        private readonly IMemorizable _memorizable;
        private readonly IGuardable _guardable;

        public Ordenador(IProcesable procesador, IMemorizable memoriaRAM, IGuardable discoDuro)
        {
            _procesable = procesador;
            _memorizable = memoriaRAM;
            _guardable = discoDuro;
        }

        public string? NumSerieDiscoDuro()
        {
            return _guardable.dameNumeroSerie();
        }

        public string? NumSerieMemoria()
        {
            return _memorizable.dameNumeroSerie();
        }

        public string? NumSerieProcesador()
        {
            return _procesable.dameNumeroSerie();
        }

        public virtual double precioTotal()
        {
            double resultado;
            resultado = _procesable.getPrecio() + _memorizable.getPrecio() + _guardable.getPrecio();
            return resultado;
        }

        public virtual int calorTotal()
        {
            int resultado;
            resultado = _procesable.getCalor() + _memorizable.getCalor() + _guardable.getCalor();
            return resultado;
        }
    }

}
