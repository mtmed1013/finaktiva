using BackWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackWebApi.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<EventLogType> EventLogType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.ToTable("EventLogs");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdTipo).HasColumnName("idTipo").IsRequired();
                entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(-1).IsRequired();
                entity.Property(e => e.FechaRegistra).HasColumnName("fecha_registra")
                .HasDefaultValueSql("getdate()")
                .HasColumnType("smalldatetime")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

                entity.HasOne(e => e.Tipo)
                .WithMany()
                .HasForeignKey(e => e.IdTipo);
            });

            modelBuilder.Entity<EventLogType>(entity =>
            {
                entity.ToTable("EventLogsType");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}