using FluentValidation;
using MP.Core.Application.DTOs;

namespace MP.Core.Application.Validators
{
    public class PessoaValidator : AbstractValidator<PessoaDTO>
    {
        public PessoaValidator() 
        { 
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome deve ser informado.");

            RuleFor(x => x.Documento)
                .NotNull()
                .NotEmpty()
                .WithMessage("Documento deve ser informado.");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Telefone deve ser informado.");

        }
    }
}
