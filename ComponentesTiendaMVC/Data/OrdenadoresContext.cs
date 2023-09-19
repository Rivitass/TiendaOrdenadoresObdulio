using Microsoft.EntityFrameworkCore;
using ComponentesTiendaMVC.Models;

namespace ComponentesTiendaMVC.Data
{
    public class OrdenadoresContext : DbContext            
    {
        public OrdenadoresContext(DbContextOptions<OrdenadoresContext> options) : base(options)
        { 
        
        }

        public DbSet<Componente> Componente => Set<Componente>();

        public DbSet<Ordenador> Ordenadores => Set<Ordenador>();

        //public DbSet<Pedido> Pedidos => Set<Pedido>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ComponenteDbInitializer(modelBuilder).Seed();
            new OrdenadorInitializer(modelBuilder).Seed();

            //modelBuilder.Entity<PedidoComponente>()
            //    .HasKey(pc => pc.IdOrdenador);

            //modelBuilder.Entity<Pedido>()
            //    .HasOne(p => p.Ordenador)
            //    .WithMany(o => o.Pedidos)
            //    .HasForeignKey(p => p.OrdenadorId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<PedidoComponente>()
            //    .HasOne(pc => pc.Componente)
            //    .WithMany()
            //    .HasForeignKey(pc => pc.ComponenteId)
            //    .OnDelete(DeleteBehavior.NoAction);


        }

    }
}
