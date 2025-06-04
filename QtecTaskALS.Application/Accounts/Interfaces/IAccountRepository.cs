
using QtecTaskALS.Application.Accounts.Queries;

namespace QtecTaskALS.Application.Accounts.Interfaces;

public interface IAccountRepository
{
    Task<int> CreateAccount(string name, string type);
    List<AccountDto> GetAccounts();
}
