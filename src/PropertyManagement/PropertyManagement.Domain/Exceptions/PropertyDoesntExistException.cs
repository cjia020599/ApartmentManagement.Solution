namespace PropertyManagement.Domain.Exceptions
{
    public class PropertyDoesntExistException(string message) : Exception(message)
    {
    }
}
