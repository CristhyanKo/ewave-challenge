using Bibliotech.Domain.Entites;
using FluentValidation;
using System;

namespace Bibliotech.Service.Validators
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(column => column).NotNull().OnAnyFailure(x => throw new ArgumentNullException("Não foi encontrado nenhum item."));

            RuleFor(column => column.Titulo)
                .NotEmpty().WithMessage("O título é obrgatório.")
                .NotNull().WithMessage("O título é obrgatório.");

            RuleFor(column => column.DataPublicacao)
                .NotEmpty().WithMessage("A data de publicação é obrgatória.")
                .NotNull().WithMessage("A data de publicação é obrgatória.");

            RuleFor(column => column.Paginas)
                .NotEmpty().WithMessage("A quantidade de páginas é obrgatória.")
                .NotNull().WithMessage("A quantidade de páginas é obrgatória.");

            RuleFor(column => column.AutorId)
                .NotEmpty().WithMessage("O autor é obrgatório.")
                .NotNull().WithMessage("O autor é obrgatório.");

            RuleFor(column => column.EditoraId)
                .NotEmpty().WithMessage("A editora é obrgatória.")
                .NotNull().WithMessage("A editora é obrgatória.");

            RuleFor(column => column.Descricao)
                .NotEmpty().WithMessage("A descrição é obrgatória.")
                .NotNull().WithMessage("A descrição é obrgatória.");

            RuleFor(column => column.Sinopse)
                .NotEmpty().WithMessage("A sinopse é obrgatória.")
                .NotNull().WithMessage("A sinopse é obrgatória.");

            RuleFor(column => column.Capa)
                .NotEmpty().WithMessage("A capa é obrgatória.")
                .NotNull().WithMessage("A capa é obrgatória.");
        }
    }
}
