﻿// <auto-generated />
using Examen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241013190655_Migracion1")]
    partial class Migracion1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.Core.Domain.Entity.Accesorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("TaxiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxiId");

                    b.ToTable("Accesorios");
                });

            modelBuilder.Entity("Examen.Core.Domain.Entity.Chofer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Choferes");
                });

            modelBuilder.Entity("Examen.Core.Domain.Entity.Taxi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoferId")
                        .HasColumnType("int");

                    b.Property<int>("Kilometraje")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChoferId");

                    b.ToTable("Taxis");
                });

            modelBuilder.Entity("Examen.Core.Domain.Entity.Accesorio", b =>
                {
                    b.HasOne("Examen.Core.Domain.Entity.Taxi", null)
                        .WithMany("Accesorios")
                        .HasForeignKey("TaxiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.Core.Domain.Entity.Taxi", b =>
                {
                    b.HasOne("Examen.Core.Domain.Entity.Chofer", null)
                        .WithMany("Taxis")
                        .HasForeignKey("ChoferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.Core.Domain.Entity.Chofer", b =>
                {
                    b.Navigation("Taxis");
                });

            modelBuilder.Entity("Examen.Core.Domain.Entity.Taxi", b =>
                {
                    b.Navigation("Accesorios");
                });
#pragma warning restore 612, 618
        }
    }
}
