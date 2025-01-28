namespace StatementWebApp.Core.Exception;

public class InternalServerErrorException(string message) : System.Exception(message);