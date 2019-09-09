using Bibliotech.Domain.Entites;
using Bibliotech.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bibliotech.Infra.Data.Context
{
    public class BibliotechContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=;Database=bibliotech");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Livro>(new LivroMap().Configure);
            modelBuilder.Entity<Autor>(new AutorMap().Configure);
            modelBuilder.Entity<Autor>().HasData(
                new Autor{ Id=1,Nome="Machado de Assis", DataNascimento=new DateTime(1839,06,21) },
                new Autor { Id=2,Nome = "Carlos Drummond de Andrade", DataNascimento =  new DateTime(1999, 10, 11) },
                new Autor { Id=3,Nome = "Clarice Lispector", DataNascimento =  new DateTime(1937, 02, 07) },
                new Autor { Id=4,Nome = "João Guimarães Rosa", DataNascimento =  new DateTime(1985, 01, 28) }
                );
            modelBuilder.Entity<Editora>(new EditoraMap().Configure);
            modelBuilder.Entity<Editora>().HasData(
                new Editora { Id=1, Nome="Global"},
                new Editora { Id=2, Nome="Arte Editorial"},
                new Editora { Id=3, Nome="Europa"},
                new Editora { Id=4, Nome= "Ecclesiae Editora" },
                new Editora { Id=5, Nome= "Fonte Editorial" },
                new Editora { Id=6, Nome= "Imago" },
                new Editora { Id=7, Nome= "Jurua" }
                );
            modelBuilder.Entity<Genero>(new GeneroMap().Configure);
            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Descricao = "Autobiografia" },
                new Genero { Id = 2, Descricao = "Horror" },
                new Genero { Id = 3, Descricao = "Biografia" },
                new Genero { Id = 4, Descricao = "Apocalipse Zumbi;" },
                new Genero { Id = 5, Descricao = "Romance" },
                new Genero { Id = 6, Descricao = "Fábula" },
                new Genero { Id = 7, Descricao = "Conto" },
                new Genero { Id = 8, Descricao = "Crônica" },
                new Genero { Id = 9, Descricao = "Aventura" },
                new Genero { Id = 10, Descricao = "Guerra" }
                );
            modelBuilder.Entity<LivroLinks>(new LivroLinksMap().Configure);
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<LivroLinks> LivroLinks { get; set; }
    }
}
