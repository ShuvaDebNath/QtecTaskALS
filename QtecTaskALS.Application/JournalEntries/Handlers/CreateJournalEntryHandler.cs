using MediatR;
using QtecTaskALS.Application.JournalEntries.Commands;
using QtecTaskALS.Application.JournalEntries.Interfaces;
using System.Threading.Tasks;

namespace QtecTaskALS.Application.JournalEntries.Handlers;

public class CreateJournalEntryHandler : IRequestHandler<CreateJournalEntryCommand, int>
{
    private readonly IJournalEntryRepository _repo;

    public CreateJournalEntryHandler(IJournalEntryRepository repo)
    {
        _repo = repo;
    }

    public Task<int> Handle(CreateJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var id = _repo.CreateJournalEntry(request);
        return Task.FromResult(id);
    }
}

