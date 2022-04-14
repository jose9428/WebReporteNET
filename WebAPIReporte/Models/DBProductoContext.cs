using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIReporte.Models
{
    public partial class DBProductoContext : DbContext
    {
        public DBProductoContext()
        {
        }

        public DBProductoContext(DbContextOptions<DBProductoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Data source=(local); Initial Catalog=DBProducto;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__PRODUCTO__88BD0357D04D59EC");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEN");

                entity.Property(e => e.NomProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOM_PRODUCTO");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("PRECIO");

                entity.Property(e => e.Stock).HasColumnName("STOCK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
