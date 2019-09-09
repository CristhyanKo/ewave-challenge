using Bibliotech.Domain.Entites;
using Bibliotech.Domain.Interfaces;
using Bibliotech.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Bibliotech.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Inserir<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Inserir(obj);
            return obj;
        }

        public T Atualizar<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Atualizar(obj);
            return obj;
        }

        public void Remover(int id)
        {
            if (id == 0)
                throw new ArgumentException("O identificador não pode ser zero.");

            repository.Remover(id);
        }

        public IList<T> Buscar() => repository.Buscar();

        public T Buscar(int id)
        {
            if (id == 0)
                throw new ArgumentException("O identificador não pode ser zero.");

            return repository.Buscar(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
