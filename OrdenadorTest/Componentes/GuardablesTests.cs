using Ordenadores.Guardadores;

namespace OrdenadorTest.Componentes
{
    [TestClass]
    public class GuardablesTests
    {
        [TestMethod]
        public void CreacionOrdenadorAlmacenamientoGuardable()
        {
            string almacenamiento = "500GB";
            string descripcion = "SanDisk";
            string numeroSerie = "789-XX";
            double precio = 50;
            int calor = 10;
            double cantidad = 1;

            Guardable guardable = new Guardable(descripcion, numeroSerie, precio, almacenamiento, calor, cantidad);
            string actualAlmacenamiento = guardable.getAlmacenamiento();
            Assert.AreEqual(almacenamiento, actualAlmacenamiento);
        }
    }
}
