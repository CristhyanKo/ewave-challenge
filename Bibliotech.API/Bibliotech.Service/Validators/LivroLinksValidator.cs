using Bibliotech.Domain.Entites;
using FluentValidation;
using System;

namespace Bibliotech.Service.Validators
{
    public class LivroLinksValidator : AbstractValidator<LivroLinks>
    {
        public LivroLinksValidator()
        {
            RuleFor(column => column).NotNull().OnAnyFailure(x => throw new ArgumentNullException("Não foi encontrado nenhum item."));

            RuleFor(column => column.Link)
                .NotEmpty().WithMessage("O link é obrgatório.")
                .NotNull().WithMessage("O link é obrgatório.");

            RuleFor(column => column.LivroId)
               .NotEmpty().WithMessage("O livro é obrgatório.")
               .NotNull().WithMessage("O livro é obrgatório.");
        }
    }
}
