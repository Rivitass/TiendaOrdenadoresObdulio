using Ordenadores;
using Ordenadores.Pedido;

namespace OrdenadorTest.Pedidos
{
    [TestClass]
    public class PedidosTipoC
    {
        [TestMethod]
        public void CreacionOrdenadorPedidosTipoC()
        {
            IOrdenadorFactoriaMethod miFactoria = new FactoriaOrdenador();
            PedidosAB PedidoB = new PedidosAB();

            PedidoB.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorTiburcioII));
            PedidoB.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorAndresCF));


            Assert.IsNotNull(PedidoB);
            Assert.AreEqual(233, PedidoB.calorTotal());
            Assert.AreEqual(1048, PedidoB.precioTotal());
        }
    }
}
