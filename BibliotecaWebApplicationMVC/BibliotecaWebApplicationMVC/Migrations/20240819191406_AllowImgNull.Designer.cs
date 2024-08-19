﻿// <auto-generated />
using System;
using BibliotecaWebApplicationMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaWebApplicationMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240819191406_AllowImgNull")]
    partial class AllowImgNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Autor", b =>
                {
                    b.Property<Guid>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.AutorLibro", b =>
                {
                    b.Property<Guid>("AutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LibroId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AutorId", "LibroId");

                    b.HasIndex("LibroId");

                    b.ToTable("AutorLibros");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Ejemplar", b =>
                {
                    b.Property<int>("EjemplarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EjemplarId"));

                    b.Property<int?>("EstanteId")
                        .HasColumnType("int");

                    b.Property<Guid?>("PublicacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EjemplarId");

                    b.HasIndex("EstanteId");

                    b.HasIndex("PublicacionId");

                    b.ToTable("Ejemplares");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Estante", b =>
                {
                    b.Property<int>("EstanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstanteId"));

                    b.Property<string>("CodigoEstante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstanteriaId")
                        .HasColumnType("int");

                    b.HasKey("EstanteId");

                    b.HasIndex("EstanteriaId");

                    b.ToTable("Estantes");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Estanteria", b =>
                {
                    b.Property<int>("EstanteriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstanteriaId"));

                    b.Property<double>("Alto")
                        .HasColumnType("float");

                    b.Property<double>("Ancho")
                        .HasColumnType("float");

                    b.HasKey("EstanteriaId");

                    b.ToTable("Estanterias");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Libro", b =>
                {
                    b.Property<Guid>("LibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContraportadaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroPaginas")
                        .HasColumnType("int");

                    b.Property<string>("PortadaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PublicacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibroId");

                    b.HasIndex("PublicacionId")
                        .IsUnique()
                        .HasFilter("[PublicacionId] IS NOT NULL");

                    b.ToTable("Libros", (string)null);
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Publicacion", b =>
                {
                    b.Property<Guid>("PublicacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PublicacionId");

                    b.ToTable("Publicaciones");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Revista", b =>
                {
                    b.Property<Guid>("RevistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PublicacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RevistaId");

                    b.HasIndex("PublicacionId")
                        .IsUnique()
                        .HasFilter("[PublicacionId] IS NOT NULL");

                    b.ToTable("Revistas", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "ProviderKey");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.AutorLibro", b =>
                {
                    b.HasOne("BibliotecaWebApplicationMVC.Models.Autor", "Autor")
                        .WithMany("AutorLibros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaWebApplicationMVC.Models.Libro", "Libro")
                        .WithMany("AutorLibros")
                        .HasForeignKey("LibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Ejemplar", b =>
                {
                    b.HasOne("BibliotecaWebApplicationMVC.Models.Estante", "Estante")
                        .WithMany("Ejemplares")
                        .HasForeignKey("EstanteId");

                    b.HasOne("BibliotecaWebApplicationMVC.Models.Publicacion", "Publicacion")
                        .WithMany("Ejemplares")
                        .HasForeignKey("PublicacionId");

                    b.Navigation("Estante");

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Estante", b =>
                {
                    b.HasOne("BibliotecaWebApplicationMVC.Models.Estanteria", "Estanteria")
                        .WithMany("Estantes")
                        .HasForeignKey("EstanteriaId");

                    b.Navigation("Estanteria");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Libro", b =>
                {
                    b.HasOne("BibliotecaWebApplicationMVC.Models.Publicacion", "Publicacion")
                        .WithOne()
                        .HasForeignKey("BibliotecaWebApplicationMVC.Models.Libro", "PublicacionId");

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Revista", b =>
                {
                    b.HasOne("BibliotecaWebApplicationMVC.Models.Publicacion", "Publicacion")
                        .WithOne()
                        .HasForeignKey("BibliotecaWebApplicationMVC.Models.Revista", "PublicacionId");

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Autor", b =>
                {
                    b.Navigation("AutorLibros");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Estante", b =>
                {
                    b.Navigation("Ejemplares");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Estanteria", b =>
                {
                    b.Navigation("Estantes");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Libro", b =>
                {
                    b.Navigation("AutorLibros");
                });

            modelBuilder.Entity("BibliotecaWebApplicationMVC.Models.Publicacion", b =>
                {
                    b.Navigation("Ejemplares");
                });
#pragma warning restore 612, 618
        }
    }
}
