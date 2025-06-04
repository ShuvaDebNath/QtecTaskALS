
using MediatR;

namespace QtecTaskALS.Application.JournalEntries.Commands;

public class CreateJournalEntryCommand : IRequest<int>
{
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<JournalEntryLineDto> Lines { get; set; } = [];
}
