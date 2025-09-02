using FluentResults;

namespace PropertyManagement.Application.Errors
{
    public class PropertyNotExistingError(string message) : Error(message) 
    {
    }
}
