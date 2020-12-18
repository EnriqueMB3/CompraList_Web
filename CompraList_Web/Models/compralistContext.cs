using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompraList_Web.Models
{
    public partial class compralistContext : DbContext
    {
        public compralistContext()
        {
        }

        public compralistContext(DbContextOptions<compralistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=204.93.216.11; user id=itesrcne_compral; password=kAfeA3wjWYY@UEs; database=itesrcne_compralist;");

                //optionsBuilder.UseMySql("server=localhost; user id=root; password=root; database=compralist;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Listo).HasColumnType("bit(2)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.QuienAgrego).HasColumnType("varchar(45)");
            });
        }
    }
}
