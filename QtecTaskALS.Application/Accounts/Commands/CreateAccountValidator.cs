using FluentValidation;
namespace QtecTaskALS.Application.Accounts.Commands;

public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
    }
}
