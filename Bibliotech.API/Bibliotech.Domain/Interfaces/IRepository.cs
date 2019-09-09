using Bibliotech.Domain.Entites;
using System.Collections.Generic;

namespace Bibliotech.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Inserir(T obj);
        void Atualizar(T obj);
        void Remover(int id);
        T Buscar(int id);
        IList<T> Buscar();
    }
}