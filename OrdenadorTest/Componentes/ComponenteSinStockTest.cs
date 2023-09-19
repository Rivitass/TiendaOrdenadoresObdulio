using Ordenadores.Almacen;
using Ordenadores.Componentes;

namespace OrdenadorTest.Componentes
{
    [TestClass]
    public class ComponenteSinStockTest
    {
        [TestMethod]
        public void CreacionOrdenadorSinStockComponente()
        {
            Componente sinStock;
            sinStock = new SinStock();
            Assert.IsNotNull(sinStock);


        }
    }
}
