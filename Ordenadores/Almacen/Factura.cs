using Ordenadores.Componentes;
using Ordenadores.Pedido;

namespace Ordenadores.Almacen
{
    public class Factura : PedidosAB
    {
       readonly List<PedidosAB> facturas = new();

        public void add(PedidosAB componente)
        {
            facturas.Add(componente);
        }

        public double facturacionTOtal()
        {
            double total = 0;

            foreach (var item in facturas)
            {
                total += item.precioTotal();
            }

            return total;
        }

        public string? IsValidPedido()
        {

            AlmacenComp miAlmacen = new AlmacenComp();
            int cont = 0;

            foreach (PedidosAB pedidoGrande in facturas)
            {
                foreach (IAlmacenable pedidos in pedidoGrande)
                {
#pragma warning disable CS8604 
                    Componente procesador = miAlmacen.GetCompAlma(pedidos.NumSerieProcesador());

                    Componente memoria = miAlmacen.GetCompAlma(pedidos.NumSerieMemoria());
                    Componente discoDuro = miAlmacen.GetCompAlma(pedidos.NumSerieDiscoDuro());
#pragma warning restore CS8604

                    if (procesador?.Cantidad < 0)
                    {
                        cont++;
                    }

                    if (memoria?.Cantidad < 0)
                    {
                        cont++;
                    }

                    if (discoDuro?.Cantidad < 0)
                    {
                        cont++;
                    }
                }

            }
            if (cont >= 1)
            {
                return "No hay suficiente stock";

            }
            else
            {
                return "Stock disponible";
            }
        }
    }
}
