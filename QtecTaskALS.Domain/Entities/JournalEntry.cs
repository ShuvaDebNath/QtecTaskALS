
namespace QtecTaskALS.Domain.Entities;

public class JournalEntry
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<JournalEntryLine> Lines { get; set; } = new List<JournalEntryLine>();
}
