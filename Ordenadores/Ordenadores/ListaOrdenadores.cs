using Ordenadores.Componentes;

namespace Ordenadores.Ordenadores
{
    public class ListaOrdenadores : IListaOrdenadores
    {
        private readonly List<IComponente> listaOrdenadores = new List<IComponente>();

        public void add(IComponente componente)
        {
            listaOrdenadores.Add(componente);
        }

        public int calorTotal()
        {
            int total = 0;

            foreach (var item in listaOrdenadores)
            {
                total += item.calorTotal();
            }

            return total;
        }
        public double precioTotal()
        {
            double total = 0;

            foreach (var item in listaOrdenadores)
            {
                total += item.precioTotal();
            }
            return total;
        }

    }
}
