using Bibliotech.Domain.Entites;
using Bibliotech.Domain.Interfaces;
using Bibliotech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bibliotech.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private BibliotechContext context = new BibliotechContext();
        public void Inserir(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Atualizar(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remover(int id)
        {
            context.Set<T>().Remove(Buscar(id));
            context.SaveChanges();
        }

        public T Buscar(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IList<T> Buscar()
        {
            return context.Set<T>().ToList();
        }
    }
}


