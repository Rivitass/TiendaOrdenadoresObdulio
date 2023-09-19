using Ordenadores.Componentes;

namespace Ordenadores.Memorizadores
{
    public  class Memorizable : Componente,  IMemorizable
    {
        public  string Almacenamiento { get; set; }
        public int Calor { get; set; }
        public new double Precio { get; set; }


        public Memorizable(string descripcion, string numeroSerie, double precio , string almacenamiento, int calor, double cantidad) : base(numeroSerie, precio, descripcion, cantidad)
        {
            this.Almacenamiento = almacenamiento;
            this.Calor = calor;
            this.Precio = precio;
            this.NumeroSerie = numeroSerie;
        }

        public string getAlmacenamiento()
        {
            return Almacenamiento;
        }

        public int getCalor()
        {
            return Calor;
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
