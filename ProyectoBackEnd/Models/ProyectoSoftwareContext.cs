using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoBackEnd.Models;

public partial class ProyectoSoftwareContext : DbContext
{
    public ProyectoSoftwareContext()
    {
    }

    public ProyectoSoftwareContext(DbContextOptions<ProyectoSoftwareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autenticacion> Autenticacions { get; set; }

    public virtual DbSet<DatosPersonale> DatosPersonales { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UAC8OOF\\SQLEXPRESS;Database=ProyectoSoftware;User ID=sa;Password=jefc2004;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autenticacion>(entity =>
        {
            entity.HasKey(e => e.AutenticacionId).HasName("PK__Autentic__3E8C6FA3C64C9CC8");

            entity.ToTable("Autenticacion");

            entity.Property(e => e.AutenticacionId).HasColumnName("AutenticacionID");
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimoIntento).HasColumnType("datetime");
            entity.Property(e => e.UsuCreador)
                .HasMaxLength(50)
                .HasColumnName("usuCreador");
            entity.Property(e => e.UsuModificador)
                .HasMaxLength(50)
                .HasColumnName("usuModificador");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Autenticacions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Autenticacion_Usuarios");
        });

        modelBuilder.Entity<DatosPersonale>(entity =>
        {
            entity.HasKey(e => e.DatosPersonalesId).HasName("PK__DatosPer__62932A50E3D17EFB");

            entity.HasIndex(e => e.Identificacion, "UQ__DatosPer__D6F931E591C57840").IsUnique();

            entity.Property(e => e.DatosPersonalesId).HasColumnName("DatosPersonalesID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.EstadoCivil).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Identificacion).HasMaxLength(20);
            entity.Property(e => e.Nacionalidad).HasMaxLength(100);
            entity.Property(e => e.Ocupacion).HasMaxLength(100);
            entity.Property(e => e.Sexo).HasMaxLength(10);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.UsuCreador)
                .HasMaxLength(50)
                .HasColumnName("usuCreador");
            entity.Property(e => e.UsuModificador)
                .HasMaxLength(50)
                .HasColumnName("usuModificador");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.DatosPersonales)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatosPersonales_Usuarios");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D1E48AFA66");

            entity.HasIndex(e => e.NombreRol, "UQ__Roles__4F0B537FC3F725B6").IsUnique();

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreRol).HasMaxLength(50);
            entity.Property(e => e.UsuCreador)
                .HasMaxLength(50)
                .HasColumnName("usuCreador");
            entity.Property(e => e.UsuModificador)
                .HasMaxLength(50)
                .HasColumnName("usuModificador");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7988D2CD849");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F3DFFCB95C").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE04659A8CA").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.UsuCreador)
                .HasMaxLength(50)
                .HasColumnName("usuCreador");
            entity.Property(e => e.UsuModificador)
                .HasMaxLength(50)
                .HasColumnName("usuModificador");
        });

        modelBuilder.Entity<UsuarioRole>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CD2A2A16F5C1");

            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.UsuCreador)
                .HasMaxLength(50)
                .HasColumnName("usuCreador");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRoles_Roles");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRoles_Usuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
