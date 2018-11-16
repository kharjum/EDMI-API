using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMDI.Business.Entities
{
    public partial class EDMIDBContext : DbContext
    {
        public EDMIDBContext()
        {
        }

        public EDMIDBContext(DbContextOptions<EDMIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ElectricMeter> ElectricMeter { get; set; }
        public virtual DbSet<Gateways> Gateways { get; set; }
        public virtual DbSet<WaterMeter> WaterMeter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<ElectricMeter>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.SerialNumber })
                    .HasName("IX_ElectricMeter")
                    .IsUnique();

                entity.Property(e => e.FirmwareVersion).HasMaxLength(10);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(10);
            });

            modelBuilder.Entity<Gateways>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.SerialNumber })
                    .HasName("IX_Gateways")
                    .IsUnique();

                entity.Property(e => e.FirmwareVersion).HasMaxLength(10);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(10);
            });

            modelBuilder.Entity<WaterMeter>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.SerialNumber })
                    .HasName("IX_WaterMeter")
                    .IsUnique();

                entity.Property(e => e.FirmwareVersion).HasMaxLength(10);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(10);
            });
        }
    }
}
