using ComponentesTiendaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ComponentesTiendaMVC.Data
{
    public class OrdenadorInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public OrdenadorInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Ordenador>().HasData(
                new Ordenador()
                {
                    IdOrdenador = 1,
                    DescripcionOrdenador = "Almacen"
                },
                new Ordenador()
                {
                    IdOrdenador = 2,
                    DescripcionOrdenador = "Ordenador de Maria"
                },
                new Ordenador()
                {
                    IdOrdenador = 3,
                    DescripcionOrdenador = "Ordenador de Paco"
                }

            );
        }
    }
}
