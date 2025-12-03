using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping ()
    {
        RequestEntity();
        EntityToResponse();
    }
    private void RequestEntity()
    {
        CreateMap<RequestRegisterExpenseJson, Expense>();

    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
    }
}
