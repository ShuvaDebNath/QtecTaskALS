using QtecTaskALS.Application.JournalEntries.Commands;
using QtecTaskALS.Application.JournalEntries.Queries;

namespace QtecTaskALS.Application.JournalEntries.Interfaces;

public interface IJournalEntryRepository
{
    int CreateJournalEntry(CreateJournalEntryCommand command);
    List<JournalEntryDto> GetAllJournalEntries();
}
