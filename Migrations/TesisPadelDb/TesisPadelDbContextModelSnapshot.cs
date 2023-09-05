﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesisPadel.Data;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    [DbContext(typeof(TesisPadelDbContext))]
    partial class TesisPadelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TesisPadel.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"), 1L, 1);

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoImagen")
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

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Puntos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("RankingId");

                    b.HasIndex("ClubId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ranking");
                });

            modelBuilder.Entity("TesisPadel.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("ClubId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TesisPadel.Models.Ranking", b =>
                {
                    b.HasOne("TesisPadel.Models.Club", "Club")
                        .WithMany("Ranking")
                        .HasForeignKey("ClubId");

                    b.HasOne("TesisPadel.Models.Usuario", "Usuario")
                        .WithMany("Ranking")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Club");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TesisPadel.Models.Usuario", b =>
                {
                    b.HasOne("TesisPadel.Models.Club", "Club")
                        .WithMany("Usuario")
                        .HasForeignKey("ClubId");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("TesisPadel.Models.Club", b =>
                {
                    b.Navigation("Ranking");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TesisPadel.Models.Usuario", b =>
                {
                    b.Navigation("Ranking");
                });
#pragma warning restore 612, 618
        }
    }
}
