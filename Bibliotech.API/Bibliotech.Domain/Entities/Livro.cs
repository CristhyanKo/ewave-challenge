using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotech.Domain.Entites
{
    public class Livro : BaseEntity
    {
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Descricao { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}