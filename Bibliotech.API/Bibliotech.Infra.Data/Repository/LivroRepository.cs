using Bibliotech.Domain.Entites;
using Bibliotech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bibliotech.Infra.Data.Repository
{
    public class LivroRepository : BaseRepository<Livro>
    {
        private BibliotechContext context = new BibliotechContext();

        public new IList<Livro> Buscar()
        {
            return context.Set<Livro>().Include(nameof(Editora)).Include(nameof(Autor)).Include(nameof(Genero)).ToList();
        }

        public new Livro Buscar(int id)
        {
            return context.Set<Livro>().Include(nameof(Editora)).Include(nameof(Autor)).Include(nameof(Genero)).FirstOrDefault(column => column.Id == id);
        }

        public List<Livro> Buscar(string termo)
        {
            return context.Set<Livro>().Include(nameof(Editora)).Include(nameof(Autor)).Include(nameof(Genero)).Where(column => (column.Genero.Descricao.Contains(termo) || column.Autor.Nome.Contains(termo) || column.Titulo.Contains(termo) || column.Editora.Nome.Contains(termo))).ToList();
        }
    }
}
