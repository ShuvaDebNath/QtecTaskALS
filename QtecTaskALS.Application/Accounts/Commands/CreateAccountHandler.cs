using MediatR;
using QtecTaskALS.Application.Accounts.Interfaces;

namespace QtecTaskALS.Application.Accounts.Commands;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
{
    private readonly IAccountRepository _accountRepo;

    public CreateAccountHandler(IAccountRepository accountRepo)
    {
        _accountRepo = accountRepo;
    }

    public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var id = _accountRepo.CreateAccount(request.Name, request.Type);
        return await id;
    }
}
