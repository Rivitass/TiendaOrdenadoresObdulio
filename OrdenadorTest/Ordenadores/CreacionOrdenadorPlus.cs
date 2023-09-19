using Ordenadores.Guardadores;
using Ordenadores.Memorizadores;
using Ordenadores.Ordenadores;
using Ordenadores.Procesadores;

namespace OrdenadorTest.Ordenadores
{
    [TestClass]
    public class CreacionOrdenadorPlus
    {
        [TestMethod]
        public void CalorTotalOrdenadorPlus()
        {
            // Arrange
            IProcesable procesador = new Procesable("i7", "123", 300.00, 8, 50, 1);
            IMemorizable memoriaRAM = new Memorizable("RAM DDR4", "456", 150.00, "16 GB", 40, 1);
            IGuardable discoDuro1 = new Guardable("SSD", "789", 200.00, "500 GB", 60, 1);
            IGuardable discoDuro2 = new Guardable("HDD", "999", 100.00, "250 GB", 70, 1);

            List<IGuardable> discosDuros = new List<IGuardable>
            {
                discoDuro2
            };

            OrdenadorPlus ordenadorPlus = new OrdenadorPlus(procesador, memoriaRAM, discoDuro1, discosDuros);

            int totalCalor = ordenadorPlus.calorTotal();

            Assert.AreEqual(220, totalCalor);
        }

        [TestMethod]
        public void PrecioTotalOrdenadorPlus()
        {
            // Arrange
            IProcesable procesador = new Procesable("i7", "123", 300.00, 8, 50, 1);
            IMemorizable memoriaRAM = new Memorizable("RAM DDR4", "456", 150.00, "16 GB", 40, 1);
            IGuardable discoDuro1 = new Guardable("SSD", "789", 200.00, "500 GB", 60, 1);
            IGuardable discoDuro2 = new Guardable("HDD", "999", 100.00, "250 GB", 70, 1);

            List<IGuardable> discosDuros = new List<IGuardable>
            {
                discoDuro2
            };

            OrdenadorPlus ordenadorPlus = new OrdenadorPlus(procesador, memoriaRAM, discoDuro1, discosDuros);

            double precioTotal = ordenadorPlus.precioTotal();

            Assert.AreEqual(750, precioTotal);
        }
    }
}
