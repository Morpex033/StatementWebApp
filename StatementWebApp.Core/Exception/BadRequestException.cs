namespace StatementWebApp.Core.Exception;

public class BadRequestException(string message) : System.Exception(message)
{
    
}