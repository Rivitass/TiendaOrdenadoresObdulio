using Ordenadores.Componentes;

namespace Ordenadores.Procesadores
{
    public class Procesable : Componente, IProcesable
    {
        public int _Cores { get; set; }

        public int _Calor { get; set; }

        public new double Precio { get; set; }
        public Procesable(string descripcion, string numeroSerie, double precio, int cores, int calor, double cantidad) : base(numeroSerie, precio, descripcion, cantidad)
        {
            _Cores = cores;
            _Calor = calor;
            this.Precio = precio;
            this.NumeroSerie = numeroSerie;
        }

        public int getCalor()
        {
            return _Calor;
        }

        public int getCores()
        {
            return _Cores;
        }

        public double getPrecio()
        {
           return Precio;
        }

        public string? dameNumeroSerie()
        {
            return NumeroSerie;
        }
    }
}
