namespace PropertyManagement.Domain.Exceptions
{
    public class PropertyAlreadyExistException(string message) : Exception(message)
    {
    }
}
