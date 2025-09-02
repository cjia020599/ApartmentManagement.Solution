using FluentResults;

namespace OwnerManagement.Application.Errors
{
    public class IndividualUnitNotFoundError(string message) : Error(message)
    {
    }
}
