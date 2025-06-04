
using MediatR;
using QtecTaskALS.Application.TrialBalance.Interfaces;
using QtecTaskALS.Application.TrialBalance.Queries;

namespace QtecTaskALS.Application.TrialBalance.Handlers;

public class GetTrialBalanceQueryHandler : IRequestHandler<GetTrialBalanceQuery, List<TrialBalanceDto>>
{
    private readonly ITrialBalanceRepository _repo;

    public GetTrialBalanceQueryHandler(ITrialBalanceRepository repo)
    {
        _repo = repo;
    }

    public Task<List<TrialBalanceDto>> Handle(GetTrialBalanceQuery request, CancellationToken cancellationToken)
    {
        var result = _repo.GetTrialBalance();
        return Task.FromResult(result);
    }
}
