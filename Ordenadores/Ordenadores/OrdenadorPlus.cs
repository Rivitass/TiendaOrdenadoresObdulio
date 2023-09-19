using Ordenadores.Guardadores;
using Ordenadores.Memorizadores;
using Ordenadores.Procesadores;

namespace Ordenadores.Ordenadores
{
    public class OrdenadorPlus : Ordenador
    {
        readonly List<IGuardable> discosDuros;
        public OrdenadorPlus(IProcesable procesador, IMemorizable memoriaRAM, IGuardable discoDuro, List<IGuardable> discosDuros) : base(procesador, memoriaRAM, discoDuro)
        {
            this.discosDuros = discosDuros;
        }

        public override int calorTotal()
        {
            int resultado;
            resultado = base.calorTotal();

            foreach (var disco in discosDuros)
            {
                resultado += disco.getCalor();
            }
            return resultado;
        }

        public override double precioTotal()
        {
            double resultado;
            resultado = base.precioTotal();
            foreach (var disco in discosDuros)
            {
                resultado += disco.getPrecio();
            }
            return resultado;
        }
    }
}
