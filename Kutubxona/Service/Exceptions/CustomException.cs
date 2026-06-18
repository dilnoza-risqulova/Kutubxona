namespace Kutubxona.Service.Exceptions;

public class CustomException : Exception
{
    public int statuscode;

    public CustomException(string message, int statuscode) : base(message)
    {
        this.statuscode = statuscode;
    }
}