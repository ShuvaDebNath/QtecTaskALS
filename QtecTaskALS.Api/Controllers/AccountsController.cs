using MediatR;
using Microsoft.AspNetCore.Mvc;
using QtecTaskALS.Application.Accounts.Commands;
using QtecTaskALS.Application.Accounts.Queries;

namespace QtecTaskALS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _mediator.Send(new GetAccountsQuery());
        return Ok(accounts);
    }
}
