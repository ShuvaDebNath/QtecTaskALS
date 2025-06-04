
using MediatR;

namespace QtecTaskALS.Application.Accounts.Queries;

public class GetAccountsQuery : IRequest<List<AccountDto>>
{
}
