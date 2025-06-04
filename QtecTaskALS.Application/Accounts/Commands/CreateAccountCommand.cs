
using MediatR;

namespace QtecTaskALS.Application.Accounts.Commands;

public class CreateAccountCommand : IRequest<int> 
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
