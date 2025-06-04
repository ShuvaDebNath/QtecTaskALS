using MediatR;
using Microsoft.AspNetCore.Mvc;
using QtecTaskALS.Application.JournalEntries.Commands;
using QtecTaskALS.Application.JournalEntries.Queries;

namespace QtecTaskALS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JournalEntriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public JournalEntriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateJournalEntryCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entries = await _mediator.Send(new GetJournalEntriesQuery());
        return Ok(entries);
    }
}
