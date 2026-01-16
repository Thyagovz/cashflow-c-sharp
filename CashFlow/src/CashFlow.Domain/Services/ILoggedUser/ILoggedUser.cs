using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Services.ILoggedUser;

public interface ILoggedUser
{
    Task<User> Get();
}
