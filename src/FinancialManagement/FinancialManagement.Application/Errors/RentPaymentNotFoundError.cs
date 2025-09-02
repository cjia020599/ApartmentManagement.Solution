using FluentResults;

namespace FinancialManagement.Application.Errors
{
    public class RentPaymentNotFoundError(string message) : Error(message)
    {
    }
}
