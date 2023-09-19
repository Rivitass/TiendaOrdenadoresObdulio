using Ordenadores.Memorizadores;

namespace OrdenadorTest.Componentes
{
    [TestClass]
    public class MemorizablesTests
    {
        [TestMethod]
        public void CreacionOrdenadorMemorizableAlmacenamiento()
        {
            string almacenamiento = "500GB";
            string descripcion = "SanDisk";
            string numeroSerie = "789-XX";
            double precio = 50;
            int calor = 10;
            double cantidad = 1;

            Memorizable memorizable = new Memorizable(descripcion, numeroSerie, precio, almacenamiento, calor, cantidad);
            string actualAlmacenamiento = memorizable.getAlmacenamiento();
            Assert.AreEqual(almacenamiento, actualAlmacenamiento);
        }
    }
}
