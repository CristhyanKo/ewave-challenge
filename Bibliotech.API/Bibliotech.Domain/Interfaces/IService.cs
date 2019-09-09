using Bibliotech.Domain.Entites;
using FluentValidation;
using System.Collections.Generic;

namespace Bibliotech.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Inserir<V>(T obj) where V : AbstractValidator<T>;
        T Atualizar<V>(T obj) where V : AbstractValidator<T>;
        void Remover(int id);
        T Buscar(int id);
        IList<T> Buscar();
    }
}