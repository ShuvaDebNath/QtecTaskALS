
using MediatR;
using QtecTaskALS.Application.Accounts.Interfaces;
using QtecTaskALS.Application.Accounts.Queries;

namespace QtecTaskALS.Application.Accounts.Handlers;

public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<AccountDto>>
{
    private readonly IAccountRepository _accountRepo;

    public GetAccountsQueryHandler(IAccountRepository accountRepo)
    {
        _accountRepo = accountRepo;
    }

    public Task<List<AccountDto>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var accounts = _accountRepo.GetAccounts();
        return Task.FromResult(accounts);
    }
}
