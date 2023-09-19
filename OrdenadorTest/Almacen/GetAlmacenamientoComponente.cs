using Ordenadores.Almacen;
using Ordenadores.Componentes;
using Ordenadores.Memorizadores;

namespace OrdenadorTest.Almacen
{
    [TestClass]
    public class GetAlmacenamientoComponente
    {
        [TestMethod]
        public void ComponenteNoExiste()
        {
           
            string claveComponente = "GPU";
            AlmacenComp almacen = new AlmacenComp();

      
            Componente resultado = almacen.GetCompAlma(claveComponente);

           
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(SinStock));
        }
    }
}
