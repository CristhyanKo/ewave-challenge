﻿// <auto-generated />
using System;
using Bibliotech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bibliotech.Infra.Data.Migrations
{
    [DbContext(typeof(BibliotechContext))]
    [Migration("20190907212738_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bibliotech.Domain.Entites.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biografia");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Autor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNascimento = new DateTime(1839, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Machado de Assis"
                        },
                        new
                        {
                            Id = 2,
                            DataNascimento = new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Carlos Drummond de Andrade"
                        },
                        new
                        {
                            Id = 3,
                            DataNascimento = new DateTime(1937, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Clarice Lispector"
                        },
                        new
                        {
                            Id = 4,
                            DataNascimento = new DateTime(1985, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "João Guimarães Rosa"
                        });
                });

            modelBuilder.Entity("Bibliotech.Domain.Entites.Editora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Editora");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Global"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Arte Editorial"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Europa"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Ecclesiae Editora"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Fonte Editorial"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Imago"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Jurua"
                        });
                });

            modelBuilder.Entity("Bibliotech.Domain.Entites.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Autobiografia"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Horror"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Biografia"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Apocalipse Zumbi;"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Romance"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Fábula"
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Conto"
                        },
                        new
                        {
                            Id = 8,
                            Descricao = "Crônica"
                        },
                        new
                        {
                            Id = 9,
                            Descricao = "Aventura"
                        },
                        new
                        {
                            Id = 10,
                            Descricao = "Guerra"
                        });
                });

            modelBuilder.Entity("Bibliotech.Domain.Entites.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AutorId");

                    b.Property<string>("Capa")
                        .IsRequired();

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("EditoraId");

                    b.Property<int>("GeneroId");

                    b.Property<int>("Paginas");

                    b.Property<string>("Sinopse")
                        .IsRequired();

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("EditoraId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("Bibliotech.Domain.Entites.LivroLinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link")
                        .IsRequired();

                    b.Property<int>("LivroId");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.ToTable("LivroLinks");
                });

            modelBuilder.Entity("Bibliotech.Domain.Entites.Livro", b =>
                {
                    b.HasOne("Bibliotech.Domain.Entites.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bibliotech.Domain.Entites.Editora", "Editora")
                        .WithMany()
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bibliotech.Domain.Entites.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bibliotech.Domain.Entites.LivroLinks", b =>
                {
                    b.HasOne("Bibliotech.Domain.Entites.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
