using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tpCourgetteV2.Entities;

public partial class TpCourgetteContext : DbContext
{
    public TpCourgetteContext()
    {
    }

    public TpCourgetteContext(DbContextOptions<TpCourgetteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calcul> Calculs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=TpCourgette;User=blizzard2;Password=blizzard2;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calcul>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("calcul");

            entity.Property(e => e.Kc)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("kc");
            entity.Property(e => e.SurfaceCulture)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("surfaceCulture");
            entity.Property(e => e.VolumeReserveEau)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("volumeReserveEau");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
