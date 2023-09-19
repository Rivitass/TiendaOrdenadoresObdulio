using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComponentesTiendaMVC.Models
{
    public enum TipoComponente
    {
        Procesador = 1,
        Memoria = 2,
        DiscoDuro = 3,
    }
    public class Componente
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string? Descripcion { get; set; }
        [Required]
        [MaxLength(20)]
        public string? NumeroSerie { get; set; }
        [Required]
        public double Precio { get; set; }
      
        public int Cores { get; set; }
        [Required]
        public int Grados { get; set; }

        public string? Almacenamiento { get; set; }
        [Range(1,3)]
        public int TipoComponente { get; set; }
        
        public int OrdenadorId { get; set; }

    }
}
