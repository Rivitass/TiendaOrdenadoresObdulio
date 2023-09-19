namespace Ordenadores.Componentes
{
    public class Componente
    {
        public string? NumeroSerie { get; set; }

        public double Precio { get; set; }

        public string? Descripcion { get; set; }

        public double Cantidad { get; set; }

        public Componente(string numeroSerie, double precio, string descripcion, double cantidad)
        {
            this.NumeroSerie = numeroSerie;
            this.Precio = precio;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
        }
        public Componente() { }


    }
}
