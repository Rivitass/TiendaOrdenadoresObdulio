using Ordenadores;
using Ordenadores.Ordenadores;

namespace OrdenadorTest.Ordenadores
{
    [TestClass]
    public class CreacionOrdenadorTipoA
    {
        [TestMethod]
        public void CreacionOrdenadorMaria()
        {
            IOrdenadorFactoriaMethod miFactoria = new FactoriaOrdenador();
            IListaOrdenadores ordenadores = new ListaOrdenadores();

            ordenadores.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorMaria));

            Assert.IsNotNull(ordenadores);
            Assert.AreEqual(30, ordenadores.calorTotal());
            Assert.AreEqual(284, ordenadores.precioTotal());
        }
        [TestMethod]
        public void CreacionOrdenadorAndres()
        {
            IOrdenadorFactoriaMethod miFactoria = new FactoriaOrdenador();
            IListaOrdenadores ordenadores = new ListaOrdenadores();

            ordenadores.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorAndres));

            Assert.IsNotNull(ordenadores);
            Assert.AreEqual(123, ordenadores.calorTotal());
            Assert.AreEqual(556, ordenadores.precioTotal());
        }

        [TestMethod]
        public void CreacionOrdenadorMariayAndres()
        {
            IOrdenadorFactoriaMethod miFactoria = new FactoriaOrdenador();
            IListaOrdenadores ordenadores = new ListaOrdenadores();

            ordenadores.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorAndres));
            ordenadores.add(miFactoria.dameOrdenador(TipoOrdenador.OrdenadorMaria));

            Assert.IsNotNull(ordenadores);
            Assert.AreEqual(153, ordenadores.calorTotal());
            Assert.AreEqual(840, ordenadores.precioTotal());
        }
    }
}
