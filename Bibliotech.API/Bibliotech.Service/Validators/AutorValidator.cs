using Bibliotech.Domain.Entites;
using FluentValidation;
using System;

namespace Bibliotech.Service.Validators
{
    public class AutorValidator : AbstractValidator<Autor>
    {
        public AutorValidator()
        {
            RuleFor(column => column).NotNull().OnAnyFailure(x => throw new ArgumentNullException("Não foi encontrado nenhum item."));

            RuleFor(column => column.Nome)
                .NotEmpty().WithMessage("O nome é obrgatório.")
                .NotNull().WithMessage("O nome é obrgatório.");

            RuleFor(column => column.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrgatória.")
                .NotNull().WithMessage("A data de nascimento é obrgatória.");
        }
    }
}
