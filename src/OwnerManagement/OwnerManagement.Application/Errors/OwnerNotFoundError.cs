using FluentResults;

namespace OwnerManagement.Application.Errors
{
    public class OwnerNotFoundError(string message): Error(message)
    {
    }
}
