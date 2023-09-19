using Ordenadores.Procesadores;

namespace OrdenadorTest.Componentes
{
    [TestClass]
    public class ProcesablesTests
    {
        [TestMethod]
        public void CreacionOrdenadorProcesableCores()
        {
            int cores = 9;
            string descripcion = "Intel i7";
            string numeroSerie = "789-XCS";
            double precio = 134;
            int calor = 10;
            double cantidad = 1;

            Procesable procesable = new Procesable(descripcion, numeroSerie, precio, cores, calor, cantidad);
            int actualAlmacenamiento = procesable.getCores();
            Assert.AreEqual(cores, actualAlmacenamiento);
        }
    }
}
