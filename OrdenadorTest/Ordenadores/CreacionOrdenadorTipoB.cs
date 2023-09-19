using Ordenadores;
using Ordenadores.Ordenadores;

namespace OrdenadorTest.Ordenadores
{
    [TestClass]
    public class CreacionOrdenadorTipoB
    {
        [TestMethod]
        public void CreacionOrdenadorTiburcioyAndres()
        {
            IOrdenadorFactoriaMethod miFactoria = new FactoriaOrdenador();
            IListaOrdenadores ordenadores = new ListaOrdenadores();


            var ordenadorTiburcioII = miFactoria.dameOrdenador(TipoOrdenador.OrdenadorTiburcioII);
            var ordenadorAndresCF = miFactoria.dameOrdenador(TipoOrdenador.OrdenadorAndresCF);


            Assert.IsNotNull(ordenadorTiburcioII);
            Assert.IsNotNull(ordenadorAndresCF);


            ordenadores.add(ordenadorTiburcioII);
            ordenadores.add(ordenadorAndresCF);


            Assert.AreEqual(455, ordenadorTiburcioII.precioTotal());
            Assert.AreEqual(75, ordenadorTiburcioII.calorTotal());
            Assert.AreEqual(593, ordenadorAndresCF.precioTotal());
            Assert.AreEqual(158, ordenadorAndresCF.calorTotal());
        }
    }
}
