namespace Banks.Exception;
public class BanksException : System.Exception
{
    public BanksException()
    {
    }

    public BanksException(string message)
            : base(message)
        {
        }

    public BanksException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
}
