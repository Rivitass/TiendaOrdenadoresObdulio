using Ordenadores.Almacen;
using Ordenadores.Pedido;
using Ordenadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenadorTest.Almacen
{
    [TestClass]
    public class NoStockDisponibleTest
    {
        [TestMethod]
        public void CreacionOrdenadorTipoD_SinStock()
        {
            IOrdenadorFactoriaMethod miFactoria = new FactoriaOrdenador();
            PedidosAB pedidoA = new PedidosAB();
            PedidosAB pedidoB = new PedidosAB();
            Factura FacturaA = new Factura();
            Factura FacturaB = new Factura();
            Factura FacturaC = new Factura();



            pedidoA.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorMaria));
            pedidoA.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorAndres));

            pedidoB.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorTiburcioII));
            pedidoB.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorAndresCF));

            FacturaA.add(pedidoA);
            FacturaB.add(pedidoB);
            FacturaC.add(pedidoA);
            FacturaC.add(pedidoB);

            Assert.IsNotNull(pedidoA);
            Assert.IsNotNull(pedidoB);
            Assert.IsNotNull(FacturaA);
            Assert.IsNotNull(FacturaB);
            Assert.IsNotNull(FacturaC);

            Assert.AreEqual(840, FacturaA.facturacionTOtal());
            Assert.AreEqual(1048, FacturaB.facturacionTOtal());
            Assert.AreEqual(1888, FacturaC.facturacionTOtal());


            Assert.AreEqual("Stock disponible", FacturaA.IsValidPedido());
            Assert.AreEqual("Stock disponible", FacturaB.IsValidPedido());
            Assert.AreEqual("No hay suficiente stock", FacturaC.IsValidPedido());
        }
    }
}
