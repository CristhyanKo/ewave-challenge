using Bibliotech.Domain.Entites;
using FluentValidation;
using System;

namespace Bibliotech.Service.Validators
{
    public class GeneroValidator : AbstractValidator<Genero>
    {
        public GeneroValidator()
        {
            RuleFor(column => column).NotNull().OnAnyFailure(x => throw new ArgumentNullException("Não foi encontrado nenhum item."));

            RuleFor(column => column.Descricao)
                .NotEmpty().WithMessage("A descrição é obrgatória.")
                .NotNull().WithMessage("A descrição é obrgatória");
        }
    }
}
