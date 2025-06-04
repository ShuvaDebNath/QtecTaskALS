
namespace QtecTaskALS.Application.Accounts.Interfaces;

public interface IAccountRepository
{
    Task<int> CreateAccount(string name, string type);
}
