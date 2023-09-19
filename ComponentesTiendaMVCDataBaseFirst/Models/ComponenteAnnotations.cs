using System.ComponentModel.DataAnnotations;

namespace ComponentesTiendaMVCDataBaseFirst.Models
{
    [MetadataType(typeof(ComponenteAnnotations))]
    public partial class Componente
    {

    }

    public class ComponenteAnnotations
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        [Required]
        public string Descripcion { get; set; } = null!;

        [StringLength(20)]
        public string NumeroSerie { get; set; } = null!;

        public double Precio { get; set; }

        public int Cores { get; set; }

        public int Grados { get; set; }

        public string? Almacenamiento { get; set; }
    }
}
