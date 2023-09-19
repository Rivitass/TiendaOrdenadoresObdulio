using Ordenadores.Componentes;
using System.Collections;

namespace Ordenadores.Pedido
{
    public class PedidosAB : IEnumerable
    {
       readonly List<IComponente> pedidosAB = new();

        public void add(IComponente componente)
        {
            pedidosAB.Add(componente);
        }

        public int calorTotal()
        {
            int total = 0;

            foreach (var item in pedidosAB)
            {
                total += item.calorTotal();
            }

            return total;
        }

        public IEnumerator GetEnumerator()
        {
            return pedidosAB.GetEnumerator();
        }

        public double precioTotal()
        {
            double total = 0;

            foreach (var item in pedidosAB)
            {
                total += item.precioTotal();
            }
            return total;
        }

    }
}
