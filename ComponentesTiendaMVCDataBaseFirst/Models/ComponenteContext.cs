using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace ComponentesTiendaMVCDataBaseFirst.Models;

public partial class ComponenteContext : DbContext
{
    public ComponenteContext()
    {
    }

    public ComponenteContext(DbContextOptions<ComponenteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Componente> Componentes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=ComponentesMVC; Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Componente>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });
    }
}
