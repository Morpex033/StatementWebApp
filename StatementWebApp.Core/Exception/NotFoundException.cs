namespace StatementWebApp.Core.Exception;

public class NotFoundException(string message) : System.Exception(message)
{
}