using MediatR;

namespace QtecTaskALS.Application.TrialBalance.Queries;

public class GetTrialBalanceQuery : IRequest<List<TrialBalanceDto>> { }
