
using MediatR;

namespace QtecTaskALS.Application.JournalEntries.Queries;

public class GetJournalEntriesQuery : IRequest<List<JournalEntryDto>> { }
