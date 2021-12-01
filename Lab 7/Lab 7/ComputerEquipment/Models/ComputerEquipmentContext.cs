using Microsoft.EntityFrameworkCore;

namespace ComputerEquipment.Models
{
    public partial class ComputerEquipmentContext : DbContext
    {
        public ComputerEquipmentContext(DbContextOptions<ComputerEquipmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .HasConstraintName("FK_Devices_To_DeviceTypes");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK_Devices_To_Producers");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
