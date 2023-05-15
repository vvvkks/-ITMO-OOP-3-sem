namespace Isu.Extra.Exception;

public class IsuExtraException : System.Exception
{
    public IsuExtraException(string message)
        : base(message)
    {
    }

    public IsuExtraException(string message, System.Exception innerException)
        : base(message, innerException)
    {
        throw new NotImplementedException();
    }
}