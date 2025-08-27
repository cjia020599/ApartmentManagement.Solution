using FluentResults;

namespace TenantAndLeaseManagement.Application.Errors
{
    public class TenantNotExistingError(string message): Error(message)
    {
    }
}
