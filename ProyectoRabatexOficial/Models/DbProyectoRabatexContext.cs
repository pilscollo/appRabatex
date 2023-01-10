using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoRabatexOficial.Models;

public partial class DbProyectoRabatexContext : DbContext
{
    public DbProyectoRabatexContext()
    {
    }

    public DbProyectoRabatexContext(DbContextOptions<DbProyectoRabatexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Egreso> Egresos { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<IngresoProducto> IngresoProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<IngresoCliente> IngresoClientes { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockProducto> StockProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V5IU507\\SQLEXPRESS;Database=dbProyectoRabatex;Trusted_Connection=true;User=sa;Password=1234;User=sa;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caja>(entity =>
        {
            entity.ToTable("Caja");
            entity.Property(e=> e.Id).ValueGeneratedNever();
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Id).HasColumnName("Id");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Egreso>(entity =>
        {
            entity.ToTable("Egreso");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.ToTable("Ingreso");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<IngresoProducto>(entity =>
        {
            entity.HasKey(e => e.IdRelacion);

            entity.ToTable("IngresoProducto");

            entity.Property(e => e.IdRelacion).ValueGeneratedNever();

            entity.HasOne(d => d.IdIngresoNavigation).WithMany(p => p.IngresoProductos)
                .HasForeignKey(d => d.IdIngreso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngresoProducto_Ingreso");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.IngresoProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngresoProducto_Producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Unidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IngresoCliente>(entity =>
        {
            entity.HasKey(e => e.IdRelacion);

            entity.ToTable("ProductoCliente");

            entity.Property(e => e.IdRelacion).ValueGeneratedNever();

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.IngresoClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoCliente_Cliente");

            entity.HasOne(d => d.IdIngresoNavigation).WithMany(p => p.IngresoClientes)
                .HasForeignKey(d => d.IdIngreso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoCliente_Producto");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.ToTable("Stock");

            entity.Property(e => e.Id).ValueGeneratedNever();
            
        });

        modelBuilder.Entity<StockProducto>(entity =>
        {
            entity.HasKey(e => e.IdRelacion);

            entity.ToTable("StockProducto");

            entity.Property(e => e.IdRelacion).ValueGeneratedNever();
            
            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.StockProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockProducto_Producto");

            entity.HasOne(d => d.IdStockNavigation).WithMany(p => p.StockProductos)
                .HasForeignKey(d => d.IdStock)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockProducto_Stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
