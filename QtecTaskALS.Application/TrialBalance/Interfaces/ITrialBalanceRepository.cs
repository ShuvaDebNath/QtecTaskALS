using QtecTaskALS.Application.TrialBalance.Queries;

namespace QtecTaskALS.Application.TrialBalance.Interfaces;

public interface ITrialBalanceRepository
{
    List<TrialBalanceDto> GetTrialBalance();
}
