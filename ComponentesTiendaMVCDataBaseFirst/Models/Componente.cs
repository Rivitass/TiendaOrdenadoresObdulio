using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ComponentesTiendaMVCDataBaseFirst.Models;

public partial class Componente
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string Descripcion { get; set; } = null!;

    [StringLength(20)]
    public string NumeroSerie { get; set; } = null!;

    public double Precio { get; set; }

    public int Cores { get; set; }

    public int Grados { get; set; }

    public string? Almacenamiento { get; set; }
}
