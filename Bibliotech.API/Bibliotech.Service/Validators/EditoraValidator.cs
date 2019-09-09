using Bibliotech.Domain.Entites;
using FluentValidation;
using System;

namespace Bibliotech.Service.Validators
{
    public class EditoraValidator : AbstractValidator<Editora>
    {
        public EditoraValidator()
        {
            RuleFor(column => column).NotNull().OnAnyFailure(x => throw new ArgumentNullException("Não foi encontrado nenhum item."));

            RuleFor(column => column.Nome)
                .NotEmpty().WithMessage("O nome é obrgatório.")
                .NotNull().WithMessage("O nome é obrgatório.");
        }
    }
}
