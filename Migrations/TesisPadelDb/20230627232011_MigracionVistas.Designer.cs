﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesisPadel.Data;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    [DbContext(typeof(TesisPadelDbContext))]
    [Migration("20230627232011_MigracionVistas")]
    partial class MigracionVistas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TesisPadel.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<int>("genero")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("TesisPadel.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int?>("LocalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ClubId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("LocalidadId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("TesisPadel.Models.Localidad", b =>
                {
                    b.Property<int>("LocalidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocalidadId"), 1L, 1);

                    b.Property<string>("LocalidadNombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProvinciaId")
                        .HasColumnType("int");

                    b.HasKey("LocalidadId");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Localidad");
                });

            modelBuilder.Entity("TesisPadel.Models.Provincia", b =>
                {
                    b.Property<int>("ProvinciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProvinciaId"), 1L, 1);

                    b.Property<string>("NombreProvincia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProvinciaId");

                    b.ToTable("Provincia");
                });

            modelBuilder.Entity("TesisPadel.Models.Ranking", b =>
                {
                    b.Property<int>("RankingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RankingId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Puntos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RankingId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Ranking");
                });

            modelBuilder.Entity("TesisPadel.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int>("LocalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UsuarioBirhtDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TesisPadel.Models.Club", b =>
                {
                    b.HasOne("TesisPadel.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("TesisPadel.Models.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadId");

                    b.Navigation("Categoria");

                    b.Navigation("Localidad");
                });

            modelBuilder.Entity("TesisPadel.Models.Localidad", b =>
                {
                    b.HasOne("TesisPadel.Models.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaId");

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("TesisPadel.Models.Ranking", b =>
                {
                    b.HasOne("TesisPadel.Models.Categoria", null)
                        .WithMany("Rankings")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("TesisPadel.Models.Categoria", b =>
                {
                    b.Navigation("Rankings");
                });
#pragma warning restore 612, 618
        }
    }
}
