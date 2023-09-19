using Ordenadores;
using Ordenadores.Almacen;
using Ordenadores.Pedido;

namespace OrdenadorTest.Almacen
{
    [TestClass]
    public class StockDisponibleTest
    {
        [TestMethod]
        public void CreacionOrdenadorTipoD_StockDisponible()
        {
            IOrdenadorFactoriaMethod miFactoria = new FactoriaOrdenador();
            PedidosAB pedidoA = new PedidosAB();
            Factura FacturaA = new Factura();

            pedidoA.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorMaria));
            pedidoA.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorAndres));

            FacturaA.add(pedidoA);
            Assert.IsNotNull(FacturaA);
#pragma warning disable CS8600 
            string resultado = FacturaA.IsValidPedido();
#pragma warning restore CS8600 

            Assert.AreEqual(840, FacturaA.facturacionTOtal());
            Assert.AreEqual("Stock disponible", resultado);
        }
    }
}
