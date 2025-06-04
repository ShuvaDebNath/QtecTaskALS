using MediatR;
using QtecTaskALS.Application.JournalEntries.Interfaces;
using QtecTaskALS.Application.JournalEntries.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QtecTaskALS.Application.JournalEntries.Handlers;

public class GetJournalEntriesQueryHandler : IRequestHandler<GetJournalEntriesQuery, List<JournalEntryDto>>
{
    private readonly IJournalEntryRepository _repo;

    public GetJournalEntriesQueryHandler(IJournalEntryRepository repo)
    {
        _repo = repo;
    }

    public Task<List<JournalEntryDto>> Handle(GetJournalEntriesQuery request, CancellationToken cancellationToken)
    {
        var entries = _repo.GetAllJournalEntries();
        return Task.FromResult(entries);
    }
}
