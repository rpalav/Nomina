﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using DominioNomina.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DatosNomina;

public partial class NominaContext : DbContext
{
    public NominaContext(DbContextOptions<NominaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Credenciales> Credenciales { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Credenciales>(entity =>
        {
            entity.HasKey(e => e.IdCredencial);

            entity.Property(e => e.Contrasenia)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Credenciales)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Credenciales_Usuarios");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LugarNacimiento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.CorreoUsuario)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}