using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QtecTaskALS.Application.TrialBalance.Queries;

namespace QtecTaskALS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrialBalanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrialBalanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetTrialBalanceQuery());
            return Ok(result);
        }
    }
}
