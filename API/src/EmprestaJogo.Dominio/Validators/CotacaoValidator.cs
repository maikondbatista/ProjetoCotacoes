using Cotacoes.Domain.Entities;
using FluentValidation;
using Cotacoes.Domain.Utils.Messages;

namespace Cotacoes.Domain.Validations
{
    public class CotacaoValidator : AbstractValidator<Cotacao>
    {
        public CotacaoValidator()
        {
            RuleFor(a => a.CNPJComprador)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .MaximumLength(200)
                .WithMessage(Messages.MaximumCharacters("{PropertyName}", 20));

            RuleFor(a => a.CNPJFornecedor)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .MaximumLength(200)
                .WithMessage(Messages.MaximumCharacters("{PropertyName}", 20));

            RuleFor(a => a.NumeroCotacao)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"));

            RuleFor(a => a.DataCotacao)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"));

            RuleFor(a => a.DataEntregaCotacao)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"));

            RuleFor(a => a.CEP)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"));
            
            RuleFor(a => a.Logradouro)
                .MaximumLength(200)
                .WithMessage(Messages.MaximumCharacters("{Propertyname}", 200));

            RuleFor(a => a.Complemento)
                .MaximumLength(50)
                .WithMessage(Messages.MaximumCharacters("{Propertyname}", 200));

            RuleFor(a => a.Bairro)
                .MaximumLength(80)
                .WithMessage(Messages.MaximumCharacters("{Propertyname}", 200));

            RuleFor(a => a.UF)
                .MaximumLength(2)
                .WithMessage(Messages.MaximumCharacters("{Propertyname}", 2));

            RuleFor(a => a.Observacao)
                .MaximumLength(200)
                .WithMessage(Messages.MaximumCharacters("{Propertyname}", 200));

            RuleForEach(child => child.CotacaoItens)
                .SetValidator(child => new CotacaoItemValidator());

        }
    }
}
