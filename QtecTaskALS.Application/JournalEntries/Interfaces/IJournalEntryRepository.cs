using QtecTaskALS.Application.JournalEntries.Commands;

namespace QtecTaskALS.Application.JournalEntries.Interfaces;

public interface IJournalEntryRepository
{
    int CreateJournalEntry(CreateJournalEntryCommand command);
}
