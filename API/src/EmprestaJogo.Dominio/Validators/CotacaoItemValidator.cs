using Cotacoes.Domain.Entities;
using FluentValidation;
using Cotacoes.Domain.Utils.Messages;

namespace Cotacoes.Domain.Validations
{
    public class CotacaoItemValidator : AbstractValidator<CotacaoItem>
    {
        public CotacaoItemValidator()
        {
            RuleFor(a => a.Descricao)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .MaximumLength(150)
                .WithMessage(Messages.MaximumCharacters("{PropertyName}", 20));

            RuleFor(a => a.NumeroItem)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"));

            RuleFor(a => a.Preco)
                .Must(preco => preco > 0)
                .WithMessage(Messages.BiggerThanZero("{PropertyName}"));

            RuleFor(a => a.Quantidade)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"));

            RuleFor(a => a.Marca)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .MaximumLength(150)
                .WithMessage(Messages.MaximumCharacters("{PropertyName}", 50));

            RuleFor(a => a.Unidade)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .MaximumLength(30)
                .WithMessage(Messages.MaximumCharacters("{PropertyName}", 20)); ;

        }
    }
}
