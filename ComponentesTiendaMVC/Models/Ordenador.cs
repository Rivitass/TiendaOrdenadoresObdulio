using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComponentesTiendaMVC.Models
{
    public class Ordenador
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrdenador { get; set; }

        [Required]
        public string DescripcionOrdenador { get; set; }

        public List<Componente> Componentes { get; set; }

        //public List<Pedido> Pedidos { get; set; }

    }
}
