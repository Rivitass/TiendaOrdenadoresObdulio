using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComponentesAPIADONET.Models
{
    public enum TipoComponente
    {
        Procesador = 1,
        Memoria = 2,
        DiscoDuro = 3,
    }
    public class Componente
    {
      
        public int Id { get; set; }
       
        public string? Descripcion { get; set; }
     
        public string? NumeroSerie { get; set; }
        
        public double Precio { get; set; }
      
        public int Cores { get; set; }
        
        public int Grados { get; set; }

        public string? Almacenamiento { get; set; }
       
        public int TipoComponente { get; set; }
        
        public int OrdenadorId { get; set; }

    }
}
