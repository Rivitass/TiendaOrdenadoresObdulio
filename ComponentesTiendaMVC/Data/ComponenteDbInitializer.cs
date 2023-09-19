using Microsoft.VisualBasic;
using ComponentesTiendaMVC.Data;
using ComponentesTiendaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ComponentesTiendaMVC.Data
{
    public class ComponenteDbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public ComponenteDbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Componente>().HasData(
                (object)
                new Componente()
                {
                    Id = 1,
                    Descripcion = "Procesador Intel i7",
                    NumeroSerie = "789_XCS",
                    Precio = 134,
                    Cores = 9,
                    Grados = 10,
                    Almacenamiento = "0",
                    TipoComponente = (int)TipoComponente.Procesador,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 2,
                    Descripcion = "Procesador Intel i7",
                    NumeroSerie = "789_XCD",
                    Precio = 138,
                    Cores = 10,
                    Grados = 12,
                    Almacenamiento = "0",
                    TipoComponente = (int)TipoComponente.Procesador,
                    OrdenadorId = 2
                },
                new Componente()
                {
                    Id = 3,
                    Descripcion = "Banco de memoria SDRAM",
                    NumeroSerie = "879FH",
                    Precio = 100,
                    Cores = 0,
                    Grados = 10,
                    Almacenamiento = "512",
                    TipoComponente = (int)TipoComponente.Memoria,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 4,
                    Descripcion = "Banco de memoria SDRAM",
                    NumeroSerie = "879FH_L",
                    Precio = 125,
                    Cores = 0,
                    Grados = 15,
                    Almacenamiento = "1024",
                    TipoComponente = (int)TipoComponente.Memoria,
                    OrdenadorId = 2
                },
                new Componente()
                {
                    Id = 5,
                    Descripcion = "Disco Duro Scan Disk",
                    NumeroSerie = "789_XX",
                    Precio = 50,
                    Cores = 0,
                    Grados = 10,
                    Almacenamiento = "500000",
                    TipoComponente = (int)TipoComponente.DiscoDuro,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 6,
                    Descripcion = "Disco Duro Scan Disk",
                    NumeroSerie = "789_XX_2",
                    Precio = 90,
                    Cores = 0,
                    Grados = 29,
                    Almacenamiento = "1000000",
                    TipoComponente = (int)TipoComponente.DiscoDuro,
                    OrdenadorId = 2
                }
            );
        }

    }
}
