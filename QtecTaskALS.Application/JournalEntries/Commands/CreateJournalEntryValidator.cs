
using FluentValidation;

namespace QtecTaskALS.Application.JournalEntries.Commands;

public class CreateJournalEntryValidator : AbstractValidator<CreateJournalEntryCommand>
{
    public CreateJournalEntryValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Lines).NotEmpty().WithMessage("At least one line required.");

        RuleFor(x => x)
            .Must(BeBalanced)
            .WithMessage("Total Debit must equal Total Credit.");
    }

    private bool BeBalanced(CreateJournalEntryCommand command)
    {
        var totalDebit = command.Lines.Sum(l => l.Debit);
        var totalCredit = command.Lines.Sum(l => l.Credit);
        return totalDebit == totalCredit;
    }
}
