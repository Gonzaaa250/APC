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
    [Migration("20230808194543_arreglos")]
    partial class arreglos
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

                    b.Property<int?>("RankingId")
                        .HasColumnType("int");

                    b.Property<int>("genero")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.HasIndex("RankingId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("TesisPadel.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"), 1L, 1);

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClubId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("TesisPadel.Models.Ranking", b =>
                {
                    b.Property<int>("RankingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RankingId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Club")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Puntos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("RankingId");

                    b.HasIndex("UsuarioId");

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

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Edad")
                        .HasColumnType("datetime2");

                    b.Property<int>("Localidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TesisPadel.Models.Categoria", b =>
                {
                    b.HasOne("TesisPadel.Models.Ranking", null)
                        .WithMany("Categorias")
                        .HasForeignKey("RankingId");
                });

            modelBuilder.Entity("TesisPadel.Models.Ranking", b =>
                {
                    b.HasOne("TesisPadel.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TesisPadel.Models.Usuario", b =>
                {
                    b.HasOne("TesisPadel.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("TesisPadel.Models.Ranking", b =>
                {
                    b.Navigation("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}
