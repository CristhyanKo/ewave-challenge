using Bibliotech.Domain.Entites;
using Bibliotech.Infra.Data.Repository;
using System;
using System.Collections.Generic;

namespace Bibliotech.Service.Services
{
    public class LivroService : BaseService<Livro>
    {
        private LivroRepository livro = new LivroRepository();

        public new IList<Livro> Buscar() => livro.Buscar();

        public new Livro Buscar(int id)
        {
            if (id == 0)
                throw new ArgumentException("O identificador não pode ser zero.");

            return livro.Buscar(id);
        }

        public IList<Livro> Buscar(string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return livro.Buscar();

            return livro.Buscar(termo);
        }
    }
}

