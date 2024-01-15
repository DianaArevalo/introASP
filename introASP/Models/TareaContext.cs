using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace introASP.Models;

public partial class TareaContext : DbContext
{
    public TareaContext()
    {
    }

    public TareaContext(DbContextOptions<TareaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brandld> Brandld { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6SS9QEC; Database=Tarea; Trusted_Connection=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.Beerld).HasName("PK__Beer__2933C8047BF77654");

            entity.ToTable("Beer");

            entity.Property(e => e.Beerld).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.BeerldNavigation).WithOne(p => p.Beer)
                .HasForeignKey<Beer>(d => d.Beerld)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beer_Brandld");
        });

        modelBuilder.Entity<Brandld>(entity =>
        {
            entity.HasKey(e => e.Brandld1).HasName("PK__Brandld__DAD651BEBFA049AF");

            entity.ToTable("Brandld");

            entity.Property(e => e.Brandld1).HasColumnName("Brandld");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
